using Business.Abstract;
using Business.Concrete;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SpaceWeatherContext>(options => options.UseInMemoryDatabase(databaseName: "SpaceWeatherDB"));

// Add AutoMapper configuration
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(MappingProfile));


// Add this line to register controllers
builder.Services.AddControllers();

//builder.Services.AddTransient<IPlanetService, PlanetManager>();
//builder.Services.AddTransient<IPlanetInMemoryDal, PlanetInMemoryDal>();

//builder.Services.AddTransient<ISatelliteService, SatelliteManager>();
//builder.Services.AddTransient<ISatelliteInMemoryDal, SatelliteInMemoryDal>();

builder.Services.AddScoped<IPlanetService, PlanetManager>();
builder.Services.AddScoped<IPlanetInMemoryDal, PlanetInMemoryDal>();

builder.Services.AddScoped<ISatelliteService, SatelliteManager>();
builder.Services.AddScoped<ISatelliteInMemoryDal, SatelliteInMemoryDal>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PlanetInMemoryDal.InitializeData(builder.Services.BuildServiceProvider());
SatelliteInMemoryDal.InitializeData(builder.Services.BuildServiceProvider());

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();