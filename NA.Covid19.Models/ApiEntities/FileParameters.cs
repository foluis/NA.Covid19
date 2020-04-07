using System;
using System.Collections.Generic;
using System.Text;

namespace NA.Covid19.Domain.ApiEntities
{
    public class FileParameters
    {
        /// <summary>
        /// "03-30-2020.csv"
        /// "dd-MM-yyyy.csv"
        /// </summary>
        public string Date { get; set; }
        public string Url { get; set; }
    }
}
