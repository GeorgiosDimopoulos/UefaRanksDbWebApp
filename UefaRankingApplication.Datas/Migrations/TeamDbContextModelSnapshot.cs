﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UefaRankingApplication.DataAccess.DbContexts;

#nullable disable

namespace UefaRankingApplication.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class TeamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("UefaRankingApplication.Data.Models.Country", b =>
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

            modelBuilder.Entity("UefaRankingApplication.Data.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PlayingCup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("UefaRankingApplication.Data.Models.Team", b =>
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

                    b.ToTable("Team");
                });

            modelBuilder.Entity("MatchTeam", b =>
                {
                    b.HasOne("UefaRankingApplication.Data.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("MatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UefaRankingApplication.Data.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UefaRankingApplication.Data.Models.Team", b =>
                {
                    b.HasOne("UefaRankingApplication.Data.Models.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("Country_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("UefaRankingApplication.Data.Models.Country", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
