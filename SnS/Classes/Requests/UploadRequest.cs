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
    class UploadRequest
    {
        private static string ENDPOINT = GlobalVariables.ENDPOINT;

        public static void uploadData(string szData, string szType, string szTable)
        {
            try
            {
                szData = Functions.Functions.escapeString(szData);
                string[] fileEntries = Directory.GetFiles(GlobalVariables.rootFolder);

                string url = ENDPOINT + "uploadData?data=" + szData + "&type=" + szType + "&table=" + szTable
                    + "&deviceName=" + GlobalVariables.getDeviceName() ;

                WebRequest request = (WebRequest)WebRequest.Create(url);

                WebResponse response = (WebResponse)request.GetResponse();
                string status = ((HttpWebResponse)response).StatusDescription;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
        }
    }
}
