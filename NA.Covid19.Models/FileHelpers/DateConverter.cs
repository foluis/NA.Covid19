using FileHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NA.Covid19.Domain.FileHelpers
{
    public class DateConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            /*
             03-21-2020 -> NO FIPS y Admin2
             03-22-2020 -> 3/22/20 23:45 SI FIPS y Admin2
             03-27-2020 -> yyyy-MM-dd HH:mm:ss                        
             */

            var date = new DateTime();

            if (from.Length == 19)
            {
                date = DateTime.ParseExact(from, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            else if (from.Length == 13)
            {
                from = "0" + from;                
                date = DateTime.ParseExact(from, "MM/dd/yy HH:mm", CultureInfo.InvariantCulture);
            }
            else if (from.Length == 14)
            {
                date = DateTime.ParseExact(from, "MM/dd/yy HH:mm", CultureInfo.InvariantCulture);
            }

            return date;
        }

        public override string FieldToString(object fieldValue)
        {
            return ((DateTime)fieldValue).ToString("yyyy-MM-dd HH:mm:ss");
        }

    }
}
