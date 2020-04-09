using System;
using System.Collections.Generic;
using System.Text;

namespace NA.Covid19.Domain
{
    public class HistoricalReport
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
    }
}
