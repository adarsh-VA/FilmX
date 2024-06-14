using Assignment_3.Models.DbModels;
using System;
using System.Collections.Generic;

namespace Assignment_3.Models.ResponseModels
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Genre> Genres { get; set; }
        public Producer producer { get; set; }
        public string Language { get; set; }
        public double Profit { get; set; }
        public string CoverImage { get; set; }
    }
}
