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
            string daySelected = MethodsStruct.DaysMatch(day);

            IEnumerable<Station> depStationQuery = _context.Stations.FromSql<Station>
                ($"select st_id, name from travel.stations where name = {from}").ToList();
            IEnumerable<Station> arrStationQuery = _context.Stations.FromSql<Station>
                ($"select st_id, name from travel.stations where name = {to}").ToList();

            MethodsStruct.GetVal(ref depStation, ref depStationId, depStationQuery);
            MethodsStruct.GetVal(ref arrStation, ref arrStationId, arrStationQuery);

            //Выводим для проверки
            Console.WriteLine($"Departing from {depStation}, depat_id = {depStationId}");
            Console.WriteLine($"Arriving at {arrStation}, arrive_id = {arrStationId}");
            Console.WriteLine($"day = {daySelected}");

            //Формируем список станций, входящих в желаемый маршрут с учетом направления.
            List<int> stationIdList = new List<int>();
            List<string> stationNameList = new List<string>();
            string order = "asc";
            if (depStationId < arrStationId)
                order = "asc";
            else if (depStationId > arrStationId)
                order = "desc";
            else
            {
                Console.WriteLine("Дома сидим!");
            }
            IEnumerable<Station> stationListQuery = _context.Stations.FromSql<Station>($"select st_id, name from travel.stations where st_id >= {Math.Min(depStationId,arrStationId)} and st_id <= {Math.Max(depStationId, arrStationId)} order by st_id "+order).ToList();

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

            //Формируем список маршрутов, доступных в выбранный день.
            IEnumerable<Train> routeDayQuery = _context.Trains.FromSql<Train>
                ($"select * from travel.trains").ToList();
            List<string> routeDayList = new List<string>();

            MethodsStruct.RoutesOnDay(routeDayQuery, day, ref routeDayList);

            Console.WriteLine("List of routes: ");
            foreach (var i in routeDayList)
                Console.WriteLine(i);

            //Для каждого маршрута формируем список станций
            foreach(var selectedRoute in routeDayList)
            {
                string routeDepStation;
                string routeArrStation;
                IEnumerable<Route> routeStationsQuery = _context.Routes.FromSql<Route>
                ($"select * from travel.Routes").ToList();
                foreach (var i in routeStationsQuery)
                {
                    routeDepStation = i.Dep;
                    routeArrStation = i.Arr;
                }



            }

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

            //1234
            return await _context.Stations.ToListAsync();
        }

    }
}
