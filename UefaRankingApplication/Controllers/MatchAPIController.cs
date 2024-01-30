using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        
        private readonly ILogger<MatchAPIController> _logger;

        public MatchAPIController(ILogger<MatchAPIController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _db = applicationDbContext;
        }

        [HttpGet("GetMatches")]
        public List<Match> GetMatches()
        {
            _logger.LogInformation("Getting All Matches Info and Results by given name");

            return _db.Matches.ToList();
        }

        [HttpGet("GetMatchesByRound")]
        public Match GetMatchesByRound(string round)
        {
            _logger.LogInformation("Getting Match Info and Results by given name");
            return _db.Matches.First(m => m.Round.Equals(round));
        }

        [HttpGet("GetMatchesByTeam")]
        public IEnumerable<Match> GetMatchesByTeam(string teamName)
        {
            _logger.LogInformation($"Getting all Matches Information by {teamName} cup!");
            var team = _db.Teams.FirstOrDefault(m => m.Name.Equals(teamName));
            return _db.Matches.Where(m => m.Teams.Contains(team));
        }

        [HttpGet("GetMatchesByCountry")]
        public IEnumerable<Match> GetMatchesByCountry(string countryName)
        {            
            _logger.LogInformation("Getting Matches by Country Information");
            return _db.Matches; // .Where(t => t.Country.Name.Equals(countryName)).Select(t => t.Name);            
        }

        [HttpPost("AddNewMatch")]
        public async Task<ActionResult<Match>> AddNewMatch([FromBody] Match match)
        {
            _db.Matches.Add(match);

            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
