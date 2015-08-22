using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SnS.Classes;

namespace SnS.Functions
{
    class KeepAlive
    {
        private static Thread thLocalThread;

        private static string szAppName = RegistryData.keyCheckKeepAlive;

        private static Process[] apProcessList = Process.GetProcesses();

        public static void keepApplicationAlive()
        {
            thLocalThread = new Thread(repeatAction);
            thLocalThread.Start();
        }

        public static void repeatAction()
        {
            while (true)
            {
                Thread.Sleep(100);
                apProcessList = Process.GetProcesses();

                bool bIsOpened = false;
                for (int i = 0; i < apProcessList.Length; i++)
                {
                    //Console.WriteLine(ProcessData.apdProcData.ElementAt(i).getName());
                    if (szAppName != null && szAppName.Contains(apProcessList[i].ProcessName))
                    {
                        bIsOpened = true;
                    }
                }

                if (bIsOpened == false)
                {
                    try
                    {
                        Process firstProc = new Process();
                        firstProc.StartInfo.FileName = szAppName;
                        firstProc.EnableRaisingEvents = true;

                        firstProc.Start();
                       
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
}