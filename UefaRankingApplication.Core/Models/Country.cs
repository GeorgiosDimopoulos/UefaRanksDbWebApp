using System.ComponentModel.DataAnnotations.Schema;

namespace UefaRankingApplication.Data.Models
{
    [Table(name: "Country")]
    public class Country
    {
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

        // ToDo: add it as new Column to the Database Table accordingly
        public List<Team> Teams { get; set; }

        //public List<CountryTeamMap> CountryTeamsMapList { get; set; }
    }
}
