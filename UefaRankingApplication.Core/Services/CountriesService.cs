using UefaRankingApplication.DataAccess.DbContexts;
using UefaRankingApplication.DataAccess.Models;
using UefaRankingApplication.DataAccess.SamplesData;

namespace UefaRankingApplication.BusinessLogic.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly TeamDbContext _context;
        private readonly IEnumerable<Country> _countries;
        private readonly IEnumerable<Team> _teams;
        private readonly CountriesSample _countriesSample;

        public CountriesService()
        {
            _countriesSample = new CountriesSample();
            _context = new TeamDbContext();
            _teams = GetSampleTeams();
            _countries = GetSampleCountries();
        }

        public IEnumerable<Country> GetCountries()
        {
            return _countries;
        }

        public IEnumerable<Team> GetTeams()
        {
            return _teams;
        }

        private IEnumerable<Team> GetSampleTeams()
        {
            return _countriesSample.GetSomeTeams();
        }

        private IEnumerable<Country> GetSampleCountries()
        {
            return _countriesSample.GetSomeCountries();
        }
        
        public async Task<bool> AddTeam(string teamName)
        {
            try
            {
                _context.Add(new Team()
                {
                    Name = teamName,
                    Country = GetCountries().First(c => c.Name.Equals(teamName))
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
                var team = GetTeams().FirstOrDefault(t => t.Name.Equals(teamName));
                _context.Remove(team);

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
            var team = GetTeams().First(t => t.Name.Equals(name));
            var country = GetCountries().First(t => t.Name.Equals(team.Country.Name));

            if (team is null || country is null)
            {
                return await Task.FromResult(false);
            }

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

        private async Task UpdateTeamAndCountryPoints(Team team, int points)
        {
            _context.AddPointsToTeamAndCountry(team, points);
            
            // _context.Update(team);
            await _context.SaveChangesAsync();
        }
    }
}
