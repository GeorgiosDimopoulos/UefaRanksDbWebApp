using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.DataAccess.Services
{
    public class CountriesService : ICountriesService
    {
        //public IEnumerable<Country>? Countries { get; set; }        
        //public IEnumerable<Team>? Teams { get; set; }

        private readonly ILogger _logger;
        private readonly ApplicationDbContext? _context;

        public CountriesService(ILogger logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _context = applicationDbContext;
            // SetDatabaseContexts();
        }

        private void SetDatabaseContexts()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                if (connection is null)
                {
                    return;
                }

                connection.Open();
                //_context = new TeamDbContext();

                // ToDo: change it to ORM command, instead of SQL query
                // var countries = connection.Query<Country>("SELECT * FROM Country");
                // var teams = connection.Query<Team>("SELECT * FROM Team");
                // var matches  = connection.Query<Team>("SELECT * FROM Match");
                var teams = _context.Teams;
                var countries = _context.Countries;
                
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

                    // _context.Teams.Add(team);
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
            if (_context is null)
            {
                return await Task.FromResult(false);
            }

            _context.Teams.Add(new Team
            {
                Name = teamName,
                // Country = Countries.First(c => c.Name.Equals(teamName))
            });

            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }


        public async Task<bool> DeleteTeam(string teamName)
        {
            if (_context is null || _context.Teams is null)
            {
                return await Task.FromResult(false);
            }

            var team = _context.Teams.First(t => t.Name.Equals(teamName));
            _context.Teams.Remove(team);
            _logger.LogInformation($"Team with name {team.Name} removed from DB");
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCountry(string countryName)
        {
            if (_context is null || _context.Teams is null)
            {
                return await Task.FromResult(false);
            }

            var c = _context.Countries.First(t => t.Name.Equals(countryName));
            _context.Countries.Remove(c);            
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Country with name {countryName} removed from DB");

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateTeamPoints(string name, string resultType)
        {
            if(this._context is null || this._context.Countries is null || this._context.Teams is null)
            {
                return false;
            }

            var team = this._context.Teams.FirstOrDefault(t => t.Name.Equals(name));

            if (team == null)
            {
                _logger.LogInformation($"Team with name {name} not found in DB");
            }

            team.GroupPoints += int.Parse(resultType);

            if (resultType.Equals("win") || int.Parse(resultType) == 3)
            {
                await UpdateCountryPoints(team.Country.Name, "2000");
            }
            else if (resultType.Equals("draw") || int.Parse(resultType) == 1)                              
            {
                await UpdateCountryPoints(team.Country.Name, "1000");
            }

            return await Task.FromResult(true);                            
        }

        public IEnumerable<Country> GetCountries()
        {
            if (_context is not null)
            {
                return _context.Countries;
            }

            return null;
        }

        public IEnumerable<Team> GetTeams()
        {
            if (_context is not null) 
            {
                return _context.Teams;
            }
            
            return null;
        }

        private async Task<bool> UpdateCountryPoints(string countryName, string resultType)
        {              
            var teamCountry = this._context.Countries.First(t => t.Name.Equals(countryName));

            if (teamCountry is null)
            {
                return await Task.FromResult(false);
            }

            var countryPoints = int.Parse(resultType) / teamCountry.Teams.Count();
            _context.Countries.FirstOrDefault(c => c == teamCountry).CountryPoints += countryPoints;

            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
