namespace UefaRankingApplication.DataAccess.Models
{
    public class Team
    {           
        public int Id { get; set; }
        
        public int RankingPoints { get; set; }

        public int? GroupPoints { get; set; }
                
        public string Name { get; set; }
        
        public bool IsPlaying { get; set; }
        
        public TeamCup? PlayingCup { get; set; }
        
        public Country Country { get; set; }

        public TeamResultType_Char[]? Results { get; set; } // char 

        public Team()
        {   
            RankingPoints = 0;
            Id = 0;
            Name = string.Empty;
            IsPlaying = false;
            Country = new Country();
        }

        public Team(int id, int rankingPoints, int groupPoints, string name, Country country, TeamCup cup, bool isPlaying, TeamResultType_Char[] results)
        {
            Id = id;
            IsPlaying = isPlaying;
            RankingPoints = rankingPoints;
            GroupPoints = groupPoints;
            Name = name;
            PlayingCup = cup;
            Country = country;
            Results = results;
        }
    }

    public enum TeamCup
    {
        ChampionsLeague,
        EuropaLeague,
        ConferenceLeague,
        None
    }

    public enum TeamResultType_Char
    {
        ChampionsLeague,
        EuropaLeague,
        ConferenceLeague,
        None
    }
}
