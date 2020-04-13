using Microsoft.EntityFrameworkCore;
using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NA.Covid19.Data
{
    public class HistoricalReportOperations
    {
        //private static Covid19Contexts _context = new Covid19Contexts();

        private readonly Covid19Contexts _context;

        public HistoricalReportOperations(Covid19Contexts context)
        {
            _context = context;
        }

        public List<HistoricalReport> GetAllHistoricalReports()
        {
            var reports = new List<HistoricalReport>();

            reports = _context.HistoricalReports.FromSqlRaw("EXEC GetHistoricalReport").ToList();
            
            return reports;
        }

        public List<HistoricalReport> GetHistoricalReportByCountry(string country)
        {
            var reports = new List<HistoricalReport>();

            reports = _context.HistoricalReports.FromSqlRaw("GetHistoricalReport @p0", country).ToList();
            
            return reports;
        }
    }
}
