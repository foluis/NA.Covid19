using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NA.Covid19.Data;
using NA.Covid19.Domain;

namespace NA.Covid19.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricalReportController : ControllerBase
    {
        private readonly HistoricalReportOperations historicalReportOperations = new HistoricalReportOperations();

        [HttpGet("[action]")]
        public IEnumerable<HistoricalReport> GetAllHistoricalReports()
        {
            try
            {
                var result = historicalReportOperations.GetAllHistoricalReports();
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }            
        }

        [HttpGet("[action]/{country}")]
        public IEnumerable<HistoricalReport> GetHistoricalReportByCountry(string country)
        {
            try
            {
                var result = historicalReportOperations.GetHistoricalReportByCountry(country);
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

    }
}