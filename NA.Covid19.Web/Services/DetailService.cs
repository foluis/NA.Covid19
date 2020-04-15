using Microsoft.AspNetCore.Components;
using NA.Covid19.Domain.ApiEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NA.Covid19.Web.Services
{
    public class DetailService : IDetailService
    {
        private readonly HttpClient _httpClient;

        public DetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            IEnumerable<Country> result = await _httpClient.GetJsonAsync<Country[]>($"api/Detail/GetCountries");
            return result;
        }
    }
}
