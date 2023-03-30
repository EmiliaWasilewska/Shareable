using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace Zadanie1
{
    internal class AsynchFilesSaving
    {
        string[] urls;
        string mainAddress;
        int tableIndex = 0;
        string folderName;
        public long imagesSize;

        public AsynchFilesSaving()
        {
            UrlAdresses urlAddresses = new UrlAdresses();
            urls = urlAddresses.FetchImageAddresses();
            mainAddress = urlAddresses.url;
        }
        public void SaveFilesAsync()
        {
            ensureFolder();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;
            Parallel.For(0, urls.Length, parallelOptions, i =>
            {
                lock (this)
                {
                   new WebClient().DownloadFile(mainAddress + urls[tableIndex], folderName + urls[tableIndex] + ".jpg");
                   FileInfo image = new FileInfo(folderName + urls[tableIndex] + ".jpg");
                   imagesSize += image.Length;
                }
                tableIndex++;               
            });
        }

        private void ensureFolder()
        {
            folderName = "C:\\images_" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd") + "\\");

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }
    }
}
