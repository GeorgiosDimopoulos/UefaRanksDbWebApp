using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using UefaRankingApplication.BusinessLogic.Services;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.UnitTests
{
    public class ServicesTests
    {
        private readonly IFixture fixture;

        // private readonly ICountriesService _countriesService;                          
        private readonly Mock<CountriesService> countriesServiceMock;

        public ServicesTests() // ICountriesService countriesService
        {
            // _countriesService = countriesService;            
            var randomCountry = fixture.Create<Country>();
            var randomTeam = fixture.Create<Team>();
            countriesServiceMock = new Mock<CountriesService>();
        }

        [Fact]
        public void GetCountriesShouldLogErrorWhenNoTeams() // async Task 
        {
            // Arrange                                    
            // var countriesService = new CountriesService(Mock.Of<ILogger<CountriesService>>());
            var countryModel = this.fixture.Build<Country>().FromFactory(() => new Country()).Create();
            var countries = new List<Country> 
            {
                countryModel 
            };

            // Act            
            countriesServiceMock.Setup(cs => cs.Countries).Returns(countries);

            // Assert
            countriesServiceMock.Verify();
        }

        [Theory]
        [InlineData("AEK","draw")]
        [InlineData("VfB", "loss")]
        public async Task GetTeamsShouldLogNoError(string name, string teamResult) 
        {
            //Arrange
            var teamModel = this.fixture.Build<Team>().FromFactory(() => new Team()).Create();
            var teams = new List<Team>
            {
                teamModel
            };
            countriesServiceMock.Setup(cs=> cs.Teams).Returns(teams);

            var countriesService = new CountriesService(Mock.Of<ILogger<CountriesService>>());

            // ACT
            var result = await countriesService.UpdateTeamAndCountryPoints(name, teamResult);

            // ASSERT
            Assert.Equal(result, true);
        }
    }
}