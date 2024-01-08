using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        
        // private readonly ICountriesService _countriesService;
        private readonly ApplicationDbContext _db;

        public CountriesController(ILogger<CountriesController> logger, ApplicationDbContext applicationDbContext) // ICountriesService countriesService
        {
            _logger = logger;
            _db = applicationDbContext;
        }

        [HttpGet("AllCountriesInfo")]
        public IEnumerable<Country> GetAllCountries()
        {
            _logger.LogInformation("Getting Countries Information");

            // return _countriesService.GetCountries().ToList();
            return _db.Countries.ToList();
        }

        [HttpGet("CountriesNames")]
        public IEnumerable<string> GetAllCountriesNames()
        {
            _logger.LogInformation("Getting Countries Names");

            // return _countriesService.GetCountries().Select(t => t.Name).ToList();
            return _db.Countries.Select(t => t.Name);            
        }

        [HttpGet("CountryInfo")]
        public Country GetCountryInfoByName(string name)
        {
            _logger.LogInformation("Getting Country Info by given name");

            // return _countriesService.GetCountries().First(c => c.Name.Equals(name));
            return _db.Countries.First(c => c.Name.Equals(name));            
        }

        [HttpPost("AddNewCountry")]
        public async Task<ActionResult<Team>> AddNewCountry([FromBody] Country country)
        {
            _db.Countries.Add(country);

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("UpdateCountryInfo")]
        public Country UpdateCountryInfo([FromBody] Country country)
        {
            _logger.LogInformation("Getting Country Info by given info for updating");
            _db.Countries.Update(country);
            _db.SaveChanges();

            // return _countriesService.GetCountries().First(c => c.Name.Equals(name));
            return country;
        }

        [HttpDelete("RemoveCountryById")]
        public async Task<ActionResult<Country>> RemoveCountryById(string id)
        {
            var country = _db.Countries.FirstOrDefault(c => c.Id == int.Parse(id));
            _db.Countries.Remove(country);
            _db.SaveChangesAsync();

            return country;
        }

        [HttpDelete("RemoveCountryByName")]
        public async Task<ActionResult<Country>> RemoveCountryByName(string countryName)
        {
            // await _countriesService.DeleteCountry(countryName)
            var country = _db.Countries.FirstOrDefault(c => c.Name.Equals(countryName));
            _db.Countries.Remove(country);
            _db.SaveChangesAsync();

            return country;            
        }
    }
}
