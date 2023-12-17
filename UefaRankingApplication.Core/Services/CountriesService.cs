﻿using Dapper;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using UefaRankingApplication.DataAccess.DbContexts;
using UefaRankingApplication.DataAccess.Models;

namespace UefaRankingApplication.BusinessLogic.Services
{
    public class CountriesService : ICountriesService
    {           
        public IEnumerable<Country>? Countries { get; set; }        
        public IEnumerable<Team>? Teams { get; set; }

        private ILogger _logger;
        private TeamDbContext? _context;

        public CountriesService(ILogger logger)
        {
            _logger = logger;
            SetDatabaseContexts();            
        }               

        private void SetDatabaseContexts()
        {
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\georg\\OneDrive\\Έγγραφα\\UefaDatabase.mdf;Integrated Security=True;Connect Timeout=30";
            using (var connection = new SqlConnection(connectionString))
            {
                if (connection is null)
                {
                    return;
                }

                connection.Open();                
                _context = new TeamDbContext();
                _context.ConnectionString = connectionString;                

                var countries = connection.Query<Country>("SELECT * FROM Country");
                var teams = connection.Query<Team>("SELECT * FROM Team");

                if (teams is null || countries is null)
                {
                    _logger.LogInformation("No teams or countries available in DB");
                    return;
                }                                               

                foreach (var team in teams)
                {
                    if (team.Id is 0)
                    {
                        _logger.LogInformation("No null primary key is valid");
                        return;
                    }

                    _context.Teams.Add(team);
                }

                foreach (var country in countries)
                {
                    if (country.Id is 0)
                    {
                        _logger.LogInformation("No null primary key is valid");
                        return;
                    }
                    _context.Countries.Add(country);
               }

                // _context.Add(existingCountries);
                // _context.Add(existingTeams);
                _context.Update(_context.Teams);
                _context.Update(_context.Countries);                             
                _context.SaveChanges();
            }            
        }

        public async Task<bool> AddTeam(string teamName)
        {
            try
            {
                if(Countries is null) 
                {
                    return false;
                }

                _context.Add(new Team()
                {
                    Name = teamName,
                    Country = Countries.First(c => c.Name.Equals(teamName))
                });

                await _context.SaveChangesAsync();
                return await Task.FromResult(true);

            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }


        public async Task<bool> DeleteTeam(string teamName)
        {
            try
            {
                var team = Teams?.First(t => t.Name.Equals(teamName));
                _context.Remove(team);
                _logger.LogInformation($"Team with name {team.Name} removed from DB");
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);

            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateTeamAndCountryPoints(string name, string resultType)
        {
            if(Teams is null || Countries is null) 
            {
                return false;
            }

            var team = Teams.First(t => t.Name.Equals(name));
            var country = Countries.First(t => t.Name.Equals(team.Country.Name));

            if (team is null || country is null)
            {
                return await Task.FromResult(false);
            }

            if (resultType.Equals("win") || int.Parse(resultType) == 3)
            {
                await UpdateTeamAndCountryPoints(team, 2000);
            }
            else if (resultType.Equals("draw") || int.Parse(resultType) == 1)                              
            {
                await UpdateTeamAndCountryPoints(team, 1000);
            }

            return await Task.FromResult(true);                            
        }

        public IEnumerable<Country>? GetCountries()
        {
            return this.Countries ?? null;
        }

        public IEnumerable<Team>? GetTeams()
        {
            return this.Teams ?? null;
        }

        private async Task UpdateTeamAndCountryPoints(Team team, int points)
        {
            _context.AddPointsToTeamAndCountry(team, points);            
            _context.Update(team);
            await _context.SaveChangesAsync();
        }        
    }
}
