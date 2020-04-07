using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FileHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NA.Covid19.Data;
using NA.Covid19.Domain;
using NA.Covid19.Domain.ApiEntities;
using NA.Covid19.Models.FileHelpers;

namespace NA.Covid19.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReportController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly DownloadOperations downloadOperations = new DownloadOperations();
        private readonly DetailOperations detailOperations = new DetailOperations();
        private CSSEGISandDataDailyReport[] records = Array.Empty<CSSEGISandDataDailyReport>();

        [HttpPost("[action]")]
        public void RegisterDownload()
        {
            Download download = new Download
            {
                DownloadedDate = new DateTime(2020, 04, 06)
            };
            downloadOperations.InsertDownload(download);
        }

        [HttpGet("[action]")]
        public IEnumerable<Download> GetAllDownloads()
        {
            var result = downloadOperations.GetAllDownloads();
            return result;
        }

        [HttpPost("[action]")]
        public void InsertDetail()
        {
            Detail detail = new Detail
            {
                Province_State = "State",
                Country_Region = "Country",
                Last_Update = new DateTime(2020, 04, 06, 11, 12, 23, 123),
                Latitude = 65.50815459m,
                Longitude = -151.39073869999999m,
                Confirmed = 1,
                Deaths = 2,
                Recovered = 3,
                Active = 4,


            };
            detailOperations.InsertDetail(detail);
        }

        [HttpPost("[action]")]
        public void InsertMultipleDetails()
        {
            List<Detail> details = new List<Detail>()
            {
                new Detail
                {
                    Province_State = "State2",
                    Country_Region = "Country2",
                    Last_Update = new DateTime(2020, 04, 06, 11, 23, 5, 321),
                    Latitude = -81.2546m,
                    Longitude = -6.9118m,
                    Confirmed = 31,
                    Deaths = 22,
                    Recovered = 43,
                    Active = 14
                    
                },
                new Detail
                {
                    Province_State = "State3",
                    Country_Region = "Country3",
                    Last_Update = new DateTime(2020, 04, 06, 11, 23, 42, 321),
                    Latitude = -97.39467635m,
                    Longitude = -149.4068m,
                    Confirmed = 10,
                    Deaths = 10,
                    Recovered = 10,
                    Active = 10
                }
            };
            detailOperations.InsertMultipleDetails(details);
        }

        [HttpGet("[action]")]
        public IEnumerable<Detail> GetAllDetails()
        {
            var result = detailOperations.GetAllDetails();
            return result;
        }

        [HttpPost("[action]")]
        public async Task SaveReportFile([FromBody] FileParameters fileParameters)
        {
            var fileName = fileParameters.Url + fileParameters.Date + ".csv";

            var engine = new FileHelperEngine<CSSEGISandDataDailyReport>();
            try
            {
                using (var result = new StreamReader(await client.GetStreamAsync(fileName)))
                {
                    records = engine.ReadStream(result);
                }

                //downloadOperations.InsertDownload(new Download { DownloadedDate = Convert.ToDateTime(fileParameters.Date) });
                //detailOperations.InsertMultipleDetails(Mapear de CSSEGISandDataDailyReport a Details );

                //Unir estas 2 operaciones en un

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                Console.WriteLine(ex.ToString()); // with stack trace
            }



           
            
        }
    }
}