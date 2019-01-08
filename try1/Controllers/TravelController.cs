using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
            //Получаем данные желаемого маршрута и дня.
            string depStation = "";
            int depStationId = 0;
            string arrStation = "";
            int arrStationId = 0;
            string daySelect = MethodsStruct.DaysMatch(day);

            IEnumerable<Station> depStationQuery = _context.Stations.FromSql<Station>
                ($"select st_id, name from travel.stations where name = {from}").ToList();
            IEnumerable<Station> arrStationQuery = _context.Stations.FromSql<Station>
                ($"select st_id, name from travel.stations where name = {to}").ToList();

            MethodsStruct.GetVal(ref depStation, ref depStationId, depStationQuery);
            MethodsStruct.GetVal(ref arrStation, ref arrStationId, arrStationQuery);

            //Выводим для проверки
            Console.WriteLine($"Departing from {depStation}, depat_id = {depStationId}");
            Console.WriteLine($"Arriving at {arrStation}, arrive_id = {arrStationId}");
            Console.WriteLine($"day = {daySelect}");

            //Формируем список станций, входящих в желаемый маршрут.
            List<int> stationIdList = new List<int>();
            List<string> stationNameList = new List<string>();
            IEnumerable<Station> stationListQuery;

            if (depStationId < arrStationId)
                stationListQuery = _context.Stations.FromSql<Station>($"select st_id, name from travel.stations where st_id >= {depStationId} and st_id <= {arrStationId} order by st_id asc").ToList();
            else if (depStationId > arrStationId)
                stationListQuery = _context.Stations.FromSql<Station>($"select st_id, name from travel.stations where st_id >= {arrStationId} and st_id <= {depStationId} order by st_id desc").ToList();
            else
            {
                Console.WriteLine("Дома сидим!");
                stationListQuery = _context.Stations.FromSql<Station>($"select st_id, name from travel.stations where st_id >= {depStationId} and st_id <= {arrStationId}").ToList();
            }

            foreach (var i in stationListQuery)
            {
                stationNameList.Add(i.Name);
                stationIdList.Add(i.Id);
            }
            Console.WriteLine("List of stations: ");
            foreach (int i in stationIdList)
                Console.WriteLine(i);
            foreach (var i in stationNameList)
                Console.WriteLine(i);

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
