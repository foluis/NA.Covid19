using NA.Covid19.Data.Interfaces;
using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NA.Covid19.Data.Repositories
{
    public class DetailRepository : IDetailRepository
    {
        private readonly Covid19Contexts _context;

        public DetailRepository(Covid19Contexts context)
        {
            _context = context;
        }

        public void InsertDetail(Detail detail)
        {
            _context.Details.Add(detail);
            _context.SaveChanges();
        }

        public void InsertMultipleDetails(List<Detail> details)
        {
            _context.Details.AddRange(details);
            _context.SaveChanges();
        }

        public List<Detail> GetAllDetails()
        {
            List<Detail> detail = _context.Details.ToList();
            return detail;
        }

        public void DeleteDetailsByDownloadId(int downloadId)
        {
            var detail = _context.Details
                .Where(x => x.DownloadId == downloadId);

            _context.Remove(detail);
            _context.SaveChanges();
        }
    }
}
