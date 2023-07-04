﻿// <auto-generated />
using System;
using GrainTWdata.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrainTWdata.Migrations
{
    [DbContext(typeof(GrainTwContext))]
    [Migration("20230702194648_createNew1")]
    partial class createNew1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrainTWdata.DB.TblGrainReceipt", b =>
                {
                    b.Property<int>("SysId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SysID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SysId"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.Property<int?>("CounterpartyId")
                        .HasColumnType("int");

                    b.Property<string>("CounterpartyName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CropYear")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Garbage")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Infection")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Process")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Product")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime");

                    b.Property<double?>("Wetness")
                        .HasColumnType("float");

                    b.HasKey("SysId");

                    b.ToTable("TblGrainReceipts");
                });

            modelBuilder.Entity("GrainTWdata.DB.TblGrainReceiptMerged", b =>
                {
                    b.Property<int>("SysId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SysId"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.Property<int?>("CounterpartyId")
                        .HasColumnType("int");

                    b.Property<string>("CounterpartyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CropYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Garbage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Infection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Process")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Wetness")
                        .HasColumnType("real");

                    b.HasKey("SysId");

                    b.ToTable("TblGrainReceiptMerged");
                });
#pragma warning restore 612, 618
        }
    }
}
