using Microsoft.AspNetCore.Components;
using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NA.Covid19.Web.Services
{
    public class HistoricalService : IHistoricalService
    {
        private readonly HttpClient _httpClient;

        public HistoricalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<HistoricalReport>> GetHistoricalReportByCountry(string country)
        {
            IEnumerable<HistoricalReport> result = await _httpClient.GetJsonAsync<HistoricalReport[]>($"api/HistoricalReport/GetHistoricalReportByCountry/{country}");
            return result;
        }
    }
}
