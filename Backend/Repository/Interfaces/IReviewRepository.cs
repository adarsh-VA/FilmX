using Assignment_3.Models.DbModels;
using System.Collections.Generic;

namespace Assignment_3.Repository.Interfaces
{
    public interface IReviewRepository
    {
        List<Review> GetAll(int moviedId);
        Review GetById(int movieId,int id);
        int Create(Review review);
        void Update(Review review);
        void Delete(int id);
    }
}
