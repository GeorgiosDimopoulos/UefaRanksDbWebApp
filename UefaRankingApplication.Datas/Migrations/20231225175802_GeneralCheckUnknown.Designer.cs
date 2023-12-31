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
    [Migration("20231225175802_GeneralCheckUnknown")]
    partial class GeneralCheckUnknown
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MatchTeam", b =>
                {
                    b.Property<int>("MatchesId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.HasKey("MatchesId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("MatchTeam");
                });

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
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Name");

                    b.Property<int>("RankingPosition")
                        .HasColumnType("int")
                        .HasColumnName("RankingPosition");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("UefaRankingApplication.DataAccess.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Result")
                        .HasMaxLength(5)
                        .HasColumnType("int")
                        .HasColumnName("Result");

                    b.Property<int>("Team_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("UefaRankingApplication.DataAccess.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Country_Id")
                        .HasColumnType("int");

                    b.Property<int?>("GroupPoints")
                        .HasColumnType("int")
                        .HasColumnName("GroupPoints");

                    b.Property<bool>("IsPlaying")
                        .HasColumnType("bit")
                        .HasColumnName("IsPlaying");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Name");

                    b.Property<int>("RankingPoints")
                        .HasColumnType("int")
                        .HasColumnName("RankingPoints");

                    b.HasKey("Id");

                    b.HasIndex("Country_Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MatchTeam", b =>
                {
                    b.HasOne("UefaRankingApplication.DataAccess.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("MatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UefaRankingApplication.DataAccess.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UefaRankingApplication.DataAccess.Models.Team", b =>
                {
                    b.HasOne("UefaRankingApplication.DataAccess.Models.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("Country_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("UefaRankingApplication.DataAccess.Models.Country", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
