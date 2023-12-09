using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.BusinessLogic.Services
{
    public interface ICountriesService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<Team> GetTeams();

        Task<bool> AddTeam(string name);

        Task<bool> UpdateTeam(string name,int num);

        IEnumerable<Country> GetSampleCountries();

        IEnumerable<Team> GetSampleTeams();

        Task<bool> UpdateCountry(string name, int num);

        Task<bool> DeleteTeam(string name);

    }
}
