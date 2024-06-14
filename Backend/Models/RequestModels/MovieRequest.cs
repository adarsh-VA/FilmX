using System.Reflection;
using System;
using Assignment_3.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models.RequestModels
{
    public class MovieRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int YearOfRelease { get; set; }
        [Required]
        public string Plot { get; set; }    
        [Required]
        public string ActorIds { get; set; }
        [Required]
        public string GenreIds { get; set; }
        [Required]
        public int ProducerId { get; set; }
        [Required]
        public string Language { get; set; }

        [Required]
        public double Profit { get; set; }
        [Required]
        public string CoverImage { get; set; }
    }
}
