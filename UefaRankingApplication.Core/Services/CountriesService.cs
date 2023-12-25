using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using UefaRankingApplication.DataAccess.DbContexts;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.BusinessLogic.Services
{
    public class CountriesService : ICountriesService
    {           
        public IEnumerable<Country>? Countries { get; set; }        
        public IEnumerable<Team>? Teams { get; set; }

        private ILogger _logger;
        private ApplicationDbContext? _context;

        public CountriesService(ILogger logger)
        {
            _logger = logger;
            SetDatabaseContexts();
        }

        private void SetDatabaseContexts()
        {
            _context = new ApplicationDbContext();
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                if (connection is null)
                {
                    return;
                }

                connection.Open();                
                
                //_context = new TeamDbContext();
                var t = _context.Teams;

                // ToDo: change it to ORM command, instead of SQL query
                var countries = connection.Query<Country>("SELECT * FROM Country");
                var teams = connection.Query<Team>("SELECT * FROM Team");
                var matches  = connection.Query<Team>("SELECT * FROM Match");

                if (teams is null || countries is null)
                {
                    _logger.LogInformation("No teams or countries available in DB");
                    return;
                }                                               

                foreach (var team in teams)
                {
                    if (team.Id is 0)
                    {
                        _logger.LogInformation("No null primary key in team is valid");
                        return;
                    }

                    _context.Teams.Add(team);
                }

                foreach (var match in matches)
                {
                    if (match.Id is 0)
                    {
                        _logger.LogInformation("No null primary key in match is valid");
                        return;
                    }

                    _context.Teams.Add(match);
                }

                foreach (var country in countries)
                {
                    if (country.Id is 0)
                    {
                        _logger.LogInformation("No null primary key in country is valid");
                        return;
                    }
                    _context.Countries.Add(country);
               }

                // _context.Update(_context.Teams);
                // _context.Update(_context.Matches);
                // _context.Update(_context.Countries);                             
                _context.SaveChanges();
            }            
        }

        public async Task<bool> AddTeam(string teamName)
        {
            try
            {
                if(Countries is null) 
                {
                    return false;
                }

                _context.Add(new Team
                {
                    Name = teamName,
                    // Country = Countries.First(c => c.Name.Equals(teamName))
                });

                await _context.SaveChangesAsync();
                return await Task.FromResult(true);

            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }


        public async Task<bool> DeleteTeam(string teamName)
        {
            try
            {
                var team = Teams?.First(t => t.Name.Equals(teamName));
                _context.Remove(team);
                _logger.LogInformation($"Team with name {team.Name} removed from DB");
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);

            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateTeamAndCountryPoints(string name, string resultType)
        {
            if(Teams is null || Countries is null) 
            {
                return false;
            }

            var team = Teams.First(t => t.Name.Equals(name));
            // var country = Countries.First(t => t.Name.Equals(team.Country.Name));

            //if (team is null || country is null)
            //{
            //    return await Task.FromResult(false);
            //}

            if (resultType.Equals("win") || int.Parse(resultType) == 3)
            {
                await UpdateTeamAndCountryPoints(team, 2000);
            }
            else if (resultType.Equals("draw") || int.Parse(resultType) == 1)                              
            {
                await UpdateTeamAndCountryPoints(team, 1000);
            }

            return await Task.FromResult(true);                            
        }

        public IEnumerable<Country>? GetCountries()
        {
            return this.Countries ?? null;
        }

        public IEnumerable<Team>? GetTeams()
        {
            return this.Teams ?? null;
        }

        private async Task UpdateTeamAndCountryPoints(Team team, int points)
        {
            _context.AddPointsToTeamAndCountry(team, points);            
            _context.Update(team);
            await _context.SaveChangesAsync();
        }        
    }
}
