using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace IISLogManager
{
    class DB
    {
        //
        //SQLite Database Manager Class
        //
        private static string dbName = "IISLogManager.sqlite";
        private static bool isConnected;
        private static SQLiteConnection db;
        public static bool Exists()
        {
            if (System.IO.File.Exists(@dbName))
                return true;
            else
                return false;
        }
        public static void reloadSettings()
        {
            using (SQLiteConnection sdb = new SQLiteConnection("Data Source=" + dbName + ";Version=3;"))
            {
                sdb.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sdb))
                {
                    try
                    {
                        cmd.CommandText = "DROP Table 'settings'";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "CREATE TABLE settings (itemid integer primary key autoincrement not null unique, name varchar(40), value varchar(255), description varchar(1000))";
                        cmd.ExecuteNonQuery();
                        defaults();
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.logError("Error Re-creating the settings Table", "Could not re-create the settings table.  See exception for details", "db", true, ex);
                    }
                }
            }
        }
        public static void Create()
        {
            SQLiteConnection.CreateFile(dbName);
            if (!isConnected)
                connect();
            string settingsTable = "CREATE TABLE settings (itemid integer primary key autoincrement not null unique, name varchar(40), value varchar(255), description varchar(1000))";
            string historyTable = "CREATE TABLE history (itemid integer primary key autoincrement not null unique, event varchar(255), caller varchar(3), status varchar(7), start varchar(25), end varchar(25))";
            string logTable = "CREATE TABLE logs (itemid integer primary key autoincrement not null unique, event varchar(255), type varchar(7), caller varchar(255), message varchar(255), date varchar(25))";
            SQLiteCommand cmd = new SQLiteCommand(settingsTable, db);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(historyTable, db);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(logTable, db);
            cmd.ExecuteNonQuery();
            /*
            string logEntry = "INSERT INTO logs (event, type, caller, message, date) values ('Created Database', 'info', 'DB.cs', 'New database has been created', '" + DateTime.Now.ToString() + "')";
            cmd = new SQLiteCommand(logEntry, db);
            cmd.ExecuteNonQuery();
            string  appVer = "INSERT INTO settings (name, value, description) values ('AppVer', '" + Settings.AppVer + "', 'Application Version')";
            cmd = new SQLiteCommand(appVer, db);
            cmd.ExecuteNonQuery();
            */
            disconnect();
            defaults();
        }
        
        public static void defaults()
        {
            using (SQLiteConnection sdb = new SQLiteConnection("Data Source=" + dbName + ";Version=3;"))
            {
                sdb.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sdb))
                {
                    using (SQLiteTransaction transaction = sdb.BeginTransaction())
                    {
                        string[] sql = new string[18];
                        sql[0] = "INSERT INTO logs(event, type, caller, message, date) values ('Inserting Defaults', 'info', 'DB.cs', 'Default data is being loaded', '" + DateTime.Now.ToString() + "')";
                        sql[1] = "INSERT INTO settings (name, value, description) values ('AppVer', '" + Settings.AppVer + "', 'Application Version')";
                        sql[2] = "INSERT INTO settings (name, value, description) values ('DaysToKeepBeforeZip', '8', 'How long to keep logs before archiving')";
                        sql[3] = "INSERT INTO settings (name, value, description) values ('DaysToKeepZipBeforeDelete', '30', 'How long to keep old archives.  Goes off of archive date, not log date')";
                        sql[4] = "INSERT INTO settings (name, value, description) values ('AdvancedLoggingSiteDirectory', '%siteName', 'IIS site Log directory.  %sitename% will use current sitename')";
                        sql[5] = "INSERT INTO settings (name, value, description) values ('AdvancedLoggingSiteDirectoryAllCaps', 'true', 'Capitalize the sitename if AdvancedLoggingSiteDirectory is set to %sitename')";
                        sql[6] = "INSERT INTO settings (name, value, description) values ('DryRun', 'false', 'Do not archive or delete, just run a report')";
                        sql[7] = "INSERT INTO settings (name, value, description) values ('DeleteOriginalLogs', 'true', 'Delete logs after they are archived')";
                        sql[8] = "INSERT INTO settings (name, value, description) values ('DeleteOldArchives', 'true', 'Delete archives older than DaysToKeepZipBeforeDelete')";
                        sql[9] = "INSERT INTO settings (name, value, description) values ('ZipFileNameDateFormat', 'yyyyMMdd', 'See C# DateTime Format options')";
                        sql[10] = "INSERT INTO settings (name, value, description) values ('ZipArchiveDirectory', 'Archive', 'Folder name for Zip archives to go under.  Can only be a relative path')";
                        sql[11] = "INSERT INTO settings (name, value, description) values ('debug', 'true', 'Enables debug logging')";
                        sql[12] = "INSERT INTO settings (name, value, description) values ('SMTPServer', '', 'SMTP Mail Server')";
                        sql[13] = "INSERT INTO settings (name, value, description) values ('SMTPFromAddress', 'noreply@localhost', 'SMTP Sender Address')";
                        sql[14] = "INSERT INTO settings (name, value, description) values ('SMTPToAddress', '', 'SMTP Mail Recipients')";
                        sql[15] = "INSERT INTO settings (name, value, description) values ('SMTPUseAuth', '', 'SMTP Server Requires Authentication')";
                        sql[16] = "INSERT INTO settings (name, value, description) values ('SMTPUser', '', 'SMTP Username')";
                        sql[17] = "INSERT INTO settings (name, value, description) values ('SMTPPass', '', 'SMTP Password')";
                        foreach (string query in sql)
                        {
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
                sdb.Close();
            }
            
            //string logEntry = "INSERT INTO logs (event, type, caller, message, date) values ('Created Database', 'info', 'DB.cs', 'New database has been created', '" + DateTime.Now.ToString() + "')";
            //using (SQLiteCommand cmd = new SQLiteCommand(logEntry, db))
                //cmd.ExecuteNonQuery();            
        }
                
        private static void connect()
        {
            if (!isConnected)
            {
                try {
                    db = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
                    db.Open();
                    isConnected = true;
                }
                catch (Exception ex)
                {
                    ErrorHandler.logError("Error Opening Database", "Could not open the database connection", "db", true, ex);
                }
            }
        }
        private static void disconnect()
        {
            if (isConnected)
            {
                try
                {
                    db.Close();
                    isConnected = false;                
                }
                catch (Exception ex)
                {
                    ErrorHandler.logError("Error Closing Database", "Could not close the database connection", "db", true, ex);
                }
            }
        }
        public static string getSetting(string settingName, string def = "")
        {
            try
            {
                if (!isConnected)
                    connect();
                string query = "SELECT * FROM settings WHERE name='" + settingName + "' LIMIT 1";
                SQLiteCommand cmd = new SQLiteCommand(query, db);
                using (SQLiteDataReader reader = cmd.ExecuteReader()) { 
                    if (reader.Read() && reader.GetString(reader.GetOrdinal("value")) != "")
                        return reader.GetString(reader.GetOrdinal("value"));
                    else
                    {
                        if (String.IsNullOrEmpty(def))
                            return "error";
                        else
                            return def;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.logError("Error Reading DB Setting", "Could not read settings from SQLite Database", "db", true, ex);
                if (String.IsNullOrEmpty(def))
                    return "error";
                else
                    return def;
            }
        }

        public static System.Data.DataTable getSettings()
        {
            try
            {
                if (!isConnected)
                    connect();
                string query = "SELECT * FROM settings ORDER BY name DESC";
                SQLiteCommand cmd = new SQLiteCommand(query, db);
                System.Data.DataSet ds = new System.Data.DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);
                System.Data.DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                ErrorHandler.logError("Error Reading DB Setting", "Could not read settings from SQLite Database", "db", true, ex);
                return null;
            }
        }
        public static System.Data.DataTable getSettingDetails(int settingid)
        {
            try
            {
                if (!isConnected)
                    connect();
                string query = "SELECT * FROM settings WHERE itemid='" + settingid + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, db);
                System.Data.DataSet ds = new System.Data.DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);
                System.Data.DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                ErrorHandler.logError("Error Reading DB Setting", "Could not read settings from SQLite Database", "db", true, ex);
                return null;
            }
        }
        public static bool updateSetting(int itemId, string name, string value, string description)
        {
            using (SQLiteConnection sdb = new SQLiteConnection("Data Source=" + dbName + ";Version=3;"))
            {
                sdb.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sdb))
                {
                    try {
                        cmd.CommandText = "update settings set name= $n, value= $v, description= $d where itemid= $id";
                        cmd.Parameters.AddWithValue("$n", name);
                        cmd.Parameters.AddWithValue("$v", value);
                        cmd.Parameters.AddWithValue("$d", description);
                        cmd.Parameters.AddWithValue("$id", itemId);
                        cmd.ExecuteNonQuery();
                        return true;
                    } catch (Exception ex)
                    {
                        ErrorHandler.logError("Error Updating DB Setting", "Could not update setting " + name + ".  See exception for details", "db", true, ex);
                        return false;
                    }
                }
            }
        }
        public static bool newSetting(string name, string value, string description)
        {
            using (SQLiteConnection sdb = new SQLiteConnection("Data Source=" + dbName + ";Version=3;"))
            {
                sdb.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sdb))
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO settings (name, value, description) VALUS ($n, $v, $d)";
                        cmd.Parameters.AddWithValue("$n", name);
                        cmd.Parameters.AddWithValue("$v", value);
                        cmd.Parameters.AddWithValue("$d", description);                        
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.logError("Error Creating DB Setting", "Could not create new setting " + name + ".  See exception for details", "db", true, ex);
                        return false;
                    }
                }
            }
        }
        public static bool deleteSetting(int settingId)
        {
            using (SQLiteConnection sdb = new SQLiteConnection("Data Source=" + dbName + ";Version=3;"))
            {
                sdb.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sdb))
                {
                    try
                    {
                        cmd.CommandText = "DELETE FROM settings WHERE itemid=$id";
                        cmd.Parameters.AddWithValue("$id", settingId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.logError("Error Deleting DB Setting", "Could not delete setting " + settingId + ".  See exception for details", "db", true, ex);
                        return false;
                    }
                }
            }
        }
    }
}
