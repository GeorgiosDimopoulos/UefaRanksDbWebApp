using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CountryController(ILogger<CountryController> logger, ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public IActionResult Index()
        {
            List<Country> countries = _db.Countries.ToList();
            return View(countries);
        }
                
        public IActionResult Upsert(int? id)
        {
            Country c = new();
            if (id == null || id == 0)
            {
                return View(c);
            }

            c = _db.Countries.FirstOrDefault(c => c.Id == id);
            if (c is null)
            {
                return NotFound();
            }

            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([FromBody] Country country) // Country country
        {
            if (ModelState.IsValid)
            {
                if (country.Id == 0)
                {
                    await _db.Countries.AddAsync(country);
                }
                else
                {
                    _db.Countries.Update(country);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }

        [Route("{id:int}")]
        [Route("{id:int}")]
        public IActionResult Teams(int? cId)
        {
            Country c = new();
            
            c = _db.Countries.FirstOrDefault(c => c.Id == cId);

            if (c == null)
            {
                return NotFound();
            }
                         
            return View(c.Teams);
        }

        // [Route("{id:int}")]
        public async Task<IActionResult> Delete(int cId)
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

        public IActionResult CreateMultiple() 
        {
            var countries = new List<Country>();
            for (int i = 0; i < 2; i++)
            {
                countries.Add(new Country() 
                {
                    Name = Guid.NewGuid().ToString(),                    
                });

                _db.Countries.AddRange(countries);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveMultiple()
        {
            var cWithLastId = _db.Countries.OrderByDescending(c => c.Id).Take(1).ToList();
            _db.Countries.RemoveRange(cWithLastId);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
