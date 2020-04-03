using FileHelpers;
using NA.Covid19.Models;
using NA.Covid19.Models.FileHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NA.Covid19.CodeProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetFile();


            //Console.ReadLine();
        }

        private static void GetFile()
        {
            //string uRI = "https://github.com/CSSEGISandData/COVID-19/tree/master/csse_covid_19_data/csse_covid_19_daily_reports/";
            string uRI = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports/";
            uRI += "03-30-2020.csv";

            List<string> splitted = new List<string>();
            //string fileList = GetCSV(uRI);

            var result = GetRecords(uRI);
            //GetRecords2(uRI);

        }

        private static string GetCSV(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }

        private static IEnumerable<CSSEGISandDataDailyReport> GetRecords(string url)
        {
            CSSEGISandDataDailyReport[] records = { };
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                StreamReader sr = new StreamReader(resp.GetResponseStream());
                using var stream = new StringReader(sr.ReadToEnd());

                var engine = new FileHelperEngine<CSSEGISandDataDailyReport>();

                //engine.BeforeReadRecord += (sender, args) =>
                //    args.RecordLine = args.RecordLine.Replace(@",", "-");

                engine.BeforeReadRecord += Engine_BeforeReadRecord;

                //engine.AfterReadRecord += Engine_AfterReadRecord;
                records = engine.ReadStream(stream);
                //var records = engine.ReadStreamAsList(stream, 0);

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // with stack trace
            }
            return records;
        }

        private static void Engine_BeforeReadRecord(EngineBase engine, FileHelpers.Events.BeforeReadEventArgs<CSSEGISandDataDailyReport> e)
        {
            //var algo = ((CSSEGISandDataDailyReport)e.Record).Country_Region;
            //if (algo != null)
            //{
            //    string hola = "adios";
            //}           
        }

        public class CustomDateTimeConverter : ConverterBase
        {
            private const string DateTimeFormat = "yyyyMMdd HH:mm:ss";

            public override object StringToField(string from)
            {
                return DateTime.ParseExact(from, DateTimeFormat, CultureInfo.InvariantCulture);
            }
        }

        private static void GetRecords2(string url)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OriginalFiles");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            WebClient webClient = new WebClient();
            webClient.DownloadFile(new Uri(url), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OriginalFiles", "OriginalFiles.csv"));

            //("~/Templates/template.cfg");
            //webClient.DownloadFile("url", Server.MapPath("~/Templates/OriginalFiles.csv"));

        }

        private static async Task<IEnumerable<CSSEGISandDataDailyReport>> GetRecords3(string url)
        {
            string readStream = string.Empty;
            HttpClient client = new HttpClient();

            IEnumerable<CSSEGISandDataDailyReport> resultado = new List<CSSEGISandDataDailyReport>();

            try
            {
                var response = await client.GetAsync(url);
                using var responseStream = await response.Content.ReadAsAsync<TextReader>();
                //var responseStream = await response.Content.ReadAsStringAsync();

                //System.IO.Stream -> System.IO.TextReader
                //string -> System.IO.TextReader

                //return responseStream;

                //var engine = new FileHelperEngine<CSSEGISandDataDailyReport>();
                //var records = engine.ReadStringAsList(readStream);

                var engine = new FileHelperEngine<CSSEGISandDataDailyReport>();
                //var records = engine.ReadStream(responseStream);
                resultado = engine.ReadStream(responseStream);
            }
            catch (Exception ex)
            {
                string messareError = ex.ToString();
            }
            return resultado;
        }
    }
}
