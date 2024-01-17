namespace UefaRankingApplication.Data.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public string PlayingCup { get; set; }

        public string Result { get; set; }
    }
}
