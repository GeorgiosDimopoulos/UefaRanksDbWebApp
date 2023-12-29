using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace MvcWebExample_Web.Controllers
{
    public class MatchController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<MatchController> _logger;

        public MatchController(ILogger<MatchController> logger, ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Match> matches = _db.Matches.ToList();
            return View(matches);
        }

        public IActionResult Upsert(int? id)
        {
            Match t = new();            
            if(id == null || id == 0) 
            {                   
                return View(t);
            }

            t = _db.Matches.FirstOrDefault(c => c.Id == id);
            if (t is null)
            {
                return NotFound();
            }

            return View(t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Match m)
        {
            if (ModelState.IsValid)
            {
                if (m.Id == 0)
                {                                          
                    // create action
                    await _db.Matches.AddAsync(m);
                }
                else
                {
                    // update action                    
                    _db.Matches.Update(m);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(m);
        }

        public async Task<IActionResult> Delete(int mId)
        {
            Match m = new();
            m = _db.Matches.FirstOrDefault(c => c.Id == mId);

            if (m == null)
            {
                return NotFound();
            }

            _db.Matches.Remove(m);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple() 
        {
            var matches = new List<Match>();
            for (int i = 0; i < 2; i++)
            {
                matches.Add(new Match() 
                {
                     // Guid.NewGuid().ToString(),                    
                });

                _db.Matches.AddRange(matches);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveMultiple()
        {
            var matchWithLastId = _db.Matches.OrderByDescending(u => u.Id).Take(1).ToList();
            _db.Matches.RemoveRange(matchWithLastId);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
