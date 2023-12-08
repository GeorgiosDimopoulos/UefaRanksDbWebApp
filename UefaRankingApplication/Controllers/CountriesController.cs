using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.Domain.Models;
using UefaRankingApplication.Presentation.Services;

namespace UefaRankingApplication.Presentation.Controllers
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
            // await _context.SaveChangesAsync();
            _logger.LogInformation("Get All Countries Info");
            return countriesService.GetSampleCountries().Select(t => t.Name);
        }

        [HttpGet("Teams")]
        public IEnumerable<string> GetAllTeamsNames()
        {
            // await _context.SaveChangesAsync();
            _logger.LogInformation("Get All Teams Info");
            return countriesService.GetSampleTeams().Select(t => t.Name);
        }

        [HttpGet("CountryInfo")]
        public Country GetCountryInfoByName(string name)
        {
            _logger.LogInformation($"Get {name} Info");
            return countriesService.GetCountries().First(c => c.Name.Equals(name));
        }

        [HttpGet("TeamInfo")]
        public Team GetTeamInfoByName(string name)
        {
            _logger.LogInformation($"Get {name} Info");
            return countriesService.GetSampleTeams().First(t => t.Name.Equals(name));
        }
    }
}
