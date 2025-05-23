using lgapi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot"
});

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var corsPolicyName = "AllowAngularApp";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            policy.WithOrigins(
                    "http://localhost:4200", // Angular local dev server
                    "https://lg-website-sigma.vercel.app" // Deployed frontend
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // Only needed if using cookies/auth
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
app.UseStaticFiles();

app.UseAuthentication(); // If using JWT or cookies

app.UseAuthorization();

app.MapControllers();

app.Run();
