using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerSurveillance.Classes
{
    public class HistoryItem
    {
        public string URL { get; set; }

        public string Title { get; set; }

        public DateTime VisitedTime { get; set; }

        public int Count { get; set; }
    }
}
