using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Assignment_3
    .Repository
{
    public class BaseRepository<T> where T : class
    {
        private string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("IMDBDB");
        }

        public List<T> Get(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<T>(query).ToList();
            }      
        }
        public List<T> GetWithValue(string query, object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<T>(query, values).ToList();
            }
        }

        public T Get(string query,object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<T>(query,values);
            }
        }

        public int Add(string procedure,object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }
        
        public void Update(string procedure,object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(string query, object values) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, values);
            }
        }

        public void DeleteProcedure(string procedure,object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public List<int> GetIds(string query,object values)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<int>(query,values).ToList<int>();
            }
        }
    }
}
