using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models.RequestModels
{
    public class ProducerRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
