using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.BusinessLogic.Services
{
    public interface ICountriesService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<Team> GetTeams();
        Task<bool> AddTeam(string name);

        Task<bool> UpdateTeamAndCountryPoints(string name, string result);                        
        
        Task<bool> DeleteTeam(string name);
    }
}
