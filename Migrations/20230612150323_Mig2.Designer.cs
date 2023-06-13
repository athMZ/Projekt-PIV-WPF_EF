﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_WPF_EF_PraktykiStudenckie.Model;

#nullable disable

namespace Projekt_WPF_EF_PraktykiStudenckie.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230612150323_Mig2")]
    partial class Mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Building")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("Flat")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.Company", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NipNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.Internship", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Responsibilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StudentId");

                    b.ToTable("Internships");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupervisorCompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("SupervisorUniversityId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupervisorCompanyId");

                    b.HasIndex("SupervisorUniversityId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.SupervisorCompany", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanySupervisors");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.SupervisorUniversity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UniversitySupervisors");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.Address", b =>
                {
                    b.HasOne("Projekt_WPF_EF_PraktykiStudenckie.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.Internship", b =>
                {
                    b.HasOne("Projekt_WPF_EF_PraktykiStudenckie.Model.Company", "Company")
                        .WithMany("Internships")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_WPF_EF_PraktykiStudenckie.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.Student", b =>
                {
                    b.HasOne("Projekt_WPF_EF_PraktykiStudenckie.Model.SupervisorCompany", "SupervisorCompany")
                        .WithMany("SupervisedStudents")
                        .HasForeignKey("SupervisorCompanyId");

                    b.HasOne("Projekt_WPF_EF_PraktykiStudenckie.Model.SupervisorUniversity", "SupervisorUniversity")
                        .WithMany("SupervisedStudents")
                        .HasForeignKey("SupervisorUniversityId");

                    b.Navigation("SupervisorCompany");

                    b.Navigation("SupervisorUniversity");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.SupervisorCompany", b =>
                {
                    b.HasOne("Projekt_WPF_EF_PraktykiStudenckie.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.Company", b =>
                {
                    b.Navigation("Internships");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.SupervisorCompany", b =>
                {
                    b.Navigation("SupervisedStudents");
                });

            modelBuilder.Entity("Projekt_WPF_EF_PraktykiStudenckie.Model.SupervisorUniversity", b =>
                {
                    b.Navigation("SupervisedStudents");
                });
#pragma warning restore 612, 618
        }
    }
}