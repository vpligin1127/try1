using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try1.Models;
//using System.Data.Entity;


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
        public async Task<ActionResult<IEnumerable<Station>>> GetStations(string from, string to) 
        {
            //Console.WriteLine($"{from}...{to}");
            IEnumerable<Station> st1 = _context.Stations.ToList();
            foreach(var row in st1)
            {
                Console.WriteLine("Station: " + row.Id);
            }

            IEnumerable<Station> statlow = _context.Stations.FromSql<Station>($"select st_id, name from travel.stations where name = {from}").ToList();
            IEnumerable<Station> stathigh = _context.Stations.FromSql<Station>($"select st_id, name from travel.stations where name = {to}").ToList();
            foreach (var i in statlow)
            {
                Console.WriteLine("low = " + i.Id);
            }


            foreach (var i in stathigh)
            {
                Console.WriteLine("high = " + i.Id);
            }

            IEnumerable<Train> tr1 = _context.Trains.ToList();
            foreach (var row in tr1)
            {
                Console.WriteLine("Train: " + row.Number);
            }
            /*
            IEnumerable<Station> name1 = _context.Stations.FromSql<Station>("select st_id, name from stations where st_id = 5").ToList();
             foreach(var i in name1)
             {
                Console.WriteLine("selected; " + i.Name);
             }
             */
            return await _context.Stations.ToListAsync();
        }
        /*
        [Route("api/trains")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Train>>> GetTrains()
        {
            IEnumerable<Train> tr1 = _context.Trains.ToList();
            foreach (var row in tr1)
            {
                Console.WriteLine("Train: " + row.Number);
            }
            return await _context.Trains.ToListAsync();

        }
        */


    }
}
