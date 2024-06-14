using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using System.Collections.Generic;

namespace Assignment_3.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieResponse> Get();
        MovieResponse Get(int id);
        int Create(MovieRequest moviemodel);
        void Update(int id, MovieRequest moviemodel);
        void Delete(int id);
    }
}
