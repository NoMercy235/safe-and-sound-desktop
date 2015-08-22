using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace SnS.Classes
{
    class settingsFile
    {
        public static int id{get; set;}
        public static string name{get; set;}
        public static TimeSpan lastUpdate{get; set;}

        public static int allowHistory {get; set;}
        public static int allowKeyLogger { get; set; }
        public static int allowUSB { get; set; }
        public static int allowProcess { get; set; }
        public static int allowFile {get; set;}
        public static string userType { get; set; }
        public static string ip { get; set; }



        public static void setTrue()
        {
            allowHistory = 1;
            allowKeyLogger = 1;
            allowUSB = 1;
            allowProcess = 1;
            allowFile = 1;
            userType = "Guest";
        }

       
    }
}
