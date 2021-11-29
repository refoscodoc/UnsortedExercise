using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Sakila;
using Sakila.DbAccess;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
builder.Services.AddDbContext<ActorContext>(o => o.UseMySql(builder.Configuration.GetConnectionString("DataAccessSqliteProvider"), serverVersion));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// var sqlConnectionString = "server=localhost;userid=alberto;password=vinazza;database=sakila;";
// MySqlConnection connection = new MySqlConnection(sqlConnectionString);


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