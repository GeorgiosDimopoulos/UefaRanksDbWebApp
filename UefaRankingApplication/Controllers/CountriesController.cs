using Microsoft.AspNetCore.Mvc;
using UefaRankingApplication.Data.Models;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.Swagger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        
        // private readonly CountriesService _countriesService;
        private readonly ApplicationDbContext _db;

        public CountriesController(ILogger<CountriesController> logger, ApplicationDbContext applicationDbContext) // CountriesService countriesService
        {
            _logger = logger;
            _db = applicationDbContext;
            
            // _countriesService = countriesService;
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

        // [HttpPut("UpdateCountryInfo")]
        // public Country UpdateCountryInfo(string name)
        // {
        //    _logger.LogInformation("Getting Country Info by given name for updating");

        //    return _countriesService.GetCountries().First(c => c.Name.Equals(name));
        // }

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
