using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnS.Classes
{
    class UsbHandler
    {
        public static DriveInfo[] allDrives = DriveInfo.GetDrives();
        public static DriveInfo[] newDrives;

        public static void UsbInit()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
        }

        public static DriveInfo[] getUsb()
        {
            return allDrives;
        }

        //Putem sa lasam asa cum este si sa facem un log sau sa detectam daca este introdus ceva neobisnuit si sa inchidem toate usb-urile
        public static void showUSB()
        {
            //foreach (DriveInfo d in allDrives)
            //{
            //    Console.WriteLine("Drive {0}", d.Name);
            //    Console.WriteLine();
            //    Console.WriteLine("  Drive type: {0}", d.DriveType);
            //    Console.WriteLine();
            //}
        }
    }
}
