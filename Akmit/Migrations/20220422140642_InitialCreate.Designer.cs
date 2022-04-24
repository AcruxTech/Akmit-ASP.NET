﻿// <auto-generated />
using Akmit.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Akmit.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220422140642_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21");

            modelBuilder.Entity("Akmit.DataAccess.Models.ClassRto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SecretCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Akmit.DataAccess.Models.DayRto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassRtoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pavilion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClassRtoId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("Akmit.DataAccess.Models.LessonRto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cabinet")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayRtoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Homework")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lesson")
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DayRtoId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Akmit.DataAccess.Models.UserRto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassRtoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClassRtoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Akmit.DataAccess.Models.DayRto", b =>
                {
                    b.HasOne("Akmit.DataAccess.Models.ClassRto", "ClassRto")
                        .WithMany("Days")
                        .HasForeignKey("ClassRtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Akmit.DataAccess.Models.LessonRto", b =>
                {
                    b.HasOne("Akmit.DataAccess.Models.DayRto", "DayRto")
                        .WithMany("Lessons")
                        .HasForeignKey("DayRtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Akmit.DataAccess.Models.UserRto", b =>
                {
                    b.HasOne("Akmit.DataAccess.Models.ClassRto", "ClassRto")
                        .WithMany("Users")
                        .HasForeignKey("ClassRtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
