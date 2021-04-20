﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartLocker.WebAPI.Data;

namespace SmartLocker.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.Locker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFull")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lockers");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.RegisterNotes.AccountingRegisterNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsTaken")
                        .HasColumnType("bit");

                    b.Property<Guid>("ToolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ToolId");

                    b.HasIndex("UserId");

                    b.ToTable("AccountingRegister");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.RegisterNotes.QueueRegisterNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ToolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ToolId");

                    b.HasIndex("UserId");

                    b.ToTable("QueueRegister");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.RegisterNotes.ServiceRegisterNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ToolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ToolId");

                    b.HasIndex("UserId");

                    b.ToTable("ServiceRegister");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.RegisterNotes.ViolationRegisterNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LockerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ToolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LockerId");

                    b.HasIndex("ToolId");

                    b.HasIndex("UserId");

                    b.ToTable("ViolationRegister");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.ServiceBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxUsages")
                        .HasColumnType("int");

                    b.Property<long>("MsBetweenServices")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ToolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Usages")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToolId")
                        .IsUnique();

                    b.ToTable("ServiceBooks");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.Tool", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LockerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServiceBookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LockerId");

                    b.HasIndex("UserId");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.RegisterNotes.AccountingRegisterNote", b =>
                {
                    b.HasOne("SmartLocker.WebAPI.Domain.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartLocker.WebAPI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Tool");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.RegisterNotes.QueueRegisterNote", b =>
                {
                    b.HasOne("SmartLocker.WebAPI.Domain.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartLocker.WebAPI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Tool");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.RegisterNotes.ServiceRegisterNote", b =>
                {
                    b.HasOne("SmartLocker.WebAPI.Domain.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartLocker.WebAPI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Tool");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.RegisterNotes.ViolationRegisterNote", b =>
                {
                    b.HasOne("SmartLocker.WebAPI.Domain.Locker", "Locker")
                        .WithMany()
                        .HasForeignKey("LockerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartLocker.WebAPI.Domain.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartLocker.WebAPI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Locker");

                    b.Navigation("Tool");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.ServiceBook", b =>
                {
                    b.HasOne("SmartLocker.WebAPI.Domain.Tool", "Tool")
                        .WithOne("ServiceBook")
                        .HasForeignKey("SmartLocker.WebAPI.Domain.ServiceBook", "ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.Tool", b =>
                {
                    b.HasOne("SmartLocker.WebAPI.Domain.Locker", "Locker")
                        .WithMany("Tools")
                        .HasForeignKey("LockerId");

                    b.HasOne("SmartLocker.WebAPI.Domain.User", "User")
                        .WithMany("Tools")
                        .HasForeignKey("UserId");

                    b.Navigation("Locker");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.Locker", b =>
                {
                    b.Navigation("Tools");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.Tool", b =>
                {
                    b.Navigation("ServiceBook");
                });

            modelBuilder.Entity("SmartLocker.WebAPI.Domain.User", b =>
                {
                    b.Navigation("Tools");
                });
#pragma warning restore 612, 618
        }
    }
}
