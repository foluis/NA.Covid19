using System;
using System.Collections.Generic;
using System.Text;

namespace NA.Covid19.Domain.ApiEntities
{
    public class ReportParameters
    {
        public DateTime StartDate { get; set; }
        public string Countries { get; set; }
    }
}
