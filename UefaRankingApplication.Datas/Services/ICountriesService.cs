using UefaRankingApplication.Data.Models;

namespace UefaRankingApplication.DataAccess.Services
{
    public interface ICountriesService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<Team> GetTeams();
        Task<bool> AddTeam(string name);

        Task<bool> UpdateTeamPoints(string cName, string result);                        
        
        Task<bool> DeleteTeam(string name);

        Task<bool> DeleteCountry(string name);
    }
}
