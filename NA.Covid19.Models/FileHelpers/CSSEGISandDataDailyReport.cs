using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NA.Covid19.Models.FileHelpers
{
    [DelimitedRecord(","), IgnoreFirst(1)]
    [IgnoreEmptyLines()]
    public class CSSEGISandDataDailyReport
    {
        public string FIPS { get; set; }
        public string Admin2 { get; set; }
        public string Province_State { get; set; }

        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForRead)]
        public string Country_Region { get; set; }

        [FieldConverter(ConverterKind.Date, "yyyy-MM-dd HH:mm:ss")]
        public DateTime Last_Update { get; set; }

        //public string Last_Update { get; set; }

        [FieldConverter(ConverterKind.Double, ".")]
        public double Lat { get; set; }
        [FieldConverter(ConverterKind.Double, ".")]
        public double Long_ { get; set; }

        //public string Lat { get; set; }
        //public string Long_ { get; set; }

        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }

        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
        public string Combined_Key { get; set; }
    }
}
