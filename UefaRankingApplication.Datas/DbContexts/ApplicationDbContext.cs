using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.DataAccess.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Country> Matches { get; set; }
        public string? ConnectionString { get; set; }                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Country>().HasKey(c => c.Id);
            modelBuilder.Entity<Country>().Property(c => c.RankingPosition).IsRequired();            
            modelBuilder.Entity<Country>().Property(c => c.AllTeamsNumber).IsRequired();           
            modelBuilder.Entity<Country>().Property(c => c.CountryPoints).IsRequired();
            modelBuilder.Entity<Country>().Property(c => c.Name).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Team>().HasKey(t => t.Id);
            modelBuilder.Entity<Team>().Property(t => t.Name).HasMaxLength(20).IsRequired();

            // modelBuilder.Entity<Match>().Property(m => m.Result).HasConversion<string>();
            modelBuilder.Entity<Match>().HasKey(m => m.Id);
            modelBuilder.Entity<Match>().Property(m => m.Result).IsRequired().HasMaxLength(5);            

            // modelBuilder.Entity<Match>().HasOne(m => m.Team).WithMany(t => t.Matches).HasForeignKey(m => m.Team_Id);            
            modelBuilder.Entity<Team>().HasOne(t => t.Country).WithMany(c => c.Teams).HasForeignKey(t => t.Country_Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            if (!optionsBuilder.IsConfigured)
            {
                // select the type of the Server we want to use, via DbContextOptionsBuilder tool
                // define with options what is the type of database we want via the connection string from the DB                
                var serverName = "(LocalDb)\\MSSQLLocalDB";                
                ConnectionString = $"Server={serverName};Database=CodingUefa;TrustServerCertificate=True;Trusted_Connection=true";                
                optionsBuilder.UseSqlServer(ConnectionString)                                    
                    .LogTo(Console.WriteLine, new [] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);                
            }
        }

        public bool AddPointsToTeamAndCountry(Team team, int points)
        {
            //var country = Countries.First(c => c.Name.Equals(team.Country.Name));
            //var countryPoints = points / country.AllTeamsNumber;
            //Teams.First(t => t.Name.Equals(team.Name)).GroupPoints += points; 
            //Countries.First(c => c.Name.Equals(team.Name)).CountryPoints += countryPoints;
            //SaveChanges();

            return true;
        }                       
    }
}