using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Management;

namespace IISLogManager
{
    class Settings
    {
        //Application Defaults - App.Config will override these
        public static String defaultDaysToKeepBeforeZip = "7";
        public static String defaultDaysToKeepZipBeforeDelete = "30";
        public static string AppVer = "0.1a";
        public static string[] lockedSettings = new string[] { "AppVer" };
        
        public static bool isSettingLocked(string setting)
        {
            if (lockedSettings.GetType().IsArray && lockedSettings.Contains(setting))
                return true;
            else
                return false;
        }

        public static string GetAppSetting(string key, string def = null, bool db = true)
        {
            if (db)
            {
                string val = DB.getSetting(key, def);
                return val;
            }
            else
            {
                try
                {
                    string val = ConfigurationManager.AppSettings[key];
                    if (string.IsNullOrEmpty(val))
                        return (def != null) ? def : "error";
                    else
                        return val;
                }
                catch (Exception e)
                {
                    ErrorHandler.logError("Error Reading AppSettings", "Unable to read appsettings value for key '" + key + "'", "100", true, e);
                    return (def != null) ? def : "error";
                }
            }
        }
        public static void SetAppSetting(string key, string value, bool db = false)
        {
            if (db)
            {
                //Need to get the settingID associated with the key
                //If the key does not exist, then we create a new one
                //If the key does exist, we update
            }
            else
            {
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = config.AppSettings.Settings;
                    if (settings[key] == null)
                    {
                        //Key does not exist, create a new one
                        settings.Add(key, value);
                    }
                    else
                    {
                        //Setting exists, edit the value
                        settings[key].Value = value;
                    }
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
                }
                catch (Exception e)
                {
                    ErrorHandler.logError("Unable to update App.config", "See exception for details", "error", true, e);
                }
            }                
        }
    }

    //
    // Custom Configuration reader
    // Used to read custom log locations
    //
    public sealed class CustomLogConfigMapSection : ConfigurationSection
    {
        private static CustomLogConfigMapSection config = ConfigurationManager.GetSection("CustomLogLocations") as CustomLogConfigMapSection;

        public static CustomLogConfigMapSection Config
        {
            get
            {
                return config;
            }
        }

        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        private CustomLogConfigMapConfigElements Settings
        {
            get { return (CustomLogConfigMapConfigElements)this[""]; }
            set { this[""] = value; }
        }

        public IEnumerable<CustomLogConfigMapConfigElement> SettingsList
        {
            get { return this.Settings.Cast<CustomLogConfigMapConfigElement>(); }
        }
    }

    public sealed class CustomLogConfigMapConfigElements : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CustomLogConfigMapConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CustomLogConfigMapConfigElement)element).LogLocation;
        }
    }

    public sealed class CustomLogConfigMapConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("logLocation", IsKey = true, IsRequired = true)]
        public string LogLocation
        {
            get { return (string)base["logLocation"]; }
            set { base["logLocation"] = value; }
        }

        [ConfigurationProperty("logExtension", IsRequired = true)]
        public string LogExtension
        {
            get { return (string)base["logExtension"]; }
            set { base["logExtension"] = value; }
        }
       
    }
}
