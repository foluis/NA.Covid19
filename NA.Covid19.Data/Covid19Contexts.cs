using Microsoft.EntityFrameworkCore;
using NA.Covid19.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NA.Covid19.Data
{
    public class Covid19Contexts : DbContext
    {
        public DbSet<Download> Downloads { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =HPHOME;Initial Catalog=Covid19;Trusted_Connection=True;");;
        }
    }
}
