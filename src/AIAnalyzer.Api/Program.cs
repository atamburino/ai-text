using Microsoft.OpenApi.Models;
using AIAnalyzer.Api.Services;
using DotNetEnv;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
Env.Load(envPath);

// For debugging - log the path and if the file exists
Console.WriteLine($"Looking for .env file at: {envPath}");
Console.WriteLine($".env file exists: {File.Exists(envPath)}");
if (File.Exists(envPath))
{
    Console.WriteLine($"Current environment variables:");
    Console.WriteLine($"DEEPSEEK_API_KEY: {Environment.GetEnvironmentVariable("DEEPSEEK_API_KEY")}");
}

// Add this line to explicitly set the URLs
builder.WebHost.UseUrls("https://localhost:5001", "http://localhost:5000");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AIAnalyzer API", Version = "v1" });
});

// Register HttpClient and MLService
builder.Services.AddHttpClient<MLService>();
builder.Services.AddScoped<MLService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AIAnalyzer API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
