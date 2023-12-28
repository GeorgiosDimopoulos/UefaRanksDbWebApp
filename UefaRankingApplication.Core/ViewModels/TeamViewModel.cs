using System.Web.Mvc;
using UefaRankingApplication.Data.Models;

namespace UefaRankingApplication.Data.ViewModels
{
    public class TeamViewModel
    {
        public Team Team { get; set; }

        public IEnumerable<SelectListItem> MatchesList { get; set; }
    }
}
