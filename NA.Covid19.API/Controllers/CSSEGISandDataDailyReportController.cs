using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FileHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NA.Covid19.Models.FileHelpers;

namespace NA.Covid19.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSSEGISandDataDailyReportController : ControllerBase
    {
        HttpClient client = new HttpClient();

        // GET: api/CSSEGISandDataDailyReport
        [HttpGet]
        public void Get()
        {
            //string uRI = "https://github.com/CSSEGISandData/COVID-19/tree/master/csse_covid_19_data/csse_covid_19_daily_reports/";

            string uRI = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports/";
            uRI += "03-30-2020.csv";

            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OriginalFiles1");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            WebClient webClient = new WebClient();
            webClient.DownloadFile(new Uri(uRI), Path.Combine(path, "OriginalFiles.csv"));

            //return string.Empty;
        }

        // GET: api/Save
        [Route("api/CSSEGISandDataDailyReport/Pailas")]
        [HttpGet]
        public async Task<IEnumerable<string>> Pailas()
        {
            string uRI = "https://github.com/CSSEGISandData/COVID-19/tree/master/csse_covid_19_data/csse_covid_19_daily_reports/";
            uRI += "/03-30-2020.csv";

            WebRequest GetURL = WebRequest.Create(uRI);
            Stream page = GetURL.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(page);

            String csv = sr.ReadToEnd();

            IEnumerable<CSSEGISandDataDailyReport> resultado = new List<CSSEGISandDataDailyReport>();
            var response = await client.GetAsync(uRI);


            if (response.IsSuccessStatusCode)
            {
                using var responseStream0 = await response.Content.ReadAsStreamAsync();

                ///pailas /using var responseStream = await response.Content.ReadAsAsync<TextReader>();
                var engine = new FileHelperEngine<CSSEGISandDataDailyReport>();
                ////var records = engine.ReadStream(responseStream);
                //resultado = engine.ReadStream(responseStream0);

                //var algo = await JsonSerializer.DeserializeAsync<IEnumerable<CSSEGISandDataDailyReport>>(responseStream0);
            }

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OriginalFiles", "OriginalFiles.csv");
            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OriginalFiles1");


            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, uRI))
                {
                    using (
                        Stream contentStream = await(await httpClient.SendAsync(request)).Content.ReadAsStreamAsync(),
                        stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 9876543, true))
                    {
                        await contentStream.CopyToAsync(stream);
                    }
                }
            }


            return new string[] { "value1", "value2" };
        }

        // GET: api/CSSEGISandDataDailyReport/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CSSEGISandDataDailyReport
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CSSEGISandDataDailyReport/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
