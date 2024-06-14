using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace Assignment_3.Models.DbModels
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public string Language { get; set; }
        public double Profit { get; set; }
        public string CoverImage { get; set; }
    }
}
