using DR = DinoManager.Dal.Repositories;
using DS = DinoManager.Dal.Services;
using DinoManager.Bll.Repositories;
using DinoManager.Bll.Services;
using System.Data.Common;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<DbConnection>(sp => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DinoManager.Database;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;"));
builder.Services.AddScoped<DR.IDinoRepository, DS.DinoService>();
builder.Services.AddScoped<IDinoRepository, DinoService>();

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
