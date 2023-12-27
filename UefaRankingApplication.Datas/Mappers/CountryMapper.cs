using Dapper;
using FluentMigrator.Runner.Generators;
using System.Data;
using UefaRankingApplication.Data.Models;

namespace UefaRankingApplication.DataAccess.Mappers
{
    public class CountryMapper : ITypeMap
    {
        public CountryMapper()
        {
            Dapper.SqlMapper.SetTypeMap(
    typeof(Team),
    new CustomPropertyTypeMap(
        typeof(Team),
        (type, columnName) =>
            type.GetProperties().FirstOrDefault(prop =>
                prop.GetCustomAttributes(false)
                    .OfType<Team>()
                    .Any(attr => attr.Name == columnName))));
        }

        public string GetTypeMap(DbType type, int size, int precision)
        {
            throw new NotImplementedException();
        }

        public string GetTypeMap(DbType type, int? size, int? precision)
        {
            throw new NotImplementedException();
        }
    }
}
