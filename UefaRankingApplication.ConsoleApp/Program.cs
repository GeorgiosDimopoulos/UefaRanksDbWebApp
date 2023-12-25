using UefaRankingApplication.DataAccess.DbContexts;
using UefaRankingApplication.DataAccess.Models;

Console.WriteLine("Hello, people of UEFA!");

CreateTeam();
GetTeams();

CreateCountry();
GetCountries();

void GetCountries()
{
    using var context = new ApplicationDbContext();
    foreach (var c in context.Countries.ToList())
    {
        Console.WriteLine(c.Name);
    }
}
void CreateTeam()
{
    using var context = new ApplicationDbContext();
    context.Teams.Add(new Team
    {
        Name = "Dortmund",
        Country_Id = 1,
        IsPlaying = true,
        RankingPoints = 2212
    });
}

void GetTeams()
{
    using var context = new ApplicationDbContext();
    foreach (var c in context.Teams.ToList())
    {
        Console.WriteLine(c.Name);
    }
}

void CreateCountry()
{
    using var context = new ApplicationDbContext();

    //Console.WriteLine("Give a new country's name");
    //var newCountryName = Console.ReadLine();

    //Console.WriteLine("Give a new country's points");
    //var newCountryPoints = Console.ReadLine();

    //Console.WriteLine("Give a new country's position");
    //var newCountryPosition = Console.ReadLine();

    //Console.WriteLine("Give a new country's number of teams");
    //var newCountryteams = Console.ReadLine();   

    context.Countries.Add(new Country
    {
        Name = "Italy",
        CountryPoints = 43234,
        AllTeamsNumber = 4,
        RankingPosition = 2,
    });       

    context.SaveChanges();    
}