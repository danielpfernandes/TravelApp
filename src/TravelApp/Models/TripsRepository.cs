using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class TripsRepository
    {
        TripContext db = new TripContext();

        public IEnumerable<Trip> GetAllTrips() {
            return db.Trips.OrderBy(t => t.Name).ToList();
        }

        public IEnumerable<Trip> GetTrip(int Id) {
            return db.Trips.OrderBy(t => t.Name).Where(t => t.Id == Id).ToList();
        }

        public IEnumerable<Stop> GetStops(string Name) {
            return db.Stops.OrderBy(t => t.Order).Where(t => t.Name == Name).ToList();
        }

        public void SaveTrip(Trip newTrip) {
            db.Add(newTrip);
            db.SaveChanges();
        }

        public void AddStop(Stop newStop) {
            db.Stops.Add(newStop);
            db.SaveChanges();
        }

    }
}
