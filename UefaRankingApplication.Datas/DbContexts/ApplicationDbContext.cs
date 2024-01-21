using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UefaRankingApplication.Data.Models;

namespace UefaRankingApplication.DataAccess.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Match> Matches { get; set; }

        public string? ConnectionString { get; set; }

        // ACTIVATE WHEN RUNNING API OR WEB LAYER, NOT ON MIGRATING DB ENTITIES
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder) : base(optionsBuilder)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            OnCountryModelCreating(modelBuilder);
            OnTeamModelCreating(modelBuilder);
            OnMatchModelCreating(modelBuilder);
            OnModelsRulesCreating(modelBuilder);                                    
        }

        private void OnMatchModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasKey(m => m.Id);
            modelBuilder.Entity<Match>().Property(m => m.Team1).IsRequired();
            modelBuilder.Entity<Match>().Property(m => m.Team2).IsRequired();
        }

        private void OnCountryModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(c => c.Id);
            modelBuilder.Entity<Country>().Property(c => c.RankingPosition).IsRequired();
            modelBuilder.Entity<Country>().Property(c => c.AllTeamsNumber).IsRequired();
            modelBuilder.Entity<Country>().Property(c => c.CountryPoints).IsRequired();
            modelBuilder.Entity<Country>().Property(c => c.Name).HasMaxLength(20).IsRequired();
        }

        private void OnTeamModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasKey(t => t.Id);
            modelBuilder.Entity<Team>().Property(t => t.Name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Team>().HasOne(t => t.Country).WithMany(c => c.Teams).HasForeignKey(t => t.Country_Id);
        }

        private void OnModelsRulesCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Match>().HasOne(m => m.Team1).WithMany(t => t.Matches).HasForeignKey(m => m.Team1Id);
            // modelBuilder.Entity<Match>().HasOne(m => m.Team2).WithMany(t => t.Matches).HasForeignKey(m => m.Team2Id);
        }

        // METHOD THAT SHOULD BE USED ONLY FOR MIGRATIONS WITH THE DB CONNECTION
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // select the type of the Server we want to use, via DbContextOptionsBuilder tool and define with options what is the type of database we want via connection string
                ConnectionString = $"Server=(LocalDb)\\MSSQLLocalDB;Database=CodingUefa;TrustServerCertificate=True;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(ConnectionString).LogTo(Console.WriteLine, new [] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
            }
        }
    }
}