using SnS.Forms;
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
    class MessagesRequest
    {
        private static string ENDPOINT = GlobalVariables.ENDPOINT;

        private static Message mf;

        public static string message { get; set; }

        public static void getMessages()
        {
            string url = ENDPOINT + "getMessages?deviceName=" + Functions.GlobalVariables.getDeviceName() ;

            WebRequest request = (WebRequest)WebRequest.Create(url);

            WebResponse response = (WebResponse)request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;

            Stream resStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(resStream);

            string responseFromServer = reader.ReadToEnd();

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            message = oJS.Deserialize<string>(responseFromServer);


            if (message != "")
            {
                Thread th = new Thread(run);
                th.Start();
            }
        }

        public static void run()
        {

            mf = new Message(message);
            message = "";
        }
    }
}
