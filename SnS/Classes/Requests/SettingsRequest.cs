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
    class SettingsRequest
    {
        private static string ENDPOINT = GlobalVariables.ENDPOINT;

        public static void getSettings()
        {
            string url = ENDPOINT + "getSettings?deviceName="
                + Functions.GlobalVariables.getDeviceName() + "&deviceIP=" + Functions.Functions.getLocalIPAddress();

            WebRequest request = (WebRequest)WebRequest.Create(url);

            WebResponse response = (WebResponse)request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;

            Stream resStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(resStream);

            string responseFromServer = reader.ReadToEnd();

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            GlobalVariables.user = oJS.Deserialize<User>(responseFromServer);
        }

        public static void postPublicKey()
        {
            Functions.RSA.generateRSAKeys();
            RegistryData.setRegistryPrivateKey(Functions.RSA.getPrivateKey());
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ENDPOINT + "postPublicKey?deviceName=");

                var postData = "client_id=" + GlobalVariables.user.id + "&public_key=" + Functions.RSA.getPublicKey();
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
