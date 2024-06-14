using Assignment_3.Models.DbModels;
using System.Collections.Generic;

namespace Assignment_3
    .Helpers
{
    public interface IDbHelper
    {
        public List<Actor> GetActorsByMovie(int id);
        public List<Genre> GetGenresByMovie(int id);
    }
}
