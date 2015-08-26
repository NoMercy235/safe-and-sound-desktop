using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnS.Classes.UserController
{
    public class Contact
    {
        public int contact_id { get; set; }
        public int client_id { get; set; }
        public string name { get; set; }
        public string message { get; set; }
    }
}
