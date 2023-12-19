using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.DataAccess.DbContexts
{
    public class TeamDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Country> Matches { get; set; }
        public string? ConnectionString { get; set; }                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Country>().ToTable("Country"); // , "ref"
            modelBuilder.Entity<Team>().ToTable("Team");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // select the type of the Server we want to use, via DbContextOptionsBuilder tool
                // define with options what is the type of database we want via the connection string from the DB                
                var serverName = "(LocalDb)\\MSSQLLocalDB";
                ConnectionString = $"Server={serverName};Database=CodingUefa;TrustServerCertificate=True;Trusted_Connection=true";                
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public bool AddPointsToTeamAndCountry(Team team, int points)
        {
            var country = Countries.First(c => c.Name.Equals(team.Country.Name));
            var countryPoints = points / country.AllTeamsNumber;
            Teams.First(t => t.Name.Equals(team.Name)).GroupPoints += points; 
            Countries.First(c => c.Name.Equals(team.Name)).CountryPoints += countryPoints;
            SaveChanges();

            return true;
        }                       
    }
}