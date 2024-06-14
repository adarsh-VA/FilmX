using Assignment_3.Models.DbModels;
using Assignment_3.Models.ResponseModels;
using System.Collections;
using System.Collections.Generic;

namespace Assignment_3.Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll(); 
        Movie GetById(int id); 
        int Create(Movie movie, string actors, string genres); 
        void Update(Movie movie, string actors, string genres); 
        void Delete(int id);

    }
}
