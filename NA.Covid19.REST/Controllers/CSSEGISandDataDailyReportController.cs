using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FileHelpers;
//using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NA.Covid19.Domain.ApiEntities;
using NA.Covid19.Models.FileHelpers;
//using Microsoft.AspNetCore.Mvc;

namespace NA.Covid19.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSSEGISandDataDailyReportController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private const string Path2 = "Covid19_Reports";
        private readonly string _reportsUrl = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports/";
        private readonly IHostEnvironment _host;
        private readonly ILogger _logger;

        public CSSEGISandDataDailyReportController(IHostEnvironment host, ILogger<CSSEGISandDataDailyReportController> logger)
        {
            _host = host;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DownloadReportFile([FromBody] FileParameters fileParameters)
        {
            var fileName = fileParameters.Date + ".csv";

            string uRI = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports/";
            uRI += fileName;

            string path2 = Path.Combine(_host.ContentRootPath, Path2);

            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(new Uri(uRI), Path.Combine(path2, fileName));

                return StatusCode(200);
            }

            catch (WebException ex)
            {
                string algo = "";
                return StatusCode(404, ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                string algo = "";
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("[action]")]
        public void ReadReportFile([FromBody] FileParameters fileParameters)
        {
            var fileName = fileParameters.Url + fileParameters.Date + ".csv";

            CSSEGISandDataDailyReport[] records = Array.Empty<CSSEGISandDataDailyReport>();
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(fileName);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                StreamReader sr = new StreamReader(resp.GetResponseStream());
                using var stream = new StringReader(sr.ReadToEnd());

                var engine = new FileHelperEngine<CSSEGISandDataDailyReport>();

                records = engine.ReadStream(stream);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                Console.WriteLine(ex.ToString()); // with stack trace
            }           
        }

        [HttpPost("[action]")]
        public async Task<IEnumerable<CSSEGISandDataDailyReport>> ReturnReportFile([FromBody] FileParameters fileParameters)
        {
            var fileName = fileParameters.Url + fileParameters.Date + ".csv";

            CSSEGISandDataDailyReport[] records = Array.Empty<CSSEGISandDataDailyReport>();
            try
            {
                //var response = await client.GetAsync(fileName);
                //using var responseStream = await response.Content.ReadAsAsync<TextReader>();

                WebRequest GetURL = WebRequest.Create(fileName);
                Stream page = GetURL.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(page);

                var engine = new FileHelperEngine<CSSEGISandDataDailyReport>();                
                records = engine.ReadStream(sr);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                Console.WriteLine(ex.ToString()); // with stack trace
            }

            return records;
        }
    }
}