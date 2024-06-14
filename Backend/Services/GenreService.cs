using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using Assignment_3.Repository;
using Assignment_3.Repository.Interfaces;
using Assignment_3.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Services
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository,IMovieRepository movieRepository)
        {
            _genreRepository = genreRepository;
        }
        public void checkGenre(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id Should not be zero!");
            if (_genreRepository.GetById(id) == null)
                throw new KeyNotFoundException("Genre Not Found!");
        }
        public int Create(GenreRequest genremodel)
        {
            return _genreRepository.Create(new Genre { Name = genremodel.Name });
        }

        public void Delete(int id)
        {
            checkGenre(id);
            _genreRepository.Delete(id);
        }

        public IList<GenreResponse> Get()
        {
            return _genreRepository.GetAll().Select(g=>new GenreResponse { Id=g.Id,Name=g.Name}).ToList();
        }

        public GenreResponse Get(int id)
        {
            checkGenre(id);
            var genre = _genreRepository.GetById(id);
            return new GenreResponse { Id = genre.Id, Name = genre.Name };
        }

        public void Update(Genre genre)
        {
            checkGenre(genre.Id);
            _genreRepository.Update(genre);
        }
    }
}
