using SnS.Classes.UserController;
using SnS.Classes.UserController.Objects;
using SnS.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SnS.Classes.Requests
{
    public class ContactsRequests
    {
        private static string ENDPOINT = GlobalVariables.ENDPOINT;

        public static void getContacts()
        {
            try
            {
                string url = ENDPOINT + "social/getContacts?clientId=" + GlobalVariables.user.id;

                WebRequest request = (WebRequest)WebRequest.Create(url);

                WebResponse response = (WebResponse)request.GetResponse();
                string status = ((HttpWebResponse)response).StatusDescription;

                Stream resStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(resStream);

                string responseFromServer = reader.ReadToEnd();

                JavaScriptSerializer oJS = new JavaScriptSerializer();
                Contact[] contacts = oJS.Deserialize<Contact[]>(responseFromServer);

                foreach (Contact contact in contacts)
                {
                    GlobalVariables.contacts.AddLast(contact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Contact postContact(string contactName)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ENDPOINT + "social/addContact/" + GlobalVariables.user.id);

                var postData = "contactName=" + contactName + "";
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                JavaScriptSerializer oJS = new JavaScriptSerializer();
                Contact result = oJS.Deserialize<Contact>(responseString);
                return result;
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
