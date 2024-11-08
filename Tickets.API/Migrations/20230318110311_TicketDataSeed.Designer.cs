﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tickets.API.DbContexts;

#nullable disable

namespace Tickets.API.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20230318110311_TicketDataSeed")]
    partial class TicketDataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Tickets.API.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("PointOfInterestId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "a@a.com",
                            Name = "Alex",
                            PointOfInterestId = 4
                        },
                        new
                        {
                            Id = 2,
                            Email = "b@b.com",
                            Name = "Bob",
                            PointOfInterestId = 5
                        },
                        new
                        {
                            Id = 3,
                            Email = "s@s.com",
                            Name = "Sarah",
                            PointOfInterestId = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
