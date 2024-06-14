using Assignment_3.Models.DbModels;
using Assignment_3.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Assignment_3.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public int Create(Review review)
        {
            return Add("[Foundation].[usp_AddReview]", new { Message = review.Message,MovieId = review.MovieId });
        }

        public void Delete(int id)
        {
            var query = @"DELETE FROM [IMDB].[Foundation].[Reviews] WHERE Id = @Id;";
            Delete(query, new { Id = id });
        }

        public List<Review> GetAll(int movieId)
        {
            string query = @"SELECT [Id]
                                ,[Message]
                                ,[FK_MovieId] AS MovieId
                            FROM [IMDB].[Foundation].[Reviews] WITH (NOLOCK)
                            WHERE FK_MovieId = @Id";
            return GetWithValue(query, new {Id=movieId});
        }
        public Review GetById(int movieId,int id)
        {
            string query = @"SELECT [Id]
                                ,[Message]
                                ,[FK_MovieId] AS MovieId
                            FROM [IMDB].[Foundation].[Reviews] WITH (NOLOCK)
                            WHERE Id = @Id AND FK_MovieId = @movieId;";
            return Get(query, new {Id = id, movieId = movieId});
        }

        public void Update(Review review)
        {
            Update("[Foundation].[usp_UpdateReview]", new { Id = review.Id, Message = review.Message,MovieId = review.MovieId });
        }
    }
}
