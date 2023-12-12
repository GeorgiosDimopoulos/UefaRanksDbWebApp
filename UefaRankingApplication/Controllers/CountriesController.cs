using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.DataAccess.Models;
using UefaRankingApplication.BusinessLogic.Services;

namespace UefaRankingApplication.UserInterface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ICountriesService _countriesService;

        public CountriesController(ILogger<CountriesController> logger)
        {
            _logger = logger;
            _countriesService = new CountriesService();
        }

        [HttpGet("AllCountriesInfo")]
        public IEnumerable<Country> GetAllCountries()
        {
            _logger.LogInformation("Getting Countries Information");
            return _countriesService.GetCountries(); // .Select(t => t);
        }

        [HttpGet("JustCountriesNames")]
        public IEnumerable<string> GetAllCountriesNames()
        {
            _logger.LogInformation("Getting Countries Names");
            return _countriesService.GetCountries().Select(t => t.Name);
        }

        [HttpGet("GetAllActiveTeams")]
        public IEnumerable<Team> GetAllTeamsNames()
        {
            _logger.LogInformation("Getting all the active playing Teams Information");
            return _countriesService.GetTeams().Where(t => t.IsPlaying); // Select(t => t).
        }                

        [HttpGet("GetTeamsByCup")]
        public IEnumerable<Team> GetTeamsByCup(string cup)
        {
            _logger.LogInformation($"Getting all Teams Information by {cup} cup!");
            return _countriesService.GetTeams().Where(t => t.PlayingCup.Equals(cup));
        }               

        [HttpGet("GetTeamsByCountry")]
        public IEnumerable<string> GetTeamsByCountry(string countryName)
        {
            _logger.LogInformation("Getting Teams by Country Information");
            return _countriesService.GetTeams().Where(t => t.Country.Name.Equals(countryName)).Select(t => t.Name);
        }

        [HttpGet("GetActiveTeamsByCup")]
        public IEnumerable<Team> GetActiveTeamsByCup(string cup)
        {
            _logger.LogInformation("Getting all the active playing Teams Information");
            return _countriesService.GetTeams().Where(t => t.IsPlaying && t.PlayingCup.Equals(cup));
        }

        [HttpGet("CountryInfo")]
        public Country GetCountryInfoByName(string name)
        {
            _logger.LogInformation("Getting Country Info by given name");
            return _countriesService.GetCountries().First(c => c.Name.Equals(name));
        }

        [HttpGet("TeamInfo")]
        public Team GetTeamInfoByName(string name)
        {
            _logger.LogInformation("Getting Team Info and Results by given name");

            // var teamResults = _countriesService.GetTeams().First(t => t.Name.Equals(name)).Results;
            return _countriesService.GetTeams().First(t => t.Name.Equals(name));
        }

        [HttpPost("AddTeam")]
        public async Task<ActionResult<Team>> PostTeam(string teamName)
        {
            if (await _countriesService.AddTeam(teamName))
            {                   
                return CreatedAtAction(nameof(Team), new { Id = 1 }, teamName);
            }     
            
            return BadRequest();
        }

        [HttpPut("AddPointsToTeamAndCountry")]
        public async Task<ActionResult<Team>> AddPointsToTeam(string name, string matchPoints)
        {            
            if (await _countriesService.UpdateTeamAndCountryPoints(name, matchPoints))
            {
                return CreatedAtAction(nameof(Team), new { Id = 1 }, name);
            }

            return BadRequest();
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

        [HttpDelete("Removeteam")]
        public async Task<ActionResult<Team>> DeleteTeam(string teamName)
        {
            if (await _countriesService.DeleteTeam(teamName))
            {
                return CreatedAtAction(nameof(Team), new { Id = 1 }, teamName);
            }            

            return BadRequest();
        }
    }
}
