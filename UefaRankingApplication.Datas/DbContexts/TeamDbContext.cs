using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.DataAccess.DbContexts
{
    public class TeamDbContext : DbContext
    {
        public DbSet<Team> TeamsList { get; set; }

        public DbSet<Country> CountriesList { get; set; }

        public TeamDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public TeamDbContext(DbContextOptions<TeamDbContext> options): base(options)
        {
        }

        public bool AddPointsToTeamAndCountry(Team team, int points)
        {
            var country = CountriesList.First(c => c.Name.Equals(team.Country.Name));
            var countryPoints = points / country.TeamsNumber;
            TeamsList.First(t => t.Name.Equals(team.Name)).GroupPoints += points; // RankingPoints 
            CountriesList.First(c => c.Name.Equals(team.Name)).CountryPoints += countryPoints;
            SaveChanges();

            return true;
        }
    }
}