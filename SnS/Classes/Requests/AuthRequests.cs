using SnS.Classes.UserController.Objects;
using SnS.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SnS.Classes.Requests
{
    class AuthRequests
    {
        private static string ENDPOINT = GlobalVariables.ENDPOINT;

        public static MessageResponse postLogin(string email, string password)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ENDPOINT + "postLogin");

                var postData = "email=" + email + "&password=" + password;
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
                MessageResponse result = oJS.Deserialize<MessageResponse>(responseString);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
