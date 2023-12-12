namespace UefaRankingApplication.DataAccess.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RankingPosition { get; set; }

        public int CountryPoints { get; set; }
        public int TeamsNumber { get; set; }

        public Country()
        {
            TeamsNumber = 0;
            RankingPosition = 0;
            CountryPoints = 0;
            Id = 0;
            Name = string.Empty;
        }

        public Country(int id, string name, int rankingPos, int teamsNumber, int countryPoints)
        {            
            Id = id;
            Name = name;
            RankingPosition = rankingPos;
            CountryPoints = countryPoints;
            TeamsNumber = teamsNumber;
        }
    }
}
