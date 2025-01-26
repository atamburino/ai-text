using Microsoft.OpenApi.Models;
using AIAnalyzer.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add this line to explicitly set the URLs
builder.WebHost.UseUrls("https://localhost:5001", "http://localhost:5000");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AIAnalyzer API", Version = "v1" });
});

// Register ML Service
builder.Services.AddSingleton<MLService>();

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
