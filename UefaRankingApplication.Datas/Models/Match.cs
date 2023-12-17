namespace UefaRankingApplication.DataAccess.Models
{
    public class Match
    {           
        public int Id { get; set; }
        public string Team { get; set; }
        public string TeamOpponent { get; set; }
        public string Score { get; set; }

        public Match()
        {
            Team = string.Empty;
            TeamOpponent = string.Empty;
            Score = string.Empty;
        }
    }
}
