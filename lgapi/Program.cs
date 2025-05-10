using lgapi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var corsPolicyName = "AllowAngularApp";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            policy.WithOrigins("https://lg-website-sigma.vercel.app/") // or your deployed Angular domain
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // Optional, if using cookies/auth
        });
});



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Enable CORS
app.UseCors(corsPolicyName);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication(); // If using JWT or cookies

app.UseAuthorization();

app.MapControllers();

app.Run();
