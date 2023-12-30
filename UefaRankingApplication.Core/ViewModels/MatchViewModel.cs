using System.Web.Mvc;
using UefaRankingApplication.Data.Models;

namespace UefaRankingApplication.Data.ViewModels
{
    public class MatchViewModel
    {
        public Match Match { get; set; }

        public IEnumerable<SelectListItem> TeamsList { get; set; }
    }
}
