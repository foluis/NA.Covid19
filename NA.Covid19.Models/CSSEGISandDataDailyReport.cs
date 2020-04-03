using System;
using System.Collections.Generic;
using System.Text;

namespace NA.Covid19.Models
{
    public class CSSEGISandDataDailyReportX
    {        
        public string FIPS { get; set; }
        public string Admin2 { get; set; }
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public string Last_Update { get; set; }
        public string Lat { get; set; }
        public string Long_ { get; set; }
        public string Confirmed { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
        public string Active { get; set; }
        public string Combined_Key { get; set; }

    }
}
