using Microsoft.EntityFrameworkCore;
using UefaRankingApplication.DataAccess.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

CheckAndApplyMigrations();

app.Run();

void CheckAndApplyMigrations()
{
    // get all the existing services
    using (var scope = app.Services.CreateScope())
    {
        // get for this action only the DbContext service
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // if the systems finds any pending migration, then apply it and update DB
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}