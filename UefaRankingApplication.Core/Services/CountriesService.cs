using UefaRankingApplication.DataAccess.DbContexts;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.BusinessLogic.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly TeamDbContext _context;
        private readonly IEnumerable<Country> _countries;
        private readonly IEnumerable<Team> _teams;

        public CountriesService()
        {
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

        public IEnumerable<Team> GetSampleTeams()
        {
            return new List<Team>()
            {
                new() 
                {
                     Id = 2,
                    Points = 1111,
                    Country = new Country()
                    {
                        Name = "Germany"
                    },
                    Name = "VfB",
                },
                new()
                {
                    Id = 2,
                    Points = 1111,
                    Country = new Country()
                    {
                        Name = "Greece"
                    },
                    Name = "AEK",                    
                },
            };
        }

        public IEnumerable<Country> GetSampleCountries()
        {
            return new List<Country>()
            {
                new()
                {
                    Id = 2,
                    Name = "Germany",                                       
                    RankingPosition = 1,
                    TeamsNumber = 5
                },
                new()
                {
                    Id = 1,
                    Name = "Greece",
                    RankingPosition = 10,
                    TeamsNumber = 4
                },
            };
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

        public async Task<bool> UpdateTeam(string name, int resultType)
        {
            try
            {
                // team.Points += int.Parse(points);
                var team = GetTeams().First(t => t.Name.Equals(name));                
                switch (resultType)
                {
                    case 1: // win: 2000 points
                        break;
                    case 2: // draw: 1000 points
                        break;                    
                    default: // loss: 0 points
                        break;
                }
                
                _context.Update(team);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCountry(string name, int res)
        {
            try
            {
                // team.Points += int.Parse(points);
                var country = GetCountries().First(t => t.Name.Equals(name));
                switch (res)
                {
                    case 1: // win: 2000 points
                        break;
                    case 2: // draw: 1000 points
                        break;
                    default: // loss: 0 points
                        break;
                }

                _context.Update(country);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
