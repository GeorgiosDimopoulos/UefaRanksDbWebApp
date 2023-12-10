using Microsoft.Extensions.Logging;
using Moq;
using UefaRankingApplication.BusinessLogic.Services;
using UefaRankingApplication.UserInterface.Controllers;

namespace UefaRankingApplication.UnitTests
{
    public class ServicesUnitTests
    {           
        // private readonly CountriesController _countriesController;
        private readonly ILogger<CountriesController> _logger;
        private readonly ICountriesService _countriesService;
        private readonly Mock<ICountriesService> _countriesServiceMock;

        public ServicesUnitTests(ILogger<CountriesController> logger, ICountriesService countriesService)
        {               
            _logger = logger;
            _countriesService = countriesService;
            _countriesServiceMock = new Mock<ICountriesService>();
            // _countriesController = new CountriesController(logger, _countriesServiceMock.Object);
        }

        [Fact]
        public void GetTeamsShouldLogErrorWhenNoTeams() // async Task 
        {
            // Arrange            

            // var controllerMock = new CountriesController(_logger, _countriesServiceMock.Object);
            var countriesControllerLoggerMock = Mock.Of<ILogger<CountriesController>>();
            var controllerMock = new CountriesController(countriesControllerLoggerMock);

            // Act
            var result = controllerMock.GetCountryInfoByName(string.Empty); // await 

            // Assert
            Assert.Null(result); // string.Empty      
        }       
    }
}