using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace IISLogManager
{
    class IISManager
    {
        private static bool TestMode = false;       
        public static List<SiteInfo> GetSiteInfo()
        {
            List<SiteInfo> siteList = new List<SiteInfo>();
            if (TestMode)
            {
                siteList.Add(new SiteInfo(1, "Test Site", "TestAppPool", "%windir%\\inetpub\\logs\\", "running", "OK"));
            }
            else
            {
                try
                {
                    ServerManager server = new ServerManager();
                    SiteCollection sites = server.Sites;
                    foreach (Site site in sites)
                    {
                        //Get AdvancedLogging Directory
                        string SiteName = Convert.ToString(site.Name);
                        string LogPath;
                        string Status = "OK";
                        try {
                            //Load AppSettings to see if AdvancedLogging is configured
                            string AdvancedLoggingSiteDirectory = Settings.GetAppSetting("AdvancedLoggingSiteDirectory");                            
                            ConfigurationElement logAttr = site.GetChildElement("advancedLogging");
                            ConfigurationAttribute logPathAttr = logAttr.GetAttribute("directory");
                            //Check the app.config to see AdvancedLogging site name directory format
                            if (AdvancedLoggingSiteDirectory == "%siteName")
                            {
                                if (Settings.GetAppSetting("AdvancedLoggingSiteDirectoryAllCaps") == "true")
                                    LogPath = "*" + Convert.ToString(logPathAttr.Value) + SiteName.ToUpper() + "\\";
                                else
                                    LogPath = "*" + Convert.ToString(logPathAttr.Value) + SiteName + "\\";
                            }
                            else if (AdvancedLoggingSiteDirectory != "error")
                                LogPath = "*" + Convert.ToString(logPathAttr.Value) + AdvancedLoggingSiteDirectory + "\\";
                            else
                                LogPath = "*" + Convert.ToString(logPathAttr.Value);
                            //Strip off any beginning identifiers and check if directory exists
                            if (!System.IO.Directory.Exists(@LogPath.Trim(new Char[] { ' ', '*', '.', '!' })))
                            {
                                LogPath = "!" + LogPath;
                                Status = "error";
                            }
                        } catch (Exception ex)
                        {
                            //ApplicationDefaults defaults = site.ApplicationDefaults;
                            LogPath = Convert.ToString(site.LogFile);
                            Status = "error";
                        }
                        site.Applications[0].ToString();
                        
                        siteList.Add(new SiteInfo(Convert.ToInt32(site.Id), SiteName, site.Applications[0].ApplicationPoolName.ToString(), LogPath, site.State.ToString(), Status));
                    }
                }
                catch (Exception e)
                {
                    siteList.Add(new SiteInfo(0, "Error", "Error Loading Site", "Error", "Error", "Error"));
                    ErrorHandler.logError("Error Connecting to IIS Manager", "There was an error thrown while connecting to the IIS Manager, see inner exception for details", "error", true, e);
                }
            }
            return siteList;                        
        }
        private static ConfigurationElement FindElement(ConfigurationElementCollection collection, string elementTagName, params string[] keyValues)
        {
            foreach (ConfigurationElement element in collection)
            {
                if (String.Equals(element.ElementTagName, elementTagName, StringComparison.OrdinalIgnoreCase))
                {
                    bool matches = true;
                    for (int i = 0; i < keyValues.Length; i += 2)
                    {
                        object o = element.GetAttributeValue(keyValues[i]);
                        string value = null;
                        if (o != null)
                        {
                            value = o.ToString();
                        }
                        if (!String.Equals(value, keyValues[i + 1], StringComparison.OrdinalIgnoreCase))
                        {
                            matches = false;
                            break;
                        }
                    }
                    if (matches)
                    {
                        return element;
                    }
                }
            }
            return null;
        }
    }
}
