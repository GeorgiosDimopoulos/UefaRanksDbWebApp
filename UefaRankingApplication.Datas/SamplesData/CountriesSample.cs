using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Country> GetSomeCountries()
        {
            return new List<Country>()
            {
                new()
                {
                    Id = 2,
                    Name = "Germany",
                    RankingPosition = 1,
                    TeamsNumber = 5,                    
                    CountryPoints = 23123
                },
                new()
                {
                    Id = 1,
                    Name = "Greece",
                    RankingPosition = 10,
                    TeamsNumber = 4,
                    CountryPoints = 12122
                },
            };
        }
    }    
}
