﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheetHrEmployeeApp.Context;

#nullable disable

namespace TimeSheetHrEmployeeApp.Migrations
{
    [DbContext(typeof(TimeSheetHrEmployeeContext))]
    [Migration("20231129040942_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.Approval", b =>
                {
                    b.Property<int>("ApprovalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApprovalID"), 1L, 1);

                    b.Property<string>("Approvedby")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AprrovedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimesheetID")
                        .HasColumnType("int");

                    b.HasKey("ApprovalID");

                    b.HasIndex("TimesheetID");

                    b.ToTable("Approvals");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.LeaveRequest", b =>
                {
                    b.Property<int>("LeaveRequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveRequestID"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LeaveRequestID");

                    b.HasIndex("Username");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProfileId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.Tasks", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskID"), 1L, 1);

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.TimeSheet", b =>
                {
                    b.Property<int>("TimesheetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimesheetID"), 1L, 1);

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HoursWorked")
                        .HasColumnType("float");

                    b.Property<double>("OverTime")
                        .HasColumnType("float");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TimesheetID");

                    b.HasIndex("Username");

                    b.ToTable("TimeSheets");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.TimeSheetDetails", b =>
                {
                    b.Property<int>("TimesheetdetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimesheetdetailID"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("NoofHours")
                        .HasColumnType("float");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.Property<int>("TimesheetID")
                        .HasColumnType("int");

                    b.HasKey("TimesheetdetailID");

                    b.HasIndex("TaskID");

                    b.HasIndex("TimesheetID");

                    b.ToTable("TimesheetDetails");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Key")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.Approval", b =>
                {
                    b.HasOne("TimeSheetHrEmployeeApp.Models.TimeSheet", "Timesheet")
                        .WithMany()
                        .HasForeignKey("TimesheetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.LeaveRequest", b =>
                {
                    b.HasOne("TimeSheetHrEmployeeApp.Models.User", "User")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.Profile", b =>
                {
                    b.HasOne("TimeSheetHrEmployeeApp.Models.User", "User")
                        .WithOne("Profiles")
                        .HasForeignKey("TimeSheetHrEmployeeApp.Models.Profile", "Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.TimeSheet", b =>
                {
                    b.HasOne("TimeSheetHrEmployeeApp.Models.User", "User")
                        .WithMany("Timesheets")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.TimeSheetDetails", b =>
                {
                    b.HasOne("TimeSheetHrEmployeeApp.Models.Tasks", "Task")
                        .WithMany()
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheetHrEmployeeApp.Models.TimeSheet", "TimeSheet")
                        .WithMany()
                        .HasForeignKey("TimesheetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("TimeSheet");
                });

            modelBuilder.Entity("TimeSheetHrEmployeeApp.Models.User", b =>
                {
                    b.Navigation("LeaveRequests");

                    b.Navigation("Profiles")
                        .IsRequired();

                    b.Navigation("Timesheets");
                });
#pragma warning restore 612, 618
        }
    }
}
