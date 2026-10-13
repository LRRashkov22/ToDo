using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using To_Do.Application.Interfaces;
using To_Do.Application.Services;
using To_Do.Infrastructure.Persistance;
var builder = WebApplication.CreateBuilder(args);

// LOAD ENV
var currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
var files = currentDir.GetFiles(".env");
var file = files.First();
Console.WriteLine($".ENV value: {file.FullName}");
DotNetEnv.Env.Load(file.FullName);
builder.Configuration.AddEnvironmentVariables();
// LOAD ENV

builder.Services.AddDbContext<BContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<ICrudTask, CrudTask>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Conn", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
builder.Services.AddOpenApi();
var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
// Configure the HTTP request pipeline.
app.UseCors("Conn");
app.UseAuthorization();

app.MapControllers();

app.Run();
