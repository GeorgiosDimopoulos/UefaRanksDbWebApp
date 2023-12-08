using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.Domain.Models;

namespace UefaRankingApplication.Domain.DbContexts
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext()
        {
        }

        public TeamDbContext(DbContextOptions<TeamDbContext> options): base(options)
        {
        }

        public DbSet<Team> TeamsList { get; set; }

        public DbSet<Country> CountriesList { get; set; }
    }
}