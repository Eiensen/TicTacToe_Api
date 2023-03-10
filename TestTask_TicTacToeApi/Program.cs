global using TestTask_TicTacToeApi.Repositories;
global using Newtonsoft.Json;
global using TestTask_TicTacToeApi.Enums;
global using TestTask_TicTacToeApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using System.Text.Json;
global using TestTask_TicTacToeApi.ViewModels;
global using TestTask_TicTacToeApi.Servicies;
global using System.Text;
global using Microsoft.OpenApi.Models;
global using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TicTacToe API",
        Description = "Простое ASP.NET Core Web API, которое позволяет получить все необходимые данные для игры в Крестики-Нолики",       
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<IRepository, FileRepository>();

builder.Services.AddTransient<IFealdLogicService, FealdLogicService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
