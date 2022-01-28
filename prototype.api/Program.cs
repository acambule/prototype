using Codewrinkles.MinimalApi.SmartModules.Extensions.WebApplicationExtensions;
using prototype.Application.Interfaces;
using prototype.infrastructure;
using prototype.infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPrototypeRepository, PrototypeRepository>();
builder.Services.AddScoped<IPrototypeService, PrototypeService>();

builder.Services.AddSmartModules(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSmartModules();

app.Run();