using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using SnS.Functions;



namespace SnS.Classes
{   
    class AlertController
    {
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }
        
        [DllImport("User32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        //Returneaza in secunde timpul de la care nu a mai fost folosit mouseul/tastatura, no pressure
        public static uint GetLastInputTime()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? (idleTime / 1000) : 0);
        }

        //Pentru test afiseaza un alert box
        public static void showAlert()
        {
            AutoClosingMessageBox.Show("Nu exista activitate de 60 secunde!", "Caption", 3000);
        }

        public static void showPrivileges(bool bIsAdmin)
        {
            if (bIsAdmin == true)
            {
                AutoClosingMessageBox.Show("Aveti drepturi de ADMIN", "Caption", 3000);
            }
            else
            if(bIsAdmin == false)
            {
                AutoClosingMessageBox.Show("Aveti drepturi de USER", "Caption", 3000);
            }
        }
    }
}
