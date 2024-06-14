using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models.RequestModels
{
    public class GenreRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
