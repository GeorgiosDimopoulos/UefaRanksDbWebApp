namespace UefaRankingApplication.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }

        public int Points { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

        public Team()
        {   
            Points = 0;
            Id = 0;
            Name = string.Empty;
            Country = new Country();
        }

        public Team(int id, int points, string name, string country)
        {
            Id = id;
            Points = points;
            Name = name;
            Country = new Country();
        }
    }            
}
