using Xunit;

namespace UefaRankingApplication.Tests
{       
    public class ControllerTest
    {
        private CountriesService countriesService;

        [Fact]
        public void AddCountry_ShouldNoReturnsError()
        {
            // var stringCalculator = new StringCalculator();
            // var actual = stringCalculator.Add("0");
            // Assert.Equal(0, actual);
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void AddTeam_ShouldNoReturnsError()
        {         
        }
    }
}
