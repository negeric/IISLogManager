using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISLogManager
{
    class Collections
    {

    }
    public class SiteInfo
    {
        public int SiteId { get; set; }
        public String SiteName { get; set; }
        public String AppPoolName { get; set; }
        public String LogPath { get; set; }
        public String SiteStatus { get; set; }
        public String Status { get; set; }
        public SiteInfo(int SiteId, String SiteName, String AppPoolName, String LogPath, String SiteStatus, String Status)
        {
            this.SiteId = SiteId;
            this.SiteName = SiteName;
            this.AppPoolName = AppPoolName;
            this.LogPath = LogPath;
            this.SiteStatus = SiteStatus;
            this.Status = Status;
        }
    }
    public class CustomLog
    {
        public String LogPath { get; set; }
        public String LogExtension { get; set; }
        public CustomLog(String LogPath, String LogExtension)
        {
            this.LogPath = LogPath;
            this.LogExtension = LogExtension;            
        }
    }
}
