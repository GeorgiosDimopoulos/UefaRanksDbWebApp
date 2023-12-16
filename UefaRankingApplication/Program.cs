﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UefaRankingApplication.DataAccess.DbContexts;

namespace UefaRankingApplication.UserInterface
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

            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\georg\\OneDrive\\Έγγραφα\\UefaDatabase.mdf;Integrated Security=True;Connect Timeout=30";
            builder.Services.AddDbContext<TeamDbContext>(opt => opt.UseSqlServer(connectionString));
            builder.Services.AddDbContext<TeamDbContext>(opt => opt.UseInMemoryDatabase("TeamsList")); // .opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test"));
        }
    }
}