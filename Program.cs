using Microsoft.EntityFrameworkCore;
using LineMonitoring.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBsContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("DbConnection")));

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Display}/{action=Index}/{id?}");

app.Run();
