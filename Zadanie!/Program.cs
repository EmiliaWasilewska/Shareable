using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_
{
    internal class Program
    {
        static string[] urls;
        const string url = "http://51.91.120.89/TABLICE/";
        static void Main(string[] args)
        {
            string data = new WebClient().DownloadString(url);
            string[] separators = { "\r\n" };
            urls= data.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
