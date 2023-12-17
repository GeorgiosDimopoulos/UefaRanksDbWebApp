using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UefaRankingApplication.DataAccess.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Column(name: "Name")]
        public string Name { get; set; }
        
        [Column(name: "RankingPosition")]
        public int RankingPosition { get; set; }

        [Column(name: "CountryPoints")]
        public int CountryPoints { get; set; }
        
        [Column(name: "ActiveTeamsNumber")]
        public int ActiveTeamsNumber { get; set; }

        [Column(name: "AllTeamsNumber")]
        public int AllTeamsNumber { get; set; }

        public Country()
        {
            ActiveTeamsNumber = 0;
            AllTeamsNumber = 0;
            RankingPosition = 0;
            CountryPoints = 0;
            Id = 0;
            Name = string.Empty;
        }
    }
}
