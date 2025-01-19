﻿// <auto-generated />
using System;
using System.Collections.Generic;
using AEBestGatePath.Data.AstroEmpires.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AEBestGatePath.Data.Migrations.AstroEmpires
{
    [DbContext(typeof(AstroEmpiresContext))]
    partial class AstroEmpiresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AEBestGatePath.Data.AstroEmpires.Entities.Gate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("GuildId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Occupied")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("integer")
                        .HasComputedColumnSql("\"Location_RingPosition\" + \"Location_Ring\" * 10 + \"Location_SystemX\" * 10^2 + \"Location_SystemY\" * 10^3 + \"Location_RegionX\" * 10^4 + \"Location_RegionY\" * 10^5 + \"Location_Galaxy\" * 10^6 + \"Location_Cluster\" * 10^7", true);

                    b.ComplexProperty<Dictionary<string, object>>("Location", "AEBestGatePath.Data.AstroEmpires.Entities.Gate.Location#Location", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Cluster")
                                .HasColumnType("integer");

                            b1.Property<int>("Galaxy")
                                .HasColumnType("integer");

                            b1.Property<int>("GateLevel")
                                .HasColumnType("integer");

                            b1.Property<int>("LogiCommander")
                                .HasColumnType("integer");

                            b1.Property<int>("RegionX")
                                .HasColumnType("integer");

                            b1.Property<int>("RegionY")
                                .HasColumnType("integer");

                            b1.Property<int>("Ring")
                                .HasColumnType("integer");

                            b1.Property<int>("RingPosition")
                                .HasColumnType("integer");

                            b1.Property<char>("Server")
                                .HasColumnType("character(1)");

                            b1.Property<int>("SystemX")
                                .HasColumnType("integer");

                            b1.Property<int>("SystemY")
                                .HasColumnType("integer");
                        });

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Gates");
                });

            modelBuilder.Entity("AEBestGatePath.Data.AstroEmpires.Entities.Guild", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Guilds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b70b6921-9ee7-4cba-914f-c4bc619dc4b2"),
                            GameId = 12530,
                            Name = "actually four guilds",
                            Tag = "QUAD"
                        },
                        new
                        {
                            Id = new Guid("17f9eba5-63bf-4ad0-9415-70b6e482fd7a"),
                            GameId = 6469,
                            Name = "CRUEL",
                            Tag = "CRUEL"
                        });
                });

            modelBuilder.Entity("AEBestGatePath.Data.AstroEmpires.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("GuildId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("AEBestGatePath.Data.AstroEmpires.Entities.Seed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SeedData");
                });

            modelBuilder.Entity("AEBestGatePath.Data.AstroEmpires.Entities.Gate", b =>
                {
                    b.HasOne("AEBestGatePath.Data.AstroEmpires.Entities.Guild", null)
                        .WithMany("Players")
                        .HasForeignKey("GuildId");

                    b.HasOne("AEBestGatePath.Data.AstroEmpires.Entities.Player", "Player")
                        .WithMany("Gates")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("AEBestGatePath.Data.AstroEmpires.Entities.Player", b =>
                {
                    b.HasOne("AEBestGatePath.Data.AstroEmpires.Entities.Guild", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId");

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("AEBestGatePath.Data.AstroEmpires.Entities.Guild", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("AEBestGatePath.Data.AstroEmpires.Entities.Player", b =>
                {
                    b.Navigation("Gates");
                });
#pragma warning restore 612, 618
        }
    }
}
