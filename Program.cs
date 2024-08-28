using dotenv.net;
using karyawanApp.Models;
using karyawanApp.Repositories;
using karyawanApp.services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

DotEnv.Config();

var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IPersistance), typeof(DbPersistance));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAbsensi, AbsensiService>();

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

// app.MapControllerRoute(
//     name: "absensi",
//     pattern: "Absensi/{action=absensiGet}/{id?}",
//     defaults: new { controller = "Absensi" }
//     );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Employee}/{id?}");

app.Run();
