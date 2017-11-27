﻿// <auto-generated />
using copts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace copts.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("copts.Models.Companys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Bank");

                    b.Property<string>("Country");

                    b.Property<int>("Inn");

                    b.Property<int>("Kpp");

                    b.Property<string>("Name");

                    b.Property<int>("Post");

                    b.Property<string>("Sity");

                    b.HasKey("Id");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("copts.Models.Rules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("copts.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int?>("RolesId");

                    b.Property<int?>("RulesId");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RulesId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("copts.Models.Users", b =>
                {
                    b.HasOne("copts.Models.Companys", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");

                    b.HasOne("copts.Models.Rules", "Rules")
                        .WithMany("Users")
                        .HasForeignKey("RulesId");
                });
#pragma warning restore 612, 618
        }
    }
}