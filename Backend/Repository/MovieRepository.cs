using Assignment_3.Models.DbModels;
using Assignment_3.Models.ResponseModels;
using Assignment_3.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Assignment_3.Repository
{
    public class MovieRepository :BaseRepository<Movie>, IMovieRepository
    {
        private string _connectionString;

        public MovieRepository(IConfiguration configuration)
            : base(configuration)
        {
            _connectionString = configuration.GetConnectionString("IMDBDB");
        }

        public int Create(Movie movie,string actors,string genres)
        {
            var procedure = "[Foundation].[usp_InsertMovie]";
            var values = new {
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease, 
                Plot = movie.Plot, 
                Poster = movie.CoverImage, 
                ActorIds = actors, 
                GenreIds = genres, 
                ProducerId = movie.ProducerId, 
                Language = movie.Language, 
                Profit = movie.Profit};

            return Add(procedure, values);
        }

        public void Delete(int id)
        {
            DeleteProcedure("[Foundation].[usp_DeleteMovie]", new { Id = id });
        }

        public List<Movie> GetAll()
        {
            var query = @"SELECT [PK_Id] AS Id
                             ,[Name]
                             ,[YearOfRelease]
                             ,[Plot]
                             ,[Poster] AS CoverImage
                             ,[FK_ProducerId] AS ProducerId
                             ,[Language]
                             ,[Profit]
                         FROM [IMDB].[Foundation].[Movies] WITH (NOLOCK)";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Movie>(query).ToList();
            }
        }

        public Movie GetById(int id)
        {
            var query = @"SELECT [PK_Id] AS Id
                             ,[Name]
                             ,[YearOfRelease]
                             ,[Plot]
                             ,[Poster] AS CoverImage
                             ,[FK_ProducerId] AS ProducerId
                             ,[Language]
                             ,[Profit]
                         FROM [IMDB].[Foundation].[Movies]
                         WHERE PK_Id = @Id";

            return Get(query, new { Id = id });
        }

        public void Update(Movie movie, string actors, string genres)
        {

            var procedure = "[Foundation].[usp_UpdateMovie]";
            var values = new
            { 
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Poster = movie.CoverImage,
                ActorIds = actors,
                GenreIds = genres,
                ProducerId = movie.ProducerId,
                Language = movie.Language,
                Profit = movie.Profit
            };

            Update(procedure, values);
        }
    }
}
