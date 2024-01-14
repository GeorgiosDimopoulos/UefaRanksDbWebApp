using AutoFixture;
using Microsoft.Extensions.Logging;
using UefaRankingApplication.API.Controllers;

namespace UefaRankingApplication.UnitTests
{
    public class ControllerTests
    {
        // private readonly CountriesController _countriesController;
        private readonly ILogger<CountryAPIController> _logger;
        private readonly IFixture fixture;

        public ControllerTests(ILogger<CountryAPIController> logger)
        {
            _logger = logger;
            fixture = new Fixture();            
        }

        [Fact]
        public void GetCountriesShouldWork() 
        {
            // Arrange
            // _countriesController = new CountriesController(logger, _countriesServiceMock.Object);
            // var controllerMock = new CountriesController(_logger, _countriesServiceMock.Object);
            // var countriesControllerLoggerMock = Mock.Of<ILogger<CountriesController>>();
            // var controllerMock = new CountriesController(countriesControllerLoggerMock);

            //// Act
            // var resultCountry = controllerMock.GetCountryInfoByName(string.Empty); // await 

            //// Assert
            // Assert.Null(resultCountry); // string.Empty      
        }
    }
}
