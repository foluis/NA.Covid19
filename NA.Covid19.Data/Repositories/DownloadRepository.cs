using Microsoft.EntityFrameworkCore;
using NA.Covid19.Data.Interfaces;
using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NA.Covid19.Data.Repositories
{
    public class DownloadRepository: IDownloadRepository
    {
        private readonly Covid19Contexts _context;

        public DownloadRepository(Covid19Contexts context)
        {
            _context = context;
        }

        public void InsertDownload(Download download)
        {
            _context.Downloads.Add(download);
            _context.SaveChanges();
        }

        public List<Download> GetAllDownloads()
        {
            List<Download> downloads = _context.Downloads.ToList();
            return downloads;
        }

        public Download GetDownloadByFileName(string fileName)
        {
            var download = _context.Downloads
                .Where(x => x.DownloadedFileName == fileName)
                .Include(b => b.Details).FirstOrDefault();
            return download;
        }

        public void InsertFullDownload(Download download, List<Detail> details)
        {
            var newDownloadId = _context.Downloads.Add(download);
            _context.SaveChanges();

            details
                .Where(x => x.DownloadId == 0).ToList().ForEach(b => b.DownloadId = download.Id);

            _context.AddRange(details);
            _context.SaveChanges();
        }

        public void DeleteDownloadByFileName(string fileName)
        {
            var download = _context.Downloads
                .Where(x => x.DownloadedFileName == fileName)
                .Include(b => b.Details).First();
            _context.Remove(download);
            _context.SaveChanges();
        }

        public void DeleteDownloadCascadingByFileName(string fileName)
        {
            var download = _context.Downloads
                .Where(x => x.DownloadedFileName == fileName)
                .Include(b => b.Details).FirstOrDefault();
            _context.Remove(download);

            var detail = _context.Details
                .Where(x => x.DownloadId == download.Id);
            _context.RemoveRange(detail);

            _context.SaveChanges();
        }
    }
}
