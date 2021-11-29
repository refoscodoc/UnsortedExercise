using DataAccess.Repositories;
using DataAccessEF.Repositories;
using Microsoft.EntityFrameworkCore;
using NewWebAPIdotnet6.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IFilmService, FilmService>();
builder.Services.AddTransient<IFilmRepository, FilmRepository>();
builder.Services.AddTransient<IFilmServiceEf, FilmServiceEf>();
builder.Services.AddTransient<IFilmRepositoryEf, FilmRepositoryEf>();

var sql = "server=localhost;userid=alberto;password=vinazza;database=sakila;";
//var sqlConnectionString = Configuration.GetConnectionString("DataAccessMySqlProvider");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

builder.Services.AddDbContext<RepositoryBaseEf>(options =>
    options.UseMySql(sql, serverVersion));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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