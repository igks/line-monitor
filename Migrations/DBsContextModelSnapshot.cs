﻿// <auto-generated />
using System;
using LineMonitoring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LineMonitoring.Migrations
{
    [DbContext(typeof(DBsContext))]
    partial class DBsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("LineMonitoring.Models.Employee", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BatchId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Line")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProcessName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("LineMonitoring.Models.Graph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Axis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Data1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Data2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Line1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Line2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Graph");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Axis = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec",
                            Data1 = "1,2,3,4,5,6,7,8,9,10,11,12",
                            Data2 = "0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,0.10,0.11,0.12",
                            Line1 = "Label for Data 1",
                            Line2 = "Label for Data 2",
                            Title = "Graph Title"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
