﻿using Microsoft.EntityFrameworkCore;
using NA.Covid19.Data.Interfaces;
using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Covid19.Data.Repositories
{
    public class HistoricalReportRepository : IHistoricalReportRepository
    {
        private readonly Covid19Contexts _context;

        public HistoricalReportRepository(Covid19Contexts context)
        {
            _context = context;
        }

        public async Task<List<HistoricalReport>> GetHistoricalReportByCountry(string country)
        {
            var result = await _context.HistoricalReports.FromSqlRaw("GetHistoricalReport @p0", country).ToListAsync();
            return result;
        }
    }
}