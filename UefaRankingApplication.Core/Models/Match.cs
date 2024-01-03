using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UefaRankingApplication.Data.Models
{
    [Table(name: "Match")]
    public class Match
    {
        [Key]
        [Column(name: "Id")]
        public int Id { get; set; }                        

        [Column(name: "Result")]
        public Result Result { get; set; } // string

        // [ForeignKey]
        // [Column(name: "Team_Id")]
        public int Team_Id { get; set; }

        // [Column(name: "OpponentTeam_Id")]
        // public int OpponentTeam_Id { get; set; }

        //[NotMapped]
        //[NotMapped]
        //public Team MyTeam { get; set; }
        //public Team OpponentTeam { get; set; }

        [NotMapped]
        public List<Team> Teams { get; set; }
    }

    public enum Result
    {
        Win,
        Draw,
        Loss
    }
}