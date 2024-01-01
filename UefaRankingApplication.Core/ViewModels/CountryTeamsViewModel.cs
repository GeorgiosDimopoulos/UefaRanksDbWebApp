using System.Web.Mvc;
using UefaRankingApplication.Data.Models;

namespace UefaRankingApplication.Data.ViewModels
{
    public class CountryTeamsViewModel
    {
        public int Id { get; set; }

        public Country Country { get; set; }

        public Team Team { get; set; }

        public IEnumerable<SelectListItem> TeamsList { get; set; }
    }
}
