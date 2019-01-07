﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("api/stations")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly StationContext _context;
        public StationsController(StationContext context)
        {
            _context = context;
        }

        //GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Station>>> GetStations(string from, string to) 
        {
            //Console.WriteLine($"{from}...{to}");
            IEnumerable<Station> st1 = _context.Stations.ToList();
            foreach(var row in st1)
            {
                Console.WriteLine("Station: " + row.Id);
            }

            IEnumerable<Station> name1 = _context.Stations.FromSql<Station>("select st_id, name from stations where st_id = 5").ToList();
             foreach(var i in name1)
             {
                Console.WriteLine("selected; " + i.Name);
             }

            return await _context.Stations.ToListAsync();
        }



    }
}
