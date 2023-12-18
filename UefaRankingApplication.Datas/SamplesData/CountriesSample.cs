using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.DataAccess.SamplesData
{
    public class CountriesSample
    {
        public CountriesSample()
        {                   
            GetSomeCountries();
            GetSomeTeams();
        }

        public List<Team> GetSomeTeams()
        {
            return new List<Team>()            
            {                                      
                new()
                {                
                    // PlayingCup = string.Empty,
                    Id = 2,
                    RankingPoints = 1111,
                    IsPlaying = false,                    
                    Country = new Country()
                    {
                        Name = "Germany"
                    },
                    Name = "VfB",                    
                },
                new()
                {
                    
                    Id = 2,
                    RankingPoints = 1111,
                    GroupPoints = 4,
                    IsPlaying = true,
                    PlayingCup = TeamCup.EuropaLeague,
                    Country = new Country()
                    {
                        Name = "Greece"
                    },
                    Name = "AEK",
                },
            };    
        }

        public IEnumerable<Country> GetSomeCountries()
        {
            return new List<Country>()
            {
                new()
                {
                    Id = 2,
                    Name = "Germany",
                    RankingPosition = 1,
                    ActiveTeamsNumber = 5,
                    AllTeamsNumber = 6,
                    CountryPoints = 23123
                },
                new()
                {
                    Id = 1,
                    Name = "Greece",
                    RankingPosition = 10,
                    ActiveTeamsNumber= 2,
                    AllTeamsNumber = 5,
                    CountryPoints = 12122
                },
            };
        }
    }    
}
