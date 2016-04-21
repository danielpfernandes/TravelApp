using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class Stop
    {
        public int ID { get; set; }
        public int Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Order { get; set; }
    }
}
