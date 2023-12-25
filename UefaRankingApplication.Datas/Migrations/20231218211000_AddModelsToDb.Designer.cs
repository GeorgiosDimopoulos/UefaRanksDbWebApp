﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UefaRankingApplication.DataAccess.DbContexts;

#nullable disable

namespace UefaRankingApplication.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231218211000_AddModelsToDb")]
    partial class AddModelsToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UefaRankingApplication.DataAccess.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActiveTeamsNumber")
                        .HasColumnType("int")
                        .HasColumnName("ActiveTeamsNumber");

                    b.Property<int>("AllTeamsNumber")
                        .HasColumnType("int")
                        .HasColumnName("AllTeamsNumber");

                    b.Property<int>("CountryPoints")
                        .HasColumnType("int")
                        .HasColumnName("CountryPoints");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("RankingPosition")
                        .HasColumnType("int")
                        .HasColumnName("RankingPosition");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("UefaRankingApplication.DataAccess.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupPoints")
                        .HasColumnType("int")
                        .HasColumnName("GroupPoints");

                    b.Property<bool>("IsPlaying")
                        .HasColumnType("bit")
                        .HasColumnName("IsPlaying");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int?>("PlayingCup")
                        .HasColumnType("int");

                    b.Property<int>("RankingPoints")
                        .HasColumnType("int")
                        .HasColumnName("RankingPoints");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("UefaRankingApplication.DataAccess.Models.Team", b =>
                {
                    b.HasOne("UefaRankingApplication.DataAccess.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
