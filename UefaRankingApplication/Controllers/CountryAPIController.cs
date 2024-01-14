using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;
using UefaRankingApplication.DataAccess.Services;

namespace UefaRankingApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryAPIController : ControllerBase
    {
        private readonly ILogger<CountryAPIController> _logger;
        
        private readonly ICountriesService _countriesService;
        private readonly ApplicationDbContext _db;

        public CountryAPIController(ILogger<CountryAPIController> logger, ApplicationDbContext applicationDbContext, ICountriesService countriesService)
        {
            _logger = logger;
            _db = applicationDbContext;
            _countriesService = countriesService;
        }

        [HttpGet("AllCountriesInfo")]
        public IEnumerable<Country> GetAllCountries()
        {
            _logger.LogInformation("Getting Countries Information");
            
            // _countriesService.GetCountries().ToList();
            return _db.Countries.ToList();
        }

        [HttpGet("CountriesNames")]
        public IEnumerable<string> GetAllCountriesNames()
        {
            _logger.LogInformation("Getting Countries Names");

            // _countriesService.GetCountries().Select(t => t.Name).ToList();
            return _db.Countries.Select(t => t.Name);            
        }

        [HttpGet("CountryInfo")]
        public Country GetCountryInfoByName(string name)
        {
            _logger.LogInformation("Getting Country Info by given name");

            // _countriesService.GetCountries().First(c => c.Name.Equals(name));
            return _db.Countries.First(c => c.Name.Equals(name));            
        }

        [HttpPost("AddNewCountry")]
        public async Task<ActionResult<Team>> AddNewCountry([FromBody] Country country)
        {
            _db.Countries.Add(country);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("UpdateCountryPoints")]
        public Country UpdateCountryPoints(string countryName, string points)
        {
            _logger.LogInformation("Getting Country name for updating its ranking points");
            var updatedCountry = _db.Countries.First(c => c.Name.Equals(countryName));
            updatedCountry.CountryPoints = int.Parse(points);
            _db.Countries.Update(updatedCountry);
            _db.SaveChanges();

            return updatedCountry;
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
            // _countriesService.DeleteCountry(countryName);
            var country = _db.Countries.FirstOrDefault(c => c.Name.Equals(countryName));
            _db.Countries.Remove(country);
            _db.SaveChangesAsync();

            return country;            
        }
    }
}
