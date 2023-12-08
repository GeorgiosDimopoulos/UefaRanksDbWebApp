using UefaRankingApplication.Domain.Models;

namespace UefaRankingApplication.Presentation.Services
{
    public interface ICountriesService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<Team> GetTeams();
    }
}
