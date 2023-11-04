﻿// <auto-generated />
using System;
using Infracstructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infracstructures.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231104184341_FixMenuDetailQuantity")]
    partial class FixMenuDetailQuantity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Base.Bird", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BirdImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BirdStatus")
                        .HasColumnType("int");

                    b.Property<int>("CageID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CageID");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Bird");
                });

            modelBuilder.Entity("Domain.Models.Base.Cage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CageStatus")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cage");
                });

            modelBuilder.Entity("Domain.Models.Base.FeedingPlan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BirdID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedingStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MealMenuID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BirdID");

                    b.HasIndex("MealMenuID");

                    b.ToTable("FeedingPlan");
                });

            modelBuilder.Entity("Domain.Models.Base.Food", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NutritionalIngredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SafetyThreshold")
                        .HasColumnType("int");

                    b.Property<double>("StandardPrice")
                        .HasColumnType("float");

                    b.Property<string>("StorageCondition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("Domain.Models.Base.InventoryLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FoodId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FoodId");

                    b.ToTable("InventoryLog");
                });

            modelBuilder.Entity("Domain.Models.Base.Log", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BirdID")
                        .HasColumnType("int");

                    b.Property<int>("CageID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BirdID");

                    b.HasIndex("CageID");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Domain.Models.Base.MealMenu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BirdStatus")
                        .HasColumnType("int");

                    b.Property<int?>("DaysBeforeFeeding")
                        .HasColumnType("int");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuStatus")
                        .HasColumnType("int");

                    b.Property<string>("NutritionalIngredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpeciesID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SpeciesID");

                    b.ToTable("MealMenu");
                });

            modelBuilder.Entity("Domain.Models.Base.MenuDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("MealMenuID")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("FoodID");

                    b.HasIndex("MealMenuID");

                    b.ToTable("MenuDetail");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PurchaseRequestID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.HasIndex("PurchaseRequestID");

                    b.HasIndex("SupplierID");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseOrderDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DeliverDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("NetPrice")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseOrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FoodID");

                    b.HasIndex("PurchaseOrderID");

                    b.ToTable("PurchaseOrderDetail");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.ToTable("PurchaseRequest");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseRequestDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseRequestID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FoodID");

                    b.HasIndex("PurchaseRequestID");

                    b.ToTable("PurchaseRequestDetail");
                });

            modelBuilder.Entity("Domain.Models.Base.Species", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Habitat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LifeExpectancy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("Domain.Models.Base.Supplier", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Domain.Models.Base.Tasks", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BirdID")
                        .HasColumnType("int");

                    b.Property<int?>("CageID")
                        .HasColumnType("int");

                    b.Property<string>("DateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StaffID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BirdID");

                    b.HasIndex("CageID");

                    b.HasIndex("StaffID");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Domain.Models.Base.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirebaseID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Models.Base.Bird", b =>
                {
                    b.HasOne("Domain.Models.Base.Cage", "Cage")
                        .WithMany("Birds")
                        .HasForeignKey("CageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Base.Species", "Species")
                        .WithMany("Birds")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cage");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("Domain.Models.Base.FeedingPlan", b =>
                {
                    b.HasOne("Domain.Models.Base.Bird", "Bird")
                        .WithMany("FeedingPlans")
                        .HasForeignKey("BirdID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Base.MealMenu", "MealMenu")
                        .WithMany("FeedingPlans")
                        .HasForeignKey("MealMenuID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bird");

                    b.Navigation("MealMenu");
                });

            modelBuilder.Entity("Domain.Models.Base.InventoryLog", b =>
                {
                    b.HasOne("Domain.Models.Base.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("Domain.Models.Base.Log", b =>
                {
                    b.HasOne("Domain.Models.Base.Bird", "Bird")
                        .WithMany("Logs")
                        .HasForeignKey("BirdID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Models.Base.Cage", "Cage")
                        .WithMany("Logs")
                        .HasForeignKey("CageID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bird");

                    b.Navigation("Cage");
                });

            modelBuilder.Entity("Domain.Models.Base.MealMenu", b =>
                {
                    b.HasOne("Domain.Models.Base.Species", "Species")
                        .WithMany("MealMenus")
                        .HasForeignKey("SpeciesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Species");
                });

            modelBuilder.Entity("Domain.Models.Base.MenuDetail", b =>
                {
                    b.HasOne("Domain.Models.Base.Food", "Food")
                        .WithMany("MenuDetails")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Base.MealMenu", "MealMenu")
                        .WithMany("MenuDetails")
                        .HasForeignKey("MealMenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("MealMenu");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseOrder", b =>
                {
                    b.HasOne("Domain.Models.Base.User", "Creator")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Base.PurchaseRequest", "PurchaseRequest")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("PurchaseRequestID");

                    b.HasOne("Domain.Models.Base.Supplier", "Supplier")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("SupplierID");

                    b.Navigation("Creator");

                    b.Navigation("PurchaseRequest");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseOrderDetail", b =>
                {
                    b.HasOne("Domain.Models.Base.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Base.PurchaseOrder", "PurchaseOrder")
                        .WithMany("PurchaseOrderDetails")
                        .HasForeignKey("PurchaseOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseRequest", b =>
                {
                    b.HasOne("Domain.Models.Base.User", "Creator")
                        .WithMany("PurchaseRequests")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseRequestDetail", b =>
                {
                    b.HasOne("Domain.Models.Base.Food", "Food")
                        .WithMany("PurchaseRequestDetails")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Base.PurchaseRequest", "PurchaseRequest")
                        .WithMany("PurchaseRequestDetails")
                        .HasForeignKey("PurchaseRequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("PurchaseRequest");
                });

            modelBuilder.Entity("Domain.Models.Base.Tasks", b =>
                {
                    b.HasOne("Domain.Models.Base.Bird", "Bird")
                        .WithMany("Tasks")
                        .HasForeignKey("BirdID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Models.Base.Cage", "Cage")
                        .WithMany("Tasks")
                        .HasForeignKey("CageID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Models.Base.User", "Staff")
                        .WithMany("Tasks")
                        .HasForeignKey("StaffID");

                    b.Navigation("Bird");

                    b.Navigation("Cage");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Domain.Models.Base.Bird", b =>
                {
                    b.Navigation("FeedingPlans");

                    b.Navigation("Logs");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.Models.Base.Cage", b =>
                {
                    b.Navigation("Birds");

                    b.Navigation("Logs");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.Models.Base.Food", b =>
                {
                    b.Navigation("MenuDetails");

                    b.Navigation("PurchaseRequestDetails");
                });

            modelBuilder.Entity("Domain.Models.Base.MealMenu", b =>
                {
                    b.Navigation("FeedingPlans");

                    b.Navigation("MenuDetails");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseOrder", b =>
                {
                    b.Navigation("PurchaseOrderDetails");
                });

            modelBuilder.Entity("Domain.Models.Base.PurchaseRequest", b =>
                {
                    b.Navigation("PurchaseOrders");

                    b.Navigation("PurchaseRequestDetails");
                });

            modelBuilder.Entity("Domain.Models.Base.Species", b =>
                {
                    b.Navigation("Birds");

                    b.Navigation("MealMenus");
                });

            modelBuilder.Entity("Domain.Models.Base.Supplier", b =>
                {
                    b.Navigation("PurchaseOrders");
                });

            modelBuilder.Entity("Domain.Models.Base.User", b =>
                {
                    b.Navigation("PurchaseOrders");

                    b.Navigation("PurchaseRequests");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
