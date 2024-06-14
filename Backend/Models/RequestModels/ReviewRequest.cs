using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models.RequestModels
{
    public class ReviewRequest
    {
        [Required]
        public string Message { get; set; }
    }
}
