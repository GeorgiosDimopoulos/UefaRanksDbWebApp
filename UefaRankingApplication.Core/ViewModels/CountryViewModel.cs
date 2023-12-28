using System.Web.Mvc;
using UefaRankingApplication.Data.Models;

namespace UefaRankingApplication.Data.ViewModels
{
    public class CountryViewModel
    {
        public Country Country { get; set; }

        public IEnumerable<SelectListItem> TeamsList { get; set; }
    }
}
