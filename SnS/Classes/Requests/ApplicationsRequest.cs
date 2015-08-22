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
    class ApplicationsRequest
    {
        private static string ENDPOINT = GlobalVariables.ENDPOINT;


        public static void getApplications()
        {
            string url = ENDPOINT + "getApplications";

            WebRequest request = (WebRequest)WebRequest.Create(url);

            WebResponse response = (WebResponse)request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;

            Stream resStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(resStream);

            string responseFromServer = reader.ReadToEnd();

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            Application[] applications = oJS.Deserialize<Application[]>(responseFromServer);

            foreach (Application application in applications)
            {
                FileController.aszProcessFilter.Add(application.application_name);
            }
            FileController.bHasApp = true;

        }
    }
}
