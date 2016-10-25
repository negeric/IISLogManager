using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace IISLogManager
{
    class Shared
    {
        public static bool CancelLogCleanup;
        public static string MillisecondsToHuma(long ms)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(ms);
            string human = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
            return human;
        }

        /****
        * File Management including deletes and Zips
        *
        */
        public static int ZipFiles(string site, string dir, int days, bool dryRun)
        {
            int filesZipped = 0;
            if (System.IO.Directory.Exists(@dir))
            {
                //Get datetime format format zip.  If conversion fails, detault is yyyyMMdd
                string DateFormat = Settings.GetAppSetting("ZipFileNameDateFormat");
                DateFormat = (DateFormat != "error") ? DateFormat : "yyyyMMdd";
                string ArchiveDirectory = (Settings.GetAppSetting("ZipArchiveDirectory") != "error") ? Settings.GetAppSetting("ZipArchiveDirectory") + "\\" : "";
                string LogPath = System.IO.Path.GetFullPath(@dir) + ArchiveDirectory;
                //Check to see if archive directory exists, if not, create it
                if (!System.IO.Directory.Exists(@LogPath))
                    System.IO.Directory.CreateDirectory(@LogPath);
                string[] files = System.IO.Directory.GetFiles(@dir, "*.log", System.IO.SearchOption.TopDirectoryOnly);
                if (files.Length > 0)
                {
                    string[] filesToZip = files.Where(c =>
                        {
                            TimeSpan ts = DateTime.Now - System.IO.File.GetLastAccessTime(c);
                            return (ts.Days >= days);
                        }).ToArray();
                    for (int i = 0; i < filesToZip.Length; i++)
                    {
                        if (CancelLogCleanup)
                            break; 
                        filesZipped++;
                        DateTime tmpFileDate = System.IO.File.GetLastAccessTime(@filesToZip[i].ToString());
                        string tmpDate = tmpFileDate.ToString(DateFormat);
                        //Get Log Files full path
                        //Remove spaces in sitename
                        
                        string ZipFileName = LogPath + System.Text.RegularExpressions.Regex.Replace(site, @"\s+", "") + "-" + tmpDate + ".zip";                        
                        if (!dryRun)
                        {
                            //if zip archive exists, add file to it, if not, create a new one
                            bool success;
                            if (System.IO.File.Exists(@ZipFileName))
                                success = AddToZip(filesToZip[i].ToString(), ZipFileName);
                            else
                                success = CreateNewZip(filesToZip[i].ToString(), ZipFileName);
                            if (success && Settings.GetAppSetting("DeleteOriginalLogs") == "true")
                            {
                                try
                                {
                                    System.IO.File.Delete(@filesToZip[i].ToString());
                                } catch (Exception ex)
                                {
                                    ErrorHandler.logError("Unable to delete origin log", "Error deleting the log file " + filesToZip[i].ToString(), "error", true, ex);
                                }
                            }
                        }
                    }
                }
                return filesZipped;
            }
            else
                return -1;
        }
        public static int DeleteZip(string dir, int days, bool dryRun)
        {
            int zipsDeleted = 0;
            string ArchiveDirectory = (Settings.GetAppSetting("ZipArchiveDirectory") != "error") ? Settings.GetAppSetting("ZipArchiveDirectory") + "\\" : "";
            string LogPath = System.IO.Path.GetFullPath(@dir) + ArchiveDirectory;
            if (System.IO.Directory.Exists(@LogPath))
            {
                string[] files = System.IO.Directory.GetFiles(@LogPath, "*.zip", System.IO.SearchOption.TopDirectoryOnly);
                if (files.Length > 0)
                {
                    string[] zipsToDelete = files.Where(c =>
                    {
                        TimeSpan ts = DateTime.Now - System.IO.File.GetLastAccessTime(c);
                        return (ts.Days >= days);
                    }).ToArray();
                    for (int i = 0; i < zipsToDelete.Length; i++)
                    {
                        zipsDeleted++;
                        if (!dryRun)
                        {
                            if (Settings.GetAppSetting("DeleteOldArchives") == "true")
                            {
                                try
                                {
                                    System.IO.File.Delete(@zipsToDelete[i].ToString());
                                }
                                catch (Exception ex)
                                {
                                    ErrorHandler.logError("Unable to delete origin archive", "Error deleting the zip archive " + zipsToDelete[i].ToString(), "error", true, ex);
                                }
                            }
                        }
                    }
                }
                return zipsDeleted;
            }
            else
                return -1;
        }
        private static bool CreateNewZip(string file, string zip)
        {
            if (System.IO.File.Exists(@zip))
            {
                AddToZip(file, zip);
                return false;
            }
            else
            {
                try {
                    using (System.IO.FileStream fs = new System.IO.FileStream(@zip, System.IO.FileMode.Create))
                    {
                        using (ZipArchive archive = new ZipArchive(fs, System.IO.Compression.ZipArchiveMode.Create))
                        {
                            archive.CreateEntryFromFile(@file, System.IO.Path.GetFileName(@file), CompressionLevel.Fastest);
                            archive.Dispose();    
                        }                        
                    }
                    return true;                  
                } catch (Exception ex)
                {
                    ErrorHandler.logError("Error Creating Archive", "Could not create archive " + zip, "error", true, ex);
                    return false;
                }
            }
        }
        private static bool AddToZip(string file, string zip)
        {
            if (System.IO.File.Exists(@zip))
            {
                try
                {
                    using (System.IO.FileStream zipToOpen = new System.IO.FileStream(@zip, System.IO.FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                        {
                            archive.CreateEntryFromFile(@file, System.IO.Path.GetFileName(@file), CompressionLevel.Fastest);
                            archive.Dispose();
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorHandler.logError("Error Adding file to Archive", "Could not add " + file + " to archive " + zip, "error", true, ex);
                    return false;
                }
            } else
            {
                CreateNewZip(file, zip);
                return false;
            }
        }

        public static List<CustomLog> AddToCustomLog(List<CustomLogConfigMapConfigElement> config)
        {
            List<CustomLog> customLog = new List<CustomLog>();
            try
            {                
                foreach (CustomLogConfigMapConfigElement m in config)
                {
                    customLog.Add(new CustomLog(m.LogLocation, m.LogExtension));
                }
            } catch (Exception ex)
            {
                ErrorHandler.logError("Error Creating List", "Could not create CustomLogList from App.config", "error", true, ex);
                customLog.Add(new CustomLog("Error", "Error, see log for details"));
            }
            return customLog;            
        }
    }
}
