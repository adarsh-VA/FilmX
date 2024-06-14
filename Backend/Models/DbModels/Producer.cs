using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models.DbModels
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }

    }
}
