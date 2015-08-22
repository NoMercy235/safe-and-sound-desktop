using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlHistoryLibrary;

namespace SnS.Classes
{
     class InternetExplorer
     {
         // List of URL objects
         public List<URL> URLs = new List<URL>();

         public IEnumerable<URL> GetHistory()
         {
        
             // Initiate main object
             UrlHistoryWrapperClass urlhistory = new UrlHistoryWrapperClass();

             // Enumerate URLs in History
             UrlHistoryWrapperClass.STATURLEnumerator enumerator =
                                                urlhistory.GetEnumerator();

             // Iterate through the enumeration
             while (enumerator.MoveNext())
             {
                 // Obtain URL and Title
                 string url = enumerator.Current.URL.Replace('\'', ' ');
                 // In the title, eliminate single quotes to avoid confusion
                 string title ;

                     if(enumerator.Current.Title == null)
                         title = "";
                     else
                         title = enumerator.Current.Title.Replace('\'', ' ');


                 // Create new entry
                 URL U = new URL(url, title, "Internet Explorer");
                 //Console.WriteLine(U.Url);
                 // Add entry to li  st
                 URLs.Add(U);
             }
           
             // Optional
             enumerator.Reset();
           
             // Clear URL History
             //urlhistory.ClearHistory();

             return URLs;
         }
     }
}
