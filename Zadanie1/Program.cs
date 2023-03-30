using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace Zadanie1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsynchFilesSaving afs = new AsynchFilesSaving();
            afs.SaveFilesAsync();
            Console.WriteLine($"Pobrane pliki graficzne ważą: {afs.imagesSize} bajtów");
            Console.ReadKey();
        }
    }
}
