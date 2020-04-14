using Microsoft.AspNetCore.Mvc;
using NA.Covid19.Data.Interfaces;
using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NA.Covid19.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricalReportController : ControllerBase
    {
        // private readonly HistoricalReportOperations historicalReportOperations = new HistoricalReportOperations();
        private readonly IHistoricalReportRepository _historicalReportRepositoryt;

        public HistoricalReportController(IHistoricalReportRepository historicalReportRepositoryt)
        {
            _historicalReportRepositoryt = historicalReportRepositoryt;
        }

        [HttpGet("[action]")]
        public IEnumerable<HistoricalReport> GetAllHistoricalReports()
        {
            try
            {
                //var result = _historicalReportRepositoryt .GetAllHistoricalReports();
                //return result;
                return null;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }            
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetHistoricalReportByCountry()
        {
            try
            {
                List<HistoricalReport> result = await _historicalReportRepositoryt.GetHistoricalReportByCountry("");

                if (result == null)
                    return NotFound();
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }

        [HttpGet("[action]/{country}")]
        public async Task<ActionResult> GetHistoricalReportByCountry(string country)
        {
            try
            {
                List<HistoricalReport> result = await _historicalReportRepositoryt.GetHistoricalReportByCountry(country);

                if (result == null)
                    return NotFound();

                if (country == "1")
                {
                    ModelState.AddModelError("country", "Country value can´t 1");
                    return BadRequest(ModelState);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retriving data from database");
            }
        }
    }
}