using DinoManager.Dal.Entities;
using DinoManager.Dal.Mappers;
using DinoManager.Dal.Repositories;
using System.Data;
using System.Data.Common;

using Tools.Database;

namespace DinoManager.Dal.Services
{
    public class DinoService : IDinoRepository
    {
        private readonly DbConnection _dbConnection;

        public DinoService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public IEnumerable<Dino> Get()
        {
            return _dbConnection.ExecuteReader("SELECT [Id], [Espece], [Poids], [Taille] FROM [Dinosaure];", dr => dr.ToDino()).ToList();
        }

        public Dino? Get(int id)
        {
            return _dbConnection.ExecuteReader("SELECT [Id], [Espece], [Poids], [Taille] FROM [Dinosaure] WHERE Id = @Id;", dr => dr.ToDino(), parameters: new { id }).SingleOrDefault();
        }

        public bool Create(Dino dino)
        {
            //Requete SQL pour insérer le dino en DB
            try
            {
                _dbConnection.ExecuteNonQuery("AjoutDinosaure", true, new { dino.Espece, dino.Poids, dino.Taille });
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            // Ceci remeplace ce qui est en dessous

            //using (DbCommand dbCommand = _dbConnection.CreateCommand())
            //{
            //    dbCommand.CommandText = "AjoutDinosaure";
            //    dbCommand.CommandType = CommandType.StoredProcedure;

            //    DbParameter especeParam = dbCommand.CreateParameter();
            //    especeParam.ParameterName = "Espece";
            //    especeParam.Value = dino.Espece;
            //    dbCommand.Parameters.Add(especeParam);

            //    DbParameter poidsParam = dbCommand.CreateParameter();
            //    poidsParam.ParameterName = "Poids";
            //    poidsParam.Value = dino.Poids;
            //    dbCommand.Parameters.Add(poidsParam);

            //    DbParameter tailleParam = dbCommand.CreateParameter();
            //    tailleParam.ParameterName = "Taille";
            //    tailleParam.Value = dino.Taille;
            //    dbCommand.Parameters.Add(tailleParam);

            //    try
            //    {
            //        dbCommand.ExecuteNonQuery();
            //        return true;                
            //    }
            //    catch (Exception)
            //    {
            //        return false;
            //    }
            //}
        }

        public bool Update(Dino dino)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("UpdateDinosaure", true, dino);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("DeleteDinosaure", true, new { id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
