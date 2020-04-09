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
        public DbSet<HistoricalReport> HistoricalReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =HPHOME;Initial Catalog=Covid19;Trusted_Connection=True;"); ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detail>()
                .Property(e => e.Province_State).HasColumnType("VARCHAR(200)");
            modelBuilder.Entity<Detail>()
                .Property(e => e.Country_Region).HasColumnType("VARCHAR(100)");
            modelBuilder.Entity<Detail>()
                .Property(e => e.ReportDateName).HasColumnType("VARCHAR(50)");
            modelBuilder.Entity<Detail>()
                .Property(e => e.Latitude).HasColumnType("DECIMAL(12,8)");
            modelBuilder.Entity<Detail>()
                .Property(e => e.Longitude).HasColumnType("DECIMAL(12,8)");

            modelBuilder.Entity<HistoricalReport>()
               .Property(e => e.Country).HasColumnType("VARCHAR(100)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
