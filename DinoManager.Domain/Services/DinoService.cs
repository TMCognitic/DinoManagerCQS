using DinoManager.Domain.Commands;
using DinoManager.Domain.Entities;
using DinoManager.Domain.Mappers;
using DinoManager.Domain.Queries;
using DinoManager.Domain.Repositories;
using System.Data.Common;
using Tools.Database;

namespace DinoManager.Domain.Services
{
    public class DinoService : IDinoRepository
    {
        private readonly DbConnection _dbConnection;

        public DinoService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public IEnumerable<Dino> Execute(GetAllDinosaureQuery query)
        {
            return _dbConnection.ExecuteReader("SELECT [Id], [Espece], [Poids], [Taille] FROM [Dinosaure];", dr => dr.ToDino()).ToList();
        }

        public bool Execute(CreateDinoCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("AjoutDinosaure", true, command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Dino? Execute(GetDinoByIdQuery query)
        {
            return _dbConnection.ExecuteReader("SELECT [Id], [Espece], [Poids], [Taille] FROM [Dinosaure] WHERE Id = @Id;", dr => dr.ToDino(), parameters: query).SingleOrDefault();
        }

        public bool Execute(DeleteDinoCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("DeleteDinosaure", true, command);
                
                if(rows == 1)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Execute(UpdateDinoCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("UpdateDinosaure", true, command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
