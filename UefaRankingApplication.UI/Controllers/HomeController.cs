using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;
using UefaRankingApplication.UI.Models;

namespace UefaRankingApplication.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        // private readonly ICountriesService _countriesService;

        public HomeController(ApplicationDbContext applicationDbContext) // ICountriesService countriesService
        {
            _db = applicationDbContext;
            // _countriesService = countriesService;
        }

        public IActionResult Index()
        {
            List<Team> teams = _db.Teams.ToList();
            return View(teams);
        }

        public IActionResult CountriesIndex()
        {
            List<Country> countries = _db.Countries.ToList();
            return View(countries);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
