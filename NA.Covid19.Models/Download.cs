using System;
using System.Collections.Generic;
using System.Text;

namespace NA.Covid19.Domain
{
    public class Download
    {
        public Download()
        {
            Details = new List<Detail>();
        }

        public int Id { get; set; }
        public DateTime DownloadedDate { get; set; }
        public string DownloadedFileName { get; set; }
        public List<Detail> Details { get; set; }
    }
}
