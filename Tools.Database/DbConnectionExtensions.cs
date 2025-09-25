using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Tools.Database
{
    public static class DbConnectionExtensions
    {
        public static object? ExecuteScalar(this DbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                object? result = dbCommand.ExecuteScalar();
                return result is DBNull ? null : result;
            }
        }

        public static int ExecuteNonQuery(this DbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                return dbCommand.ExecuteNonQuery();
            }
        }

        public static IEnumerable<TResult> ExecuteReader<TResult>(this DbConnection dbConnection, string query, Func<IDataRecord, TResult> mapper, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
                {
                    while (dbDataReader.Read())
                    {
                        yield return mapper(dbDataReader);
                    }
                }
            }
        }

        private static DbCommand CreateCommand(DbConnection dbConnection, string query, bool isStoredProcedure, object? parameters)
        {
            EnsureDbConnection(dbConnection);

            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            if (isStoredProcedure)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }

            if (parameters is not null)
            {
                foreach (PropertyInfo property in parameters.GetType().GetProperties().Where(p => p.CanRead))
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = property.Name;
                    dbParameter.Value = property.GetValue(parameters) ?? DBNull.Value;
                    dbCommand.Parameters.Add(dbParameter);
                }
            }

            return dbCommand;
        }

        private static void EnsureDbConnection(DbConnection dbConnection)
        {
            ArgumentNullException.ThrowIfNull(dbConnection);

            if (dbConnection.State is ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            if (dbConnection.State is not ConnectionState.Open)
            {
                throw new InvalidOperationException("The database connection is not open.");
            }
        }
    }
}
