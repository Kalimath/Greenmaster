﻿// <auto-generated />
using System;
using Greenmaster.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Greenmaster.Core.Migrations
{
    [DbContext(typeof(ArboretumContext))]
    [Migration("20240926190626_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GardenStyleMaterialType", b =>
                {
                    b.Property<int>("GardenStylesId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialsId")
                        .HasColumnType("int");

                    b.HasKey("GardenStylesId", "MaterialsId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("GardenStyleMaterialType");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Design.GardenStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AllSeasonInterest")
                        .HasColumnType("bit");

                    b.Property<string>("Colors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concepts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DivideIntoRooms")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PathSize")
                        .HasColumnType("int");

                    b.Property<bool>("RequiresLargeGarden")
                        .HasColumnType("bit");

                    b.Property<string>("Shapes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuitablePlantGenera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GardenStyles");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Design.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaterialTypes");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Measurements.Dimensions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.ObjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objectType_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ObjectTypes");

                    b.HasDiscriminator<string>("objectType_type").HasValue("ObjectType");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Placeables.Placeable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DimensionsId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RenderingId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("placeable_filler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DimensionsId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RenderingId");

                    b.HasIndex("TypeId");

                    b.ToTable("Placeables");

                    b.HasDiscriminator<string>("placeable_filler").HasValue("Placeable");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.Property<double>("Z")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Rendering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Renderings");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Specie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BloomPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommonNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cultivar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cycle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlowerColors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFragrant")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPoisonous")
                        .HasColumnType("bit");

                    b.Property<double>("MaxHeight")
                        .HasColumnType("float");

                    b.Property<double>("MaxWidth")
                        .HasColumnType("float");

                    b.Property<int>("MinimalTemperature")
                        .HasColumnType("int");

                    b.Property<string>("MutualisticGenera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("PollinatingFlowers")
                        .HasColumnType("bit");

                    b.Property<string>("Shape")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sunlight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Water")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlantTypeId");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Placeables.Plant", b =>
                {
                    b.HasBaseType("Greenmaster.Core.Models.Placeables.Placeable");

                    b.Property<int>("SpecieId")
                        .HasColumnType("int");

                    b.HasIndex("SpecieId");

                    b.HasDiscriminator().HasValue("Plant");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Placeables.Structure", b =>
                {
                    b.HasBaseType("Greenmaster.Core.Models.Placeables.Placeable");

                    b.HasDiscriminator().HasValue("Structure");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.PlantType", b =>
                {
                    b.HasBaseType("Greenmaster.Core.Models.ObjectType");

                    b.Property<bool>("AllowAsUndergrowth")
                        .HasColumnType("bit");

                    b.Property<string>("Canopy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PlantType");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.StructureType", b =>
                {
                    b.HasBaseType("Greenmaster.Core.Models.ObjectType");

                    b.HasDiscriminator().HasValue("StructureType");
                });

            modelBuilder.Entity("GardenStyleMaterialType", b =>
                {
                    b.HasOne("Greenmaster.Core.Models.Design.GardenStyle", null)
                        .WithMany()
                        .HasForeignKey("GardenStylesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Greenmaster.Core.Models.Design.MaterialType", null)
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Placeables.Placeable", b =>
                {
                    b.HasOne("Greenmaster.Core.Models.Measurements.Dimensions", "Dimensions")
                        .WithMany()
                        .HasForeignKey("DimensionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Greenmaster.Core.Models.Point", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Greenmaster.Core.Models.Rendering", "Rendering")
                        .WithMany()
                        .HasForeignKey("RenderingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Greenmaster.Core.Models.ObjectType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dimensions");

                    b.Navigation("Location");

                    b.Navigation("Rendering");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Specie", b =>
                {
                    b.HasOne("Greenmaster.Core.Models.PlantType", "PlantType")
                        .WithMany()
                        .HasForeignKey("PlantTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlantType");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Placeables.Plant", b =>
                {
                    b.HasOne("Greenmaster.Core.Models.Specie", "Specie")
                        .WithMany("Plants")
                        .HasForeignKey("SpecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("Greenmaster.Core.Models.Specie", b =>
                {
                    b.Navigation("Plants");
                });
#pragma warning restore 612, 618
        }
    }
}