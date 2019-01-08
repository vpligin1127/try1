using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try1.Models;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace try1.Controllers
{
    //[Route("api/stations")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly TravelContext _context;
        public TravelController(TravelContext context)
        {
            _context = context;
        }

        [Route("api/stations")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Station>>> GetStations(string from, string to, int day) 
        {
            string dep_stat = "";
            int dep_stat_id = 0;
            string arr_stat = "";
            int arr_stat_id = 0;
            string day_select = MethodsStruct.Days_match(day);

            IEnumerable<Station> statlow = _context.Stations.FromSql<Station>($"select st_id, name from travel.stations where name = {from}").ToList();
            IEnumerable<Station> stathigh = _context.Stations.FromSql<Station>($"select st_id, name from travel.stations where name = {to}").ToList();

            MethodsStruct.GetVal(ref dep_stat, ref dep_stat_id, statlow);
            MethodsStruct.GetVal(ref arr_stat, ref arr_stat_id, stathigh);

            Console.WriteLine($"Departing from {dep_stat}, depat_id = {dep_stat_id}");
            Console.WriteLine($"Arriving at {arr_stat}, arrive_id = {arr_stat_id}");
            Console.WriteLine($"day = {day_select}");


            /*
            IEnumerable<Train> tr1 = _context.Trains.ToList();
            foreach (var row in tr1)
            {
                Console.WriteLine("Train: " + row.Number);
            }

            IEnumerable<Route> r1 = _context.Routes.ToList();
            foreach (var row in r1)
            {
                Console.WriteLine("Route: " + row.RName);
            }
            */


            return await _context.Stations.ToListAsync();
        }

    }
}
