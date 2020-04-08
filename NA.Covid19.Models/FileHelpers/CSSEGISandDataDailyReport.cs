using FileHelpers;
using NA.Covid19.Domain.FileHelpers;
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

        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Admin2 { get; set; }

        [FieldOptional]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForRead)]
        [FieldNullValue(typeof(string), "")]
        public string Province_State { get; set; }

        [FieldOptional]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForRead)]
        [FieldNullValue(typeof(string), "")]
        public string Country_Region { get; set; }

        [FieldOptional]
        //[FieldConverter(ConverterKind.Date, "yyyy-MM-dd HH:mm:ss")]
        [FieldConverter(typeof(DateConverter))]
        [FieldNullValue(typeof(DateTime), "1900-01-01 00:00:00")]
        public DateTime Last_Update { get; set; }

        [FieldOptional]
        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldNullValue(typeof(decimal), "0.0")]
        public decimal Lat { get; set; }

        [FieldOptional]
        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldNullValue(typeof(decimal), "0.0")]
        public decimal Long_ { get; set; }

        [FieldOptional]
        [FieldNullValue(typeof(int), "0")]
        public int Confirmed { get; set; }

        [FieldOptional]
        [FieldNullValue(typeof(int), "0")]
        public int Deaths { get; set; }

        [FieldOptional]
        [FieldNullValue(typeof(int), "0")]
        public int Recovered { get; set; }

        [FieldOptional]
        [FieldNullValue(typeof(int), "0")]
        public int Active { get; set; }

        [FieldOptional]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
        public string Combined_Key { get; set; }
    }
}
