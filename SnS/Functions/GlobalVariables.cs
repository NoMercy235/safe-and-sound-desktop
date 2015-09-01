using SnS.Classes;
using SnS.Classes.UserController;
using SnS.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnS.Functions
{
    class GlobalVariables
    {
        public static string ENDPOINT = "http://localhost/Cyclopv2/public/api/";
        public static User user = new User();
        public static LinkedList<Contact> contacts = new LinkedList<Contact>();
        public static UserForm userPanel;
        public static LoginForm loginForm;

        private static string szDeviceName;
        private static bool bIsAdmin;
        public static string rootFolder;

        private static bool bHasCheckedPrivileges = false;
        public static bool bIsLoggedIn = false;


#region Setters and getters
        public static void setGuest()
        {
            user = new User();
            user.allow_file = user.allow_history = user.allow_logger = user.allow_process = user.allow_usb = 1;
            user.type = "Guest";
        }


        public static void setPrivileges()
        {
            if (bHasCheckedPrivileges == false)
            {
                bIsAdmin = Functions.isAdministrator();
            }
        }

        public static bool getPrivileges()
        {
            return bIsAdmin;
        }

        public static void setDeviceName(string szName)
        {
            szDeviceName = szName;
            rootFolder = @"C:\Users\" + GlobalVariables.getDeviceName() + @"\Desktop\WorkerData\";
        }

        public static string getDeviceName()
        {
            return szDeviceName;
        }
#endregion
    }
}
