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
        [FieldNullValue(typeof(string), "")]
        public string FIPS { get; set; }

        [FieldNullValue(typeof(string), "")]
        public string Admin2 { get; set; }

        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForRead)]
        public string Province_State { get; set; }

        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForRead)]
        public string Country_Region { get; set; }

        [FieldConverter(ConverterKind.Date, "yyyy-MM-dd HH:mm:ss")]
        public DateTime Last_Update { get; set; }        

        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldNullValue(typeof(decimal), "0.0")]
        public decimal Lat { get; set; }

        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldNullValue(typeof(decimal), "0.0")]
        public decimal Long_ { get; set; }

        [FieldNullValue(typeof(int), "0")]
        public int Confirmed { get; set; }

        [FieldNullValue(typeof(int), "0")]
        public int Deaths { get; set; }

        [FieldNullValue(typeof(int), "0")]
        public int Recovered { get; set; }

        [FieldNullValue(typeof(int), "0")]
        public int Active { get; set; }

        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
        public string Combined_Key { get; set; }
    }
}
