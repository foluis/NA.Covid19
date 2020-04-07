using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NA.Covid19.Data
{
    public class DownloadOperations
    {
        private static Covid19Contexts context = new Covid19Contexts();

        public void InsertDownload(Download download)
        {
            context.Downloads.Add(download);
            context.SaveChanges();
        }

        public List<Download> GetAllDownloads()
        {
            List<Download> downloads = context.Downloads.ToList();
            return downloads;
        }

        public void InsertFullDownload(Download download, List<Detail> details)
        {
            var newDownloadId = context.Downloads.Add(download);
            context.SaveChanges();

            details.Where(x => x.DownloadId == 0).ToList().ForEach(b => b.DownloadId = download.Id);

            context.AddRange(details);
            context.SaveChanges();
        }

        //public void DeeteDownload(int DownloadId)
        //{
        //    //var blog = context.Downloads.Include(b => b.Posts).First();
        //    context.Remove(blog);
        //}
    }
}
