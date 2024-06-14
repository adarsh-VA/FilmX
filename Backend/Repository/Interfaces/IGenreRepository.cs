using Assignment_3.Models.DbModels;
using System.Collections.Generic;

namespace Assignment_3.Repository.Interfaces
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();
        Genre GetById(int id);
        int Create(Genre genre);
        void Update(Genre genre); 
        void Delete(int id);

    }
}
