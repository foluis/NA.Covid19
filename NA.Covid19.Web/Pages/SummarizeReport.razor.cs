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

        public IEnumerable<HistoricalReport> ReportData { get; set; }

        string countries = "Colombia";
        DateTime startDate = new DateTime(2020, 04, 01);

        ChartSeriesType seriesType = ChartSeriesType.Line;

        async Task GetData()
        {
            //ReportData = await _historicalService.GetHistoricalReportByCountry(countries);

            ReportParameters parameters = new ReportParameters
            {
                Countries = countries,
                StartDate = startDate
            };

            ReportData = await _historicalService.GetHistoricalReportByCountriesByDate(parameters);
        }
    }
}
