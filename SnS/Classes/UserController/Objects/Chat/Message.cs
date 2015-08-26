using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnS.Classes.UserController.Objects
{
    public class Message
    {
        public int id { get; set; }
        public int sender_id { get; set; }
        public int receiver_id { get; set; }
        public string message { get; set; }
    }
}
