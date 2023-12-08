namespace UefaRankingApplication.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }

        public int Points { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Team()
        {   
            Points = 0;
            Id = 0;
            Name = string.Empty;
            Country = string.Empty;
        }

        public Team(int id, int points, string name, string country)
        {
            Id = id;
            Points = points;
            Name = name;
            Country = country;
        }
    }            
}
