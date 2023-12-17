using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.DataAccess.DbContexts
{
    public class TeamDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
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