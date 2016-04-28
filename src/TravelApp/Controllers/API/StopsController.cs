using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelApp.Models;
using AutoMapper;
using TravelApp.ViewModels;
using TravelApp.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Controllers.API
{
    [Route("api/[controller]/{tripName}")]
    public class StopsController : Controller
    {
        TripsRepository db = new TripsRepository();
        CoordinateService coordService = new CoordinateService();
        // GET: /<controller>/
        [HttpGet]
        public JsonResult Get(string tripname)
        {
            //To change
            var stops = db.GetStops(tripname);
            var results = Mapper.Map<IEnumerable<TripViewModel>>(stops);
            return Json(stops);
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody]TripViewModel stop)
        {
            var newStop = Mapper.Map<Stop>(stop);
            var longlat = await coordService.Lookup(newStop.Name);
            if (longlat.Success) {
                db.AddStop(newStop);
            }
            return Json(newStop);
        }

        public IActionResult Index()
        {   
            return View();
        }
    }
}
