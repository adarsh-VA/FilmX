using Assignment_3.Models.DbModels;
using Assignment_3.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Assignment_3.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public int Create(Genre genre)
        {
            return Add("[Foundation].[usp_AddGenre]", new { Name = genre.Name});
        }

        public void Delete(int id)
        {
            DeleteProcedure("[Foundation].[usp_DeleteGenre]", new { Id = id });
        }

        public List<Genre> GetAll()
        {
            string query = @"SELECT [Id]
                                ,[Name]
                            FROM [IMDB].[Foundation].[Genres] WITH (NOLOCK)";
            return Get(query);
        }


        public Genre GetById(int id)
        {
            var query = @"SELECT [Id]
                        	,[Name]
                        FROM [IMDB].[Foundation].[Genres]W WITH (NOLOCK)
                        WHERE Id = @Id;";
            return Get(query, new { Id = id });
        }

        public void Update(Genre genre)
        {
            Update("[Foundation].[usp_UpdateGenre]", new { Id = genre.Id, Name = genre.Name });
        }
    }
}
