using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.WebSwagger
{
    public class Program
    {
        // public IConfiguration Configuration { get; }
        public static void Main(string [] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // configure our dbContext domain in the web project, the connection string is placed in the appsettings.json (not need to set it here, but we can)
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("TeamsList"));
            // builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("CountriesList"));

            var app = builder.Build();

            // ToDo: implement later Health Checks properly
            // builder.Services.AddHealthChecks().AddCheck<SampleHealthCheck>("Sample");
            // app.MapHealthChecks("/healthy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();            
        }
    }
}