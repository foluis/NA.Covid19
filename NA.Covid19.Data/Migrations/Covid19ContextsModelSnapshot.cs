﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NA.Covid19.Data;

namespace NA.Covid19.Data.Migrations
{
    [DbContext(typeof(Covid19Contexts))]
    partial class Covid19ContextsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<int>("Confirmed")
                        .HasColumnType("int");

                    b.Property<string>("Country_Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int?>("DownloadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Province_State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Recovered")
                        .HasColumnType("int");

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

                    b.HasKey("Id");

                    b.ToTable("Downloads");
                });

            modelBuilder.Entity("NA.Covid19.Domain.Detail", b =>
                {
                    b.HasOne("NA.Covid19.Domain.Download", "Download")
                        .WithMany()
                        .HasForeignKey("DownloadId");
                });
#pragma warning restore 612, 618
        }
    }
}
