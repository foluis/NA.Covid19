using Microsoft.EntityFrameworkCore;
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

        public Download GetDownloadByFileName(string fileName)
        {
            var download = context.Downloads.Where(x => x.DownloadedFileName == fileName).Include(b => b.Details).FirstOrDefault();
            return download;
        }

        public void InsertFullDownload(Download download, List<Detail> details)
        {
            var newDownloadId = context.Downloads.Add(download);
            context.SaveChanges();

            details.Where(x => x.DownloadId == 0).ToList().ForEach(b => b.DownloadId = download.Id);

            context.AddRange(details);
            context.SaveChanges();
        }

        public void DeleteDownloadByFileName(string fileName)
        {
            var download = context.Downloads.Where(x => x.DownloadedFileName == fileName).Include(b => b.Details).First();
            context.Remove(download);
            context.SaveChanges();
        }

        public void DeleteDownloadCascadingByFileName(string fileName)
        {
            var download = context.Downloads.Where(x => x.DownloadedFileName == fileName).Include(b => b.Details).FirstOrDefault();
            context.Remove(download);

            var detail = context.Details.Where(x => x.DownloadId == download.Id);
            context.RemoveRange(detail);

            context.SaveChanges();
        }
    }
}
