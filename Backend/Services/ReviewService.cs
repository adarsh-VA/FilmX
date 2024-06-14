using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using Assignment_3.Repository;
using Assignment_3.Repository.Interfaces;
using Assignment_3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Services
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository _reviewRepository;
        private IMovieRepository _movieRepository;
        public ReviewService(IReviewRepository reviewRepository, IMovieRepository movieRepository,IProducerRepository producerRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
        }
        public void checkReview(int movieId, int reviewId)
        {
            if (movieId == 0 || reviewId == 0) throw new ArgumentException("Id should not be Zero");
            if (_movieRepository.GetById(movieId) == null)
                throw new KeyNotFoundException("Movie Not Found!");
            var review = _reviewRepository.GetAll(movieId).Find(r => r.Id == reviewId && r.MovieId == movieId);
            if (review == null)
                throw new KeyNotFoundException("Review Not Found!");
        }
        public int Create(int movieId,ReviewRequest reviewmodel)
        {
            if (movieId == 0)
                throw new ArgumentException("Movie Id should not be Zero");
            if (_movieRepository.GetAll().Find(m => m.Id == movieId) == null)
                throw new KeyNotFoundException("Movie Not Found!");
            return _reviewRepository.Create(new Review {Message = reviewmodel.Message, MovieId = movieId });
        }

        public void Delete(int movieId,int id)
        {
            checkReview(movieId, id);
            _reviewRepository.Delete(id);
        }

        public IEnumerable<ReviewResponse> GetByMovie(int movieId)
        {
            if (movieId == 0)
                throw new ArgumentException("Movie Id should not be Zero");
            if (_movieRepository.GetById(movieId) == null)
                throw new KeyNotFoundException("Movie Not Found!");
            var reviews = _reviewRepository.GetAll(movieId).Select(r=>new ReviewResponse { Id=r.Id,Message=r.Message,MovieId=r.MovieId}).ToList();
            if (reviews == null)
                throw new KeyNotFoundException("Reviews Not Found!");
            return reviews;
        }

        public ReviewResponse Get(int movieId,int id)
        {
            checkReview(movieId, id); 
            var review = _reviewRepository.GetById(movieId, id);
            return new ReviewResponse { Id = review.Id, Message = review.Message,MovieId=review.MovieId };
        }

        public void Update(int movieId,Review review)
        {
            checkReview(movieId, review.Id);
            _reviewRepository.Update(review);
        }
    }
}
