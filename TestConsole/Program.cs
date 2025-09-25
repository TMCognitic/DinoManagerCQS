// See https://aka.ms/new-console-template for more information
using DE = DinoManager.Dal.Entities;
using DR = DinoManager.Dal.Repositories;
using DS = DinoManager.Dal.Services;
using DinoManager.Bll.Entities;
using DinoManager.Bll.Repositories;
using DinoManager.Bll.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

IServiceCollection services = new ServiceCollection();
services.AddTransient<DbConnection>(sp => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DinoManager.Database;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;"));
services.AddScoped<DR.IDinoRepository, DS.DinoService>();
services.AddScoped<IDinoRepository, DinoService>();

IServiceProvider serviceProvider = services.BuildServiceProvider();
DR.IDinoRepository dalRepository = serviceProvider.GetService<DR.IDinoRepository>()!;
IDinoRepository dinoRepository = serviceProvider.GetService<IDinoRepository>()!;

//Dino dino = new Dino("Test", 155, 2500);

//dinoRepository.Create(dino);


foreach(Dino d in dinoRepository.Get())
{
    Console.WriteLine(d.Espece);
}

