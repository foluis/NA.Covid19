using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NA.Covid19.Data
{
    public class DetailOperations
    {
        private static Covid19Contexts context = new Covid19Contexts();

        public void InsertDetail(Detail detail)
        {
            context.Details.Add(detail);
            context.SaveChanges();
        }

        public void InsertMultipleDetails(List<Detail> details)
        {
            context.Details.AddRange(details);
            context.SaveChanges();
        }

        public List<Detail> GetAllDetails()
        {
            List<Detail> detail = context.Details.ToList();
            return detail;
        }       
    }
}
