# IISLogManager
IIS Log Manager was designed as a simple to use IIS Log manager.  THe application uses Microsoft.Web.Administration to invoke a ServerManager to pull IIS Sites and their log settings.
By using Web.Administration, the application is dynamic, and in most cases, can run out of the box.<br />
<b>This is an Alpha release.  It works, but not all settings are implemented</b>

# Custom Log Locations
Beyond dynamically searching IIS Log locations, this application can also cleanup logs located elsewhere on the machine.  To add a custom 
log location, launch the application and click "Tools"->"Custom Log Locations".  As of the Alpha release, these settings are still stored in the App.config file.  
These settings will eventually move to the SqlLite database.

# Settings
IIS Log Manager uses a SqlLite database to store application specific settings.  These settings can be modified by launching the application, then clicking on "Settings"->"Application Settings".  Note that some settings are locked and should never be modified.

<b>Debug</b> - Enable debug logging to the logs\debug-log.txt<br />
<b>ZipFileNameDateFormat</b> - C# DateTime value that is appended to the Zip Archives <i>Default: yyyyMMdd</i><br />
<b>ZipArchiveDirectory</b> - Directory to place Zip archives.  This is relative to the log file parent directory <i>Default: Archive</i><br />
<b>SMTPUser</b> - If SMTP Notifications are enabled and your SMTP server requires authentication, enter it here<br />

# ToDo
These items will be included in future releases

<ul>
<li>Move Custom Log Locations to SqlLite Database</li>
<li>Allow dynamic DaysToKeep options for each log location</li>
<li>Change string[] files in Shared.ZipFiles to use a faster method</li>
<li>Fix static log extension Shared.ZipFiles, should be dynamic</li>
<li>Finish Email Manager and SMTP reports</li>
<li>Multi-thread calls to Shared.ZipFiles to process multiple directories at the same time</li>
</ul>
