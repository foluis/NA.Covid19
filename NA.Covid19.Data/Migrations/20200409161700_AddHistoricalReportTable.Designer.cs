﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NA.Covid19.Data;

namespace NA.Covid19.Data.Migrations
{
    [DbContext(typeof(Covid19Contexts))]
    [Migration("20200409161700_AddHistoricalReportTable")]
    partial class AddHistoricalReportTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NA.Covid19.Domain.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Active")
                        .HasColumnType("int");

                    b.Property<int?>("Confirmed")
                        .HasColumnType("int");

                    b.Property<string>("Country_Region")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("DownloadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("DECIMAL(12,8)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("DECIMAL(12,8)");

                    b.Property<string>("Province_State")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int?>("Recovered")
                        .HasColumnType("int");

                    b.Property<string>("ReportDateName")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("DownloadId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("NA.Covid19.Domain.Download", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DownloadedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DownloadedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Downloads");
                });

            modelBuilder.Entity("NA.Covid19.Domain.HistoricalReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<int>("Confirmed")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Recovered")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HistoricalReports");
                });

            modelBuilder.Entity("NA.Covid19.Domain.Detail", b =>
                {
                    b.HasOne("NA.Covid19.Domain.Download", "Download")
                        .WithMany("Details")
                        .HasForeignKey("DownloadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
