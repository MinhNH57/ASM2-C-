﻿// <auto-generated />
using System;
using ASM2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASM2.Migrations
{
    [DbContext(typeof(ASM2Dbcontext))]
    partial class ASM2DbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASM2.Models.HocVien", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaKhoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tuoi")
                        .HasColumnType("int");

                    b.Property<string>("chuyennghanh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("HocViens");

                    b.HasData(
                        new
                        {
                            ID = new Guid("efb065a2-1a52-40db-8cf4-cfa4327c9157"),
                            HoTen = "Nguyen Hong Minh",
                            Tuoi = 20,
                            chuyennghanh = "CNTT"
                        });
                });

            modelBuilder.Entity("ASM2.Models.KhoaHoc", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("namHoc")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("KhoaHocs");

                    b.HasData(
                        new
                        {
                            ID = "SD18401",
                            TenKhoa = "PTPM98",
                            namHoc = 2022
                        });
                });

            modelBuilder.Entity("ASM2.Models.HocVien", b =>
                {
                    b.HasOne("ASM2.Models.KhoaHoc", "Course")
                        .WithMany("HocViens")
                        .HasForeignKey("CourseID");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ASM2.Models.KhoaHoc", b =>
                {
                    b.Navigation("HocViens");
                });
#pragma warning restore 612, 618
        }
    }
}
