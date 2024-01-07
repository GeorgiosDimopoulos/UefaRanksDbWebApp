using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.Web.Controllers
{
    public class CountriesRankingController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CountriesRankingController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public IActionResult Index()
        {
            List<Country> countries = _db.Countries.OrderByDescending(c =>c.CountryPoints).ToList();
            return View(countries);
        }

        public IActionResult Upsert(int? id)
        {                                     
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Country country)
        {
            if (ModelState.IsValid)
            {                           
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }


        public async Task<IActionResult> Delete(int cId) // 
        {
            Country c = new();
            c = _db.Countries.FirstOrDefault(c => c.Id == cId);

            if (c == null)
            {
                return NotFound();
            }

            _db.Countries.Remove(c);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
