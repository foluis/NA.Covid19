using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NA.Covid19.Data.Interfaces
{
    public interface IHistoricalReportRepository
    {
        Task<List<HistoricalReport>> GetHistoricalReportByCountry(string country);
    }
}
