using System;
using System.Collections.Generic;
using System.Text;

namespace NA.Covid19.Domain
{
    public class Detail
    {
        public int Id { get; set; }
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public DateTime Last_Update { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public Download Download { get; set; }
    }
}
