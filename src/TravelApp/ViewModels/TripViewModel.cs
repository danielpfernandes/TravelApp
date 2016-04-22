using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.ViewModels
{
    public class TripViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "This field cannot have less than 5 neither more than 255 characters")]
        public string Name { get; set; }
        public DateTime DateCreated {get { return DateTime.Now; }}
        public ICollection<StopViewModel> StopsView { get; set; }
    }
}
