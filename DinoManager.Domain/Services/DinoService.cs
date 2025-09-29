using DinoManager.Domain.Commands;
using DinoManager.Domain.Entities;
using DinoManager.Domain.Mappers;
using DinoManager.Domain.Queries;
using DinoManager.Domain.Repositories;
using System.Data.Common;
using Tools.Cqs.Queries;
using Tools.Cqs.Results;
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

        public async Task<ICqsResult<IEnumerable<Dino>>> ExecuteAsync(GetAllDinosaureQuery query)
        {
            try
            {
                IEnumerable<Dino> result = await _dbConnection.ExecuteReaderAsync("SELECT [Id], [Espece], [Poids], [Taille] FROM [Dinosaure];", dr => dr.ToDino()).ToList();

                return CqsResult<IEnumerable<Dino>>.Success(result.ToList());
            }
            catch (Exception ex)
            {
                return CqsResult<IEnumerable<Dino>>.Failure(ex.Message);
            }
        }

        public ICqsResult<Dino> Execute(GetDinoByIdQuery query)
        {
            try
            {
                Dino? dino = _dbConnection.ExecuteReader("SELECT [Id], [Espece], [Poids], [Taille] FROM [Dinosaure] WHERE Id = @Id;", dr => dr.ToDino(), parameters: query).SingleOrDefault();

                if (dino is null)
                    return CqsResult<Dino>.Failure("Dino Not Found");

                return CqsResult<Dino>.Success(dino);
            }
            catch (Exception ex)
            {
                return CqsResult<Dino>.Failure(ex.Message);
            }
        }

        public async Task<ICqsResult> ExecuteAsync(CreateDinoCommand command)
        {
            try
            {
                await _dbConnection.ExecuteNonQueryAsync("AjoutDinosaure", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        

        public ICqsResult Execute(DeleteDinoCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("DeleteDinosaure", true, command);

                if (rows == 1)
                    return CqsResult.Success();

                return CqsResult.Failure("Dino not found");
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(UpdateDinoCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("UpdateDinosaure", true, command);
                
                if (rows == 1)
                    return CqsResult.Success();

                return CqsResult.Failure("Dino not found");
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
