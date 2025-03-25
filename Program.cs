using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CarDealerApp.Models;
using CarDealerApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string is missing.");

var jwtSettings = configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]);
Console.WriteLine($"JWT Secret: {configuration["JwtSettings:Secret"]}");


// Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure Authentication (JWT for API, Cookies for MVC)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yT9f@kL!xA4VqW2mZ7sN#GdXpJ6uC8bE0R5tL!vM3pQ")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
})
.AddCookie(); // Cookie authentication for MVC

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();


app.Run();
