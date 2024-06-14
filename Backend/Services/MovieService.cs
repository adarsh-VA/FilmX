using Assignment_3.Helpers;
using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using Assignment_3.Repository;
using Assignment_3.Repository.Interfaces;
using Assignment_3.Services.Interfaces;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Assignment_3.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IDbHelper _dbHelper;


        public MovieService(IMovieRepository movieRepository, IProducerRepository producerRepository,IGenreRepository genreRepository, IActorRepository actorRepository,IConfiguration configuration)
        {
            _movieRepository = movieRepository;
            _producerRepository = producerRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;
            _dbHelper = new DbHelper(configuration.GetConnectionString("IMDBDB"));
        }
        public void CheckMovie(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id should not be Zero");
            if (_movieRepository.GetById(id) == null)
                throw new KeyNotFoundException("Movie Not Found!");
        }

        public List<int> validateActors(string ActorIds)
        {
            if (ActorIds == "")
                throw new ArgumentException("ActorsId should not be Empty");

            int aId;
            var actors = new List<int>();

            foreach (var a in ActorIds.Split(','))
            {
                try
                {
                    aId = Convert.ToInt32(a);
                }
                catch (System.Exception)
                {
                    throw new ArgumentException("Actor Id Format Error!");
                }
                if (_actorRepository.GetById(aId) == null)
                    throw new KeyNotFoundException("Actor Not Found!");
                actors.Add(aId);
            }
            return actors;
        }
        public List<int> validateGenres(string GenreIds)
        {
            if (GenreIds == "")
                throw new ArgumentException("GenresId should not be Empty");

            int gId;
            var genres = new List<int>();

            foreach (var g in GenreIds.Split(','))
            {
                try
                {
                    gId = Convert.ToInt32(g);
                }
                catch (System.Exception)
                {
                    throw new ArgumentException("Genre Id Format Error!");
                }
                if (_genreRepository.GetById(gId) == null)
                    throw new KeyNotFoundException("Genre Not Found!");
                genres.Add(gId);
            }
            return genres;
        }

        public int Create(MovieRequest movieRequest)
        {
            var movie = new Movie {
                Name=movieRequest.Name,
                Plot=movieRequest.Plot, 
                ProducerId=movieRequest.ProducerId, 
                YearOfRelease = movieRequest.YearOfRelease,
                CoverImage = movieRequest.CoverImage,
                Language=movieRequest.Language,
                Profit=movieRequest.Profit,
            };

            validateActors(movieRequest.ActorIds);
            validateGenres(movieRequest.GenreIds);
            if (_producerRepository.GetById(movieRequest.ProducerId) == null)
                throw new KeyNotFoundException("Producer Not Found!");
            return _movieRepository.Create(movie, movieRequest.ActorIds, movieRequest.GenreIds);
        }

        public void Delete(int id)
        {
            CheckMovie(id);
            _movieRepository.Delete(id);
        }

        public List<MovieResponse> Get()
        {
            try
            {
                var movies = _movieRepository.GetAll();
                var response = new List<MovieResponse>();

                foreach (var movie in movies)
                {
                    response.Add(new MovieResponse
                    {
                        Id = movie.Id,
                        Name = movie.Name,
                        YearOfRelease = movie.YearOfRelease,
                        Plot = movie.Plot,
                        CoverImage = movie.CoverImage,
                        Language = movie.Language,
                        Profit = movie.Profit,
                        producer = _producerRepository.GetById(movie.ProducerId),
                        Actors = _dbHelper.GetActorsByMovie(movie.Id),
                        Genres = _dbHelper.GetGenresByMovie(movie.Id)
                    });
                }

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public MovieResponse Get(int id)
        {
            CheckMovie(id);
            var movie = _movieRepository.GetById(id);

            var response = new MovieResponse { 
                Id= id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                CoverImage = movie.CoverImage,
                Language=movie.Language,
                Profit=movie.Profit,
                producer = _producerRepository.GetById(movie.ProducerId),
                Actors = _dbHelper.GetActorsByMovie(id),
                Genres = _dbHelper.GetGenresByMovie(id)
            };
            return response;
        }

        public void Update(int id, MovieRequest movieRequest)
        {
            var movie = new Movie
            {
                Id = id,
                Name = movieRequest.Name,
                Plot = movieRequest.Plot,
                ProducerId = movieRequest.ProducerId,
                YearOfRelease = movieRequest.YearOfRelease,
                CoverImage = movieRequest.CoverImage,
                Language = movieRequest.Language,
                Profit = movieRequest.Profit,
            };
            CheckMovie(id);
            validateActors(movieRequest.ActorIds);
            validateGenres(movieRequest.GenreIds);
            if (_producerRepository.GetById(movieRequest.ProducerId) == null)
                throw new KeyNotFoundException("Producer Not Found!");

            _movieRepository.Update(movie,movieRequest.ActorIds, movieRequest.GenreIds);
        }
    }
}
