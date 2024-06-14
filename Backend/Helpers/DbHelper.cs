using Assignment_3.Models.DbModels;
using Assignment_3.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Helpers
{
    public class DbHelper : IDbHelper
    {
        private string _connectionString;
        public DbHelper(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public List<Actor> GetActorsByMovie(int id)
        {
            var actorQuery = @"SELECT [PK_Id] AS Id
                                    ,[Name]
                                    ,[Sex] AS Gender
                                    ,[Dob] AS DOB
                                    ,[Bio]
                                FROM [IMDB].[Foundation].[Actors] WITH (NOLOCK)
                                JOIN [Foundation].[Actors_Movies] ON FK_ActorId = PK_Id
                                WHERE FK_MovieId = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Actor>(actorQuery, new { Id = id }).ToList();
            }
        }
        public List<Genre> GetGenresByMovie(int id)
        {
            var genreQuery = @"SELECT [Id]
                               	,[Name]
                               FROM [IMDB].[Foundation].[Genres] WITH (NOLOCK)
                               JOIN Foundation.Genres_Movies ON FK_GenreId = Id
                               WHERE FK_MovieId = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Genre>(genreQuery, new { Id = id }).ToList();
            }
        }
    }
}
