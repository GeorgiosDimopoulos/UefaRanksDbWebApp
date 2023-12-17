using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UefaRankingApplication.DataAccess.Models
{
    [Table(name: "Team")]
    public class Team
    {
        [Key]
        [Column(name: "Id")]
        public int Id { get; set; } // TeamId

        [Column(name: "RankingPoints")]
        public int RankingPoints { get; set; }

        [Column(name: "GroupPoints")]
        public int? GroupPoints { get; set; }

        [Column(name: "Name")]
        public string Name { get; set; }
        
        [Column(name: "IsPlaying")]
        public bool IsPlaying { get; set; }
        
        public TeamCup? PlayingCup { get; set; }

        [ForeignKey("CountryId")] // nameof(CountryId)
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
