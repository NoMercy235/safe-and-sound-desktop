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
    class ShutdownRequest
    {
        private static string ENDPOINT = GlobalVariables.ENDPOINT;

        public static void getShutdown()
        {
            string url = ENDPOINT + "getShutdown?deviceName=" + Functions.GlobalVariables.getDeviceName();

            WebRequest request = (WebRequest)WebRequest.Create(url);

            WebResponse response = (WebResponse)request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;

            Stream resStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(resStream);

            string responseFromServer = reader.ReadToEnd();

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            string message = oJS.Deserialize<string>(responseFromServer);

            Console.WriteLine(message);

            if (message == "Yes")
            {
                Functions.Functions.shutdown();
            }

        }
    }
}
