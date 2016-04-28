using System;
using System.ComponentModel.DataAnnotations;

namespace TravelApp.ViewModels
{
    public class StopViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "The name must have more than 5 and less than 255 charaters")]
        public string Name { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; } 
    }
}