using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.DataAccess.DbContexts
{
    public class TeamDbContext : DbContext
    {
        public DbSet<Team> TeamsList { get; set; }
        public TeamDbContext? DbCurContext { get; set; }
        public DbSet<Country> CountriesList { get; set; }
        public string? ConnectionString { get; set; }                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
            var country = CountriesList.First(c => c.Name.Equals(team.Country.Name));
            var countryPoints = points / country.TeamsNumber;
            TeamsList.First(t => t.Name.Equals(team.Name)).GroupPoints += points; 
            CountriesList.First(c => c.Name.Equals(team.Name)).CountryPoints += countryPoints;
            SaveChanges();

            return true;
        }                       
    }
}