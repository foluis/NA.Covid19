using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.Covid19.Web.Services
{
    public interface IHistoricalService
    {
        Task<IEnumerable<HistoricalReport>> GetHistoricalReportByCountry(string country);
    }
}
