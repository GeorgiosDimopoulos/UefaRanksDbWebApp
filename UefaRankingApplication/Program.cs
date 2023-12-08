using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.UserInterface
{
    public class Program
    {
        public static void Main(string [] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
            builder.Services.AddDbContext<TeamDbContext>(opt =>
            opt.UseInMemoryDatabase("TeamsList")); // TeamsList is the name of the list in the TeamDbContext class
        }
    }
}