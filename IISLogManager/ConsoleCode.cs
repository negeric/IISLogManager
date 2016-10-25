using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISLogManager
{
    class ConsoleCode
    {
        private static bool debug = (Settings.GetAppSetting("debug") == "error" || Settings.GetAppSetting("debug") == "false") ? false : true;
        public static void LogCleanup()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            echo("Starting console Log Cleanup");            
            bool dryRun = (Settings.GetAppSetting("DryRun") == "true") ? true : false;
            string daysToKeepBeforeZip = Settings.GetAppSetting("DaysToKeepBeforeZip");
            string daysToKeepZipBeforeDelete = Settings.GetAppSetting("DaysToKeepZipBeforeDelete");
            ErrorHandler.logInfo("Starting CLI Log Cleanup", "CLI Log cleanup Dry Run: " + dryRun.ToString() + ". Days to Keep Logs: " + daysToKeepBeforeZip + ". Days to Keep ZIP: " + daysToKeepZipBeforeDelete, "info");
            ErrorHandler.logIISCleanupInfo("Starting CLI Log Cleanup", "CLI Log cleanup Dry Run: " + dryRun.ToString() + ". Days to Keep Logs: " + daysToKeepBeforeZip + ". Days to Keep ZIP: " + daysToKeepZipBeforeDelete);
            echo("Dry Run: " + dryRun.ToString());
            echo("Days to Keep Logs: " + daysToKeepBeforeZip);
            echo("Days to Keep Zip Archives: " + daysToKeepZipBeforeDelete);
            List<SiteInfo> Sites = IISManager.GetSiteInfo();
            int tmpSites = 0;
            int tmpTotalFilesZipped = 0;
            int tmpTotalZipsDeleted = 0;
            string DryRunText = (dryRun) ? " dry run " : "";
            foreach (SiteInfo site in Sites)
            {
                if (site.SiteName == "Error")
                {
                    echo("Error loading sites.  Please ensure IIS Manager is installed and you have permission to IIS.  See error log for further details");
                }
                else
                {
                    int tmpSiteFilesZipped = 0;
                    int tmpSiteZipsDeleted = 0;
                    tmpSites++;
                    echo("Starting cleanup on site " + site.SiteName);
                    ErrorHandler.logIISCleanupInfo("Starting Cleanup on " + site.SiteName, "Cleanup started on site " + site.SiteName + " within directory " + site.LogPath);
                    //Do Zip
                    tmpSiteFilesZipped = Shared.ZipFiles(site.SiteName, @site.LogPath.Trim(new Char[] { ' ', '*', '.', '!' }), Convert.ToInt32(daysToKeepBeforeZip), dryRun);
                    //Do Zip archive cleanup
                    tmpSiteZipsDeleted = Shared.DeleteZip(@site.LogPath.Trim(new Char[] { ' ', '*', '.', '!' }), Convert.ToInt32(daysToKeepZipBeforeDelete), dryRun);                    
                    tmpTotalFilesZipped = tmpTotalFilesZipped + tmpSiteFilesZipped;
                    tmpTotalZipsDeleted = tmpTotalZipsDeleted + tmpSiteZipsDeleted;
                    echo("Cleaned " + tmpSiteFilesZipped + " from " + site.SiteName + ".  Cleaned " + tmpTotalFilesZipped + " total files");
                    ErrorHandler.logIISCleanupInfo("Finished" + DryRunText + " Cleanup on " + site.SiteName, "Cleanup finished on site " + site.SiteName + " within directory " + site.LogPath + ".  Total files zipped - " + tmpSiteFilesZipped + ", Total ZIPs deleted - " + tmpSiteZipsDeleted);
                }
            }
            watch.Stop();
            string TotalRunTime = Shared.MillisecondsToHuma(watch.ElapsedMilliseconds);
            echo("Finished log cleanup.  Compressed " + tmpTotalFilesZipped + " file(s) and removed " + tmpTotalFilesZipped + " zip archive(s) in " + TotalRunTime);
            ErrorHandler.logIISCleanupInfo("Finished CLI Log Cleanup", "Zipped up " + tmpTotalFilesZipped + " files and removed " + tmpTotalZipsDeleted + " ZIP archives on " + tmpSites + " sites.  Total execution time was - " + TotalRunTime);
        }

        private static void echo(string txt)
        {
            if (debug)
            {
                try {
                    Console.WriteLine(txt);
                }
                catch (Exception e)
                {
                    //Just making sure we can output to console, no need to send the exception anywhere
                }
            }
        }

    }
}
