using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;
using SnS.Functions;



namespace SnS.Classes
{
    class ProcessData : Process
    {
        public static LinkedList<ProcessData> apdProcData = new LinkedList<ProcessData>();
        public static LinkedList<ProcessData> apdPrecedentProcData = new LinkedList<ProcessData>();
        public static LinkedList<int> anPrecedentProcIds = new LinkedList<int>();
        public static LinkedList<int> anProcIds = new LinkedList<int>();

        public static LinkedList<int> apdShownProcesses = new LinkedList<int>();

        private string szName;
        private int nId;

        //private string szDeviceName;
        //private string szUserName;
        private DateTime dtTimeStart;

        private bool bHasBeenShown;


#region constructors
        public ProcessData()
        { }

        public ProcessData(string name, int id, DateTime time)
        {
            szName = name;
            nId = id;
            //szUserName = "";
            dtTimeStart = time;
            bHasBeenShown = false;
        }

        public ProcessData(string name, int id)
        {
            szName = name;
            nId = id;
            bHasBeenShown = false;
        }
#endregion

#region setters and getters

        public void setName(string name)
        {
            szName = name;
        }

        public string getName()
        {
            return szName;
        }

        public void setId(int id)
        {
            nId = id;
        }

        public int getId()
        {
            return nId;
        }

        public void setShownState(bool bState)
        {
            bHasBeenShown = bState;
        }

        public bool getShownState()
        {
            return bHasBeenShown;
        }

#endregion 

#region instance methods

        public void showProcessInfo()
        {
            //if the user had rights to access the 
            if(dtTimeStart.ToString() != "1/1/0001 12:00:00 AM")
            {
                //Console.WriteLine(this.szName + " | " + this.nId + " | " + this.dtTimeStart.ToString());
            }
            else
            {
                //Console.WriteLine(this.szName + " | " + this.nId);
            }
        }

        public String getProcessInfo()
        {
            apdShownProcesses.AddLast(this.getId());
            if (dtTimeStart.ToString() != "1/1/0001 12:00:00 AM")
            {
                return this.szName + " | " + this.nId + " | " + this.dtTimeStart.ToString();
            }
            else
            {
                return this.szName + " | " + this.nId;
            }
        }

        public void processOnExit(object sender, System.EventArgs e)
        {

        }

#endregion

#region static methods
        public static void copyLastProcessList()
        {
            anPrecedentProcIds.Clear();
            for (int i = 0; i < anProcIds.Count; i++)
            {
                anPrecedentProcIds.AddLast(anProcIds.ElementAt(i));
            }

            apdPrecedentProcData.Clear();
            for (int i = 0; i < apdProcData.Count; i++)
            {
                apdPrecedentProcData.AddLast(apdProcData.ElementAt(i));
            }
        }

        public static void checkLastProcessList()
        {
            for (int i = 0; i < anPrecedentProcIds.Count; i++)
            {
                bool bWasFound = false;
                for (int j = 0; j < anProcIds.Count; j++)
                {
                    if (anProcIds.ElementAt(j) == anPrecedentProcIds.ElementAt(i))
                    {
                        bWasFound = true;
                        break;
                    }
                }
                if (bWasFound == false)
                {
                    if (apdPrecedentProcData.ElementAt(i).dtTimeStart.ToString() != "1/1/0001 12:00:00 AM")
                    {
                        apdShownProcesses.Remove(apdShownProcesses.Find(apdPrecedentProcData.ElementAt(i).getId()));
                        TimeSpan dtTimeEnd = System.DateTime.Now.Subtract(apdPrecedentProcData.ElementAt(i).dtTimeStart);
                        FileController.saveApplicationExitTime(apdPrecedentProcData.ElementAt(i).getName(), dtTimeEnd);
                    }
                }
            }
        }


        public static void makeProcessArray(int n, Process[] proc)
        {
            copyLastProcessList();

            DateTime dtTime = DateTime.Now;
            apdProcData.Clear();
            anProcIds.Clear();
            for (int i = 0; i < n; i++)
            {
                bool bHasRights = true;
                //try to get the start time of process
                try
                {
                    dtTime = proc[i].StartTime;
                }
                catch (Exception ex)
                {
                    //if the user has no rights to access it, the date will not be added; 
                    //Console.WriteLine(ex);
                    bHasRights = false;
                }

                if (bHasRights == true && !anProcIds.Contains(proc[i].Id))
                {
                    apdProcData.AddLast(new ProcessData(proc[i].ProcessName, proc[i].Id , dtTime));
                    anProcIds.AddLast(proc[i].Id);
                }
                else
                // merge scos?
                // nu cred, Ca daca nu are acces la timp, nu poate sa il scrie.
                if (bHasRights == false && !anProcIds.Contains(proc[i].Id)) 
                {
                    apdProcData.AddLast(new ProcessData(proc[i].ProcessName, proc[i].Id));
                    anProcIds.AddLast(proc[i].Id);
                }

            }

            checkLastProcessList();
        }

        public static void showAllProcesses()
        {
            for (int i = 0; i < apdProcData.Count; i++)
            {
                apdProcData.ElementAt(i).showProcessInfo();
            }
        }

#endregion

    }
}
