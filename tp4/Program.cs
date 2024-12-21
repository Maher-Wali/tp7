using Microsoft.EntityFrameworkCore;
using tp4.Repositories;
using tp4.Repositories.MovieRepo;
using tp4.Services.MovieService;
using tp4.Services.CustomerService;
using Microsoft.AspNetCore.Identity;
using System;
using tp4.Infrastructure.Repositories;
using tp4.Core.Interfaces.Repositories;
using tp4.Application.Services;
using tp4.Core.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//configure the identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
options.SignIn.RequireConfirmedAccount = true)
.AddEntityFrameworkStores<ApplicationDbContext>();
// Register the repository

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieService,MovieService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddScoped<IMovieRepository, MovieRepository>();
services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMembershipTypeService, MembershipTypeService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;
    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

var app = builder.Build();
builder.Services.AddRazorPages();
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

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
