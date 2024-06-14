using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using System.Collections.Generic;

namespace Assignment_3.Services.Interfaces
{
    public interface IGenreService
    {
        IList<GenreResponse> Get();
        GenreResponse Get(int id);
        int Create(GenreRequest genremodel);
        void Update(Genre genre);
        void Delete(int id);
    }
}
