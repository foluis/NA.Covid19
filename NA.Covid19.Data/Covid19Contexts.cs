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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Detail>(eb =>
            //{
            //    eb.Property(b => b.Province_State).HasColumnType("varchar(200)");
            //    eb.Property(b => b.Country_Region).HasColumnType("varchar(200)");
            //    eb.Property(b => b.Latitude).HasColumnType("decimal(5, 2)");
            //    eb.Property(b => b.Longitude).HasColumnType("decimal(5, 2)");
            //});

            modelBuilder.Entity<Detail>()
                .Property(e => e.Province_State).HasColumnType("VARCHAR(200)");//.HasMaxLength(250);
            modelBuilder.Entity<Detail>()
                .Property(e => e.ReportDateName).HasColumnType("VARCHAR(50)");//.HasMaxLength(50);
            modelBuilder.Entity<Detail>()
                .Property(e => e.Latitude).HasColumnType("DECIMAL(12,8)");//.HasMaxLength(50);


            base.OnModelCreating(modelBuilder);
        }
    }
}
