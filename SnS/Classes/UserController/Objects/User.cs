using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnS.Classes
{
    class User
    {
        public int id { get; set; }
        public int allow_history { get; set; }
        public int allow_logger { get; set; }
        public int allow_usb { get; set; }
        public int allow_process { get; set; }
        public int allow_file { get; set; }

        public int warning_count { get; set; }

        public string name { get; set; }
        public string ip { get; set; }
        public string last_update { get; set; }
        public string token { get; set; }



    }
}
