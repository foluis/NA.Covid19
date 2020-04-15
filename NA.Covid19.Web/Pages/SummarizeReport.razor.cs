using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using NA.Covid19.Domain;
using NA.Covid19.Domain.ApiEntities;
using NA.Covid19.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.Covid19.Web.Pages
{
    public partial class SummarizeReport : ComponentBase
    {
        [Inject]
        public IHistoricalService _historicalService { get; set; }

        [Inject]
        public IDetailService _detailService { get; set; }

        public IEnumerable<HistoricalReport> ReportData { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        IEnumerable<Country> Items;

        DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

        ChartSeriesType seriesType = ChartSeriesType.Line;

        protected override async Task OnInitializedAsync()
        {
            await GetCountries();
        }

        private async Task GetCountries()
        {
            Countries = await _detailService.GetCountries();
        }

        async Task GetData()
        {
            var selectedCountries = string.Join<string>(",", Items.Select(i => i.Name));
            ReportParameters parameters = new ReportParameters
            {
                Countries = selectedCountries,
                StartDate = startDate
            };

            ReportData = await _historicalService.GetHistoricalReportByCountriesByDate(parameters);
        }
    }
}
