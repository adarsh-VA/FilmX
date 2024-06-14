using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using System.Collections.Generic;

namespace Assignment_3.Services.Interfaces
{
    public interface IReviewService
    {
        public IEnumerable<ReviewResponse> GetByMovie(int movieId);
        ReviewResponse Get(int movieId ,int id);
        int Create(int movieId,ReviewRequest reviewmodel);
        void Update(int movieId,Review review);
        void Delete(int movieId,int id);
    }
}
