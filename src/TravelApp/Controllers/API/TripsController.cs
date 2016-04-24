using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AutoMapper;
using System.Collections;
using TravelApp.ViewModels;
using TravelApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Controllers.API
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        TripsRepository db = new TripsRepository();
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            //To change
            var trips = db.GetAllTrips();
            var results = Mapper.Map < IEnumerable< TripViewModel >> (trips);

            return Json(trips);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return db.GetTrip(id).ToString();
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]TripViewModel trip)
        {
            
            var newTrip = Mapper.Map<Trip>(trip);
            newTrip.UserName = "Hello";
            db.SaveTrip(newTrip);
            return Json(newTrip);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
