using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.DataAccess.DbContexts
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