using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        
        // private readonly ICountriesService _countriesService;
        private readonly ILogger<TeamAPIController> _logger;

        public TeamAPIController(ILogger<TeamAPIController> logger, ApplicationDbContext applicationDbContext) // , CountriesService countriesService
        {
            _logger = logger;
            _db = applicationDbContext;
            
            // _countriesService = countriesService;
        }

        [HttpGet("GetAllTeams")]
        public List<Team> GetTeamInfoByName()
        {
            _logger.LogInformation("Getting Team Info and Results by given name");
            // return _countriesService.GetTeams().First(t => t.Name.Equals(name));

            return _db.Teams.ToList();
        }

        [HttpGet("GetATeamInfo")]
        public Team GetTeamInfoByName(string name)
        {
            _logger.LogInformation("Getting Team Info and Results by given name");

            // return _countriesService.GetTeams().First(t => t.Name.Equals(name));
            return _db.Teams.First(t => t.Name.Equals(name));
        }

        [HttpGet("GetAllActiveTeams")]
        public IEnumerable<Team> GetAllTeamsNames()
        {
            _logger.LogInformation("Getting all the active playing Teams Information");

            // return _countriesService.GetTeams().Where(t => t.IsPlaying).ToList();
            return _db.Teams.Where(t => t.IsPlaying);            
        }

        [HttpGet("GetTeamsByCup")]
        public IEnumerable<Team> GetTeamsByCup(string cup)
        {
            _logger.LogInformation($"Getting all Teams Information by {cup} cup!");

            // return _countriesService.GetTeams().Where(t => t.PlayingCup.Equals(cup)).ToList();
            return _db.Teams.Where(t => t.PlayingCup.Equals(cup));            
        }

        [HttpGet("GetTeamsByCountry")]
        public IEnumerable<string> GetTeamsByCountry(string countryName)
        {            
            _logger.LogInformation("Getting Teams by Country Information");

            // return _countriesService.GetTeams().Where(t => t.Country.Name.Equals(countryName)).Select(t => t.Name).ToList();
            return _db.Teams.Where(t => t.Country.Name.Equals(countryName)).Select(t => t.Name);            
        }

        [HttpGet("GetActiveTeamsByCup")]
        public IEnumerable<Team> GetActiveTeamsByCup(string cup)
        {
            _logger.LogInformation("Getting all the active playing Teams Information");

            // return _countriesService.GetTeams().Where(t => t.IsPlaying && t.PlayingCup.Equals(cup)).ToList();
            return _db.Teams.Where(t => t.IsPlaying && t.PlayingCup.Equals(cup));
        }

        [HttpPost("AddNewTeam")]
        public async Task<ActionResult<Team>> AddNewTeam([FromBody] Team team) // string teamName, string country
        {
            //_db.Teams.Add(new Team()
            //{
            //    Name = teamName,
            //    Country = _db.Countries.First(c => c.Name.Equals(country)),
            //    GroupPoints = 0                
            //});
            _db.Teams.Add(team);

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("AddPointsToExistingTeam")]
        public async Task<ActionResult<Team>> UpdateTeam([FromBody] Team team)
        {
            // _db.Teams.FirstOrDefault(t => t.Name.Equals(name)).GroupPoints += int.Parse(matchPoints);            
            _db.Teams.Update(team);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Team), new { Id = 1 }, team.Name);

            // if (await _countriesService.UpdateTeamPoints(name, matchPoints))
            // {
            //    return CreatedAtAction(nameof(Team), new { Id = 1 }, name);
            // }            
            // return BadRequest();            
        }

        //[HttpPut("FixPointsOfResultToTeamAndCountry")]
        //public async Task<ActionResult<Team>> FixPointsOfResult(string name, string match, string newMatchPoints)
        //{
        //    if (await _countriesService.UpdateTeamAndCountryPoints(name, match, newMatchPoints))
        //    {
        //        return CreatedAtAction(nameof(Team), new { Id = 1 }, name);
        //    }

        //    return BadRequest();
        //}

        [HttpDelete("RemoveExistingTeam")]
        public async Task<ActionResult<Team>> DeleteTeam(string teamName)
        {
            var curTeam = _db.Teams.FirstOrDefault(t => t.Name.Equals(teamName));
            if (curTeam is null)
            {
                _logger.LogInformation("Team wigh given name not found!");
                return CreatedAtAction(nameof(Team), new { Id = 1 }, teamName);
            }

            _db.Teams.Remove(curTeam);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Team), new { Id = 1 }, teamName);            
        }        
    }
}
