using SnS.Classes.UserController;
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

namespace SnS.Classes.Requests
{
    public class SocialRequests
    {
        private static string ENDPOINT = GlobalVariables.ENDPOINT;

        public static void getContacts()
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

        public static Contact postContact(string contactName)
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
    }
}
