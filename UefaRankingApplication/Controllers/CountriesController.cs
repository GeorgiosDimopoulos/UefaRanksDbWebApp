using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using UefaRankingApplication.DataAccess.Models;
using UefaRankingApplication.BusinessLogic.Services;

namespace UefaRankingApplication.UserInterface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        // private readonly TeamDbContext _context;
        private readonly ILogger<CountriesController> _logger;
        private CountriesService countriesService;

        public CountriesController(ILogger<CountriesController> logger) // TeamDbContext context
        {
            // _context = context;
            _logger = logger;
            countriesService = new CountriesService();

        }

        [HttpGet("Countries")]
        public IEnumerable<string> GetAllCountries()
        {
            return countriesService.GetSampleCountries().Select(t => t.Name);
        }

        [HttpGet("Teams")]
        public IEnumerable<string> GetAllTeamsNames()
        {
            return countriesService.GetSampleTeams().Select(t => t.Name);
        }

        [HttpGet("CountryInfo")]
        public Country GetCountryInfoByName(string name)
        {
            return countriesService.GetCountries().First(c => c.Name.Equals(name));
        }

        [HttpGet("TeamInfo")]
        public Team GetTeamInfoByName(string name)
        {
            return countriesService.GetSampleTeams().First(t => t.Name.Equals(name));
        }

        [HttpPost("{team}")]
        public async Task<ActionResult<Team>> PostTeam(string teamName)
        {
            if (await countriesService.AddTeam(teamName))
            {                   
                return CreatedAtAction(nameof(Team), new { Id = 1 }, teamName);
            }     
            
            return BadRequest();
        }

        [HttpPut("TeamPoints")]
        public async Task<ActionResult<Team>> AddPointsToTeam(string name, string points)
        {            
            if (await countriesService.UpdateTeam(name, int.Parse(points)))
            {
                return CreatedAtAction(nameof(Team), new { Id = 1 }, name);
            }

            return BadRequest();
        }

        [HttpPut("CountryPoints")]
        public async Task<ActionResult<Team>> AddPointsToCountry(string name, string points)
        {
            if (await countriesService.UpdateCountry(name, int.Parse(points)))
            {
                return CreatedAtAction(nameof(Team), new { Id = 1 }, name);
            }

            return BadRequest();
        }

        [HttpDelete("{team}")]
        public async Task<ActionResult<Team>> DeleteTeam(string teamName)
        {
            if (await countriesService.DeleteTeam(teamName))
            {
                return CreatedAtAction(nameof(Team), new { Id = 1 }, teamName);
            }            

            return BadRequest();
        }
    }
}
