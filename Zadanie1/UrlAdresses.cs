using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class UrlAdresses
    {
        public string url = "http://51.91.120.89/TABLICE/";
              
        public string[] FetchImageAddresses()
        { 
            string data = new WebClient().DownloadString(url);
            string[] separators = { "\r\n" };
            return data.Split(separators, StringSplitOptions.RemoveEmptyEntries);           
        }
    }
}
