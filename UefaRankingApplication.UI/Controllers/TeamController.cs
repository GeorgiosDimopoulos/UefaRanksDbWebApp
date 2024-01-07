using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger, ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Team> teams = _db.Teams.ToList();
            return View(teams);
        }

        public IActionResult Upsert(int? id)
        {
            Team t = new();            
            if(id == null || id == 0) 
            {                   
                return View(t);
            }

            t = _db.Teams.FirstOrDefault(c => c.Id == id);
            if (t is null)
            {
                return NotFound();
            }

            return View(t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Team team)
        {
            if (ModelState.IsValid)
            {
                if (team.Id == 0)
                {                                          
                    // create action
                    await _db.Teams.AddAsync(team);
                }
                else
                {
                    // update action                    
                    _db.Teams.Update(team);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(team);
        }

        public async Task<IActionResult> Delete(int teamId)
        {
            Team team = new();
            team = _db.Teams.FirstOrDefault(c => c.Id == teamId);

            if (team == null)
            {
                return NotFound();
            }

            _db.Teams.Remove(team);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple() 
        {
            var teams = new List<Team>();
            for (int i = 0; i < 2; i++)
            {
                teams.Add(new Team() 
                {
                    Name = Guid.NewGuid().ToString(),                    
                });

                _db.Teams.AddRange(teams);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveMultiple()
        {
            var teamWithLastId = _db.Teams.OrderByDescending(u => u.Id).Take(1).ToList();
            _db.Teams.RemoveRange(teamWithLastId);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
