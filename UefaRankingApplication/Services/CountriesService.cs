using UefaRankingApplication.Domain.Models;

namespace UefaRankingApplication.Presentation.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly IEnumerable<Country> countries;
        private readonly IEnumerable<Team> teams;

        public CountriesService()
        {
            teams = GetSampleTeams();
            countries = GetSampleCountries();
        }

        public IEnumerable<Country> GetCountries()
        {
            return countries;
        }

        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }

        public IEnumerable<Team> GetSampleTeams()
        {
            return new List<Team>()
            {
                new() 
                {
                     Id = 2,
                    Points = 1111,
                    Country = "Germany",
                    Name = "VfB",
                },
                new()
                {
                    Id = 2,
                    Points = 1111,
                    Country = "Greece",
                    Name = "AEK",                    
                },
            };
        }

        public IEnumerable<Country> GetSampleCountries()
        {
            return new List<Country>()
            {
                new Country()
                {
                    Id = 2,
                    Name = "Germany",                                       
                    RankingPosition = 1,
                    TeamsNumber = 5
                },
                new Country()
                {
                    Id = 1,
                    Name = "Greece",
                    RankingPosition = 10,
                    TeamsNumber = 4
                },
            };
        }
    }
}
