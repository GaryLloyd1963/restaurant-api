﻿using restaurantAPI.Interface;
using restaurantAPI.Repository;
using restaurantAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddSingleton<IRestaurantService, RestaurantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    var connectionString = builder.Configuration.GetConnectionString("RestaurantsDb");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string 'RestaurantsDb' is not configured.");
    }

    SqliteInfrastructure.SqliteDBBuilder.BuildDatabase(connectionString, true);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapRestaurantEndpoints();

app.Run();
