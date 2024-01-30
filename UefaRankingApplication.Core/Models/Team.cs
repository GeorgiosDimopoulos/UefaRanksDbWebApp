using System.ComponentModel.DataAnnotations.Schema;

namespace UefaRankingApplication.Data.Models
{
    [Table(name: "Team")]
    public class Team
    {
        // [Key]
        [Column(name: "Id")]
        public int Id { get; set; }

        [Column(name: "RankingPoints")]
        public int RankingPoints { get; set; }

        [Column(name: "GroupPoints")]
        public int? GroupPoints { get; set; }

        [Column(name: "Name")]
        public string Name { get; set; }

        [Column(name: "IsPlaying")]
        public bool IsPlaying { get; set; }

        [NotMapped]
        public TeamCup? PlayingCup { get; set; }

        public int Country_Id { get; set; }

        public Country Country { get; set; }       

        public List<Match> Matches { get; set; }

        // [NotMapped]
        // public IEnumerable<SelectListItem>? CountryList { get; set; }
        //public List<CountryTeamMap> CountryTeamsMapList { get; set; }
    }

    public enum TeamCup
    {
        ChampionsLeague,
        EuropaLeague,
        ConferenceLeague,
        None
    }

    public enum ResultRankingPoints
    {
        Win = 2000,
        Draw = 1000,
        Loss = 0,
    }

    //public enum TeamResultType_Char
    //{
    //    None = 0,
    //    ChampionsLeague = 1,
    //    EuropaLeague = 2,
    //    ConferenceLeague = 3        
    //}
}