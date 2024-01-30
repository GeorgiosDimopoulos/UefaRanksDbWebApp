using System.ComponentModel.DataAnnotations.Schema;

namespace UefaRankingApplication.Data.Models
{                            
    [Table(name: "Match")]
    public class Match
    {
        public int Id { get; set; }

        public int Round { get; set; }

        /// To-Do: add Team1 and Team2 for a match, not a list!
        // public Team Team1 { get; set; }
        // public Team Team2 { get; set; }
        // public int Team1Id { get; set; }
        // public int Team2Id { get; set; }
        public List<Team> Teams { get; set; } 
        public string PlayingCup { get; set; }

        public string Result { get; set; }
    }
}
