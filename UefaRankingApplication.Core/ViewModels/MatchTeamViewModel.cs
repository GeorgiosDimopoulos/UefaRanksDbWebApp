using System.Web.Mvc;
using UefaRankingApplication.Data.Models;

namespace UefaRankingApplication.Data.ViewModels
{
    public class MatchTeamViewModel
    {
        public int Id { get; set; }

        public Team Team { get; set; }

        public IEnumerable<SelectListItem> TeamsList { get; set; }
    }
}
