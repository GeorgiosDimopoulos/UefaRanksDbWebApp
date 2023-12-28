Console.WriteLine("1.Check all available countries");
Console.WriteLine("2. Check all available teams");
Console.WriteLine("3. Add a new country in DB");
Console.WriteLine("4. Add a new team in DB");
Console.WriteLine("5. Get only only team from DB");
Console.WriteLine("6. Get only only country with its teams from DB");
Console.WriteLine("Press anything else to EXIT");

var choiceStr =Console.ReadLine();
var choice = int.Parse(choiceStr ?? "0");

switch (choice)
{
    case 1:
        // GetCountries();
        break;
    case 2:
        // GetTeams();
        break;
    case 3: 
        // CreateCountry();
        break;
    case 4:
        // CreateTeam();
        break;
    case 5:
        // GetTeam();
        break;
    case 6:
        // GetCountryWithItsTeams();
        break;
    default:
        break;
}

//CreateTeam();
//GetTeams();
//CreateCountry();
// GetCountries();

//void GetCountries()
//{
//    using var context = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
//    foreach (var c in context.Countries.ToList())
//    {
//        Console.WriteLine(c.Name);
//    }
//}
//void CreateTeam()
//{
//    using var context = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
//    context.Teams.Add(new Team
//    {
//        Name = "Dortmund",
//        Country_Id = 1,
//        IsPlaying = true,
//        RankingPoints = 2212
//    });
//}

//void GetTeams()
//{
//    using var context = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
//    foreach (var c in context.Teams.ToList())
//    {
//        Console.WriteLine(c.Name);
//    }
//}

//void CreateCountry()
//{
//    using var context = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());

//    Console.WriteLine("Give a new country's name");
//    var newCountryName = Console.ReadLine();

//    Console.WriteLine("Give a new country's points");
//    var newCountryPoints = Console.ReadLine();

//    Console.WriteLine("Give a new country's position");
//    var newCountryPosition = Console.ReadLine();

//    Console.WriteLine("Give a new country's number of teams");
//    var newCountryteams = Console.ReadLine();

//    context.Countries.Add(new Country
//    {
//        Name = newCountryName ?? string.Empty,
//        CountryPoints = int.Parse(newCountryPoints ?? "0"),
//        AllTeamsNumber = int.Parse(newCountryteams ?? "0"),
//        RankingPosition = int.Parse(newCountryPosition ?? "0")
//    });       

//    context.SaveChanges();    
//}