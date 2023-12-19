using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UefaRankingApplication.DataAccess.Models
{
    [Table(name: "Match")]
    public class Match
    {
        [Key]
        [Column(name: "Id")]
        public int Id { get; set; }

        [Column(name: "Team")]
        public Team Team { get; set; }

        [Column(name: "OpponentTeam")]
        public Team OpponentTeam { get; set; }

        [Column(name: "Result")]
        public string Result { get; set; }

        public Match()
        {
            Team = new();
            OpponentTeam = new();
            Result = string.Empty;
        }
    }
}
