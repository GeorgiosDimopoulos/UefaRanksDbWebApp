using System.ComponentModel.DataAnnotations.Schema;

namespace UefaRankingApplication.DataAccess.Models
{
    [Table(name: "Team")]
    public class Team
    {
        [Column(name: "Id")]
        public int Id { get; set; }

        [Column(name: "RankingPoints")]
        public int RankingPoints { get; set; }

        [Column(name: "GroupPoints")]
        public int? GroupPoints { get; set; }

        [Column(name: "TeamName")]
        public string Name { get; set; }
        
        public bool IsPlaying { get; set; }
        
        public TeamCup? PlayingCup { get; set; }
        
        public Country Country { get; set; }

        // public char[]? Results { get; set; } // TeamResultType_Char
        public Team()
        {   
            RankingPoints = 0;
            Id = 0;
            Name = string.Empty;
            IsPlaying = false;
            Country = new Country();
        }

        public Team(int id, int rankingPoints, int groupPoints, string name, Country country, TeamCup cup, bool isPlaying) // char[] results
        {
            Id = id;
            IsPlaying = isPlaying;
            RankingPoints = rankingPoints;
            GroupPoints = groupPoints;
            Name = name;
            PlayingCup = cup;
            Country = country;
            
            // Results = results;
        }
    }

    public enum TeamCup
    {
        ChampionsLeague,
        EuropaLeague,
        ConferenceLeague,
        None
    }

    //public enum TeamResultType_Char
    //{
    //    None = 0,
    //    ChampionsLeague = 1,
    //    EuropaLeague = 2,
    //    ConferenceLeague = 3        
    //}
}
