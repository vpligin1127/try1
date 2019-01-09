using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try1.Models;
using static System.Environment;



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
            bool flag = true;

            IEnumerable<Station> depStationQuery = _context.Stations.FromSql<Station>
                ($"select st_id, name from travel.stations where name = {from}").ToList();
            IEnumerable<Station> arrStationQuery = _context.Stations.FromSql<Station>
                ($"select st_id, name from travel.stations where name = {to}").ToList();

            MethodsStruct.GetVal(ref depStation, ref depStationId, depStationQuery);
            MethodsStruct.GetVal(ref arrStation, ref arrStationId, arrStationQuery);

            //Выводим для проверки
            Console.WriteLine($"Departing from {depStation}");
            Console.WriteLine($"Arriving at {arrStation}");
            Console.WriteLine($"day = {daySelected}");

      //Формируем список станций, входящих в желаемый маршрут с учетом направления.
            List<int> stationIdList = new List<int>();
            List<string> stationNameList = new List<string>();

            string order = MethodsStruct.OrderQuery(depStationId, arrStationId, ref flag);

            IEnumerable<Station> stationListQuery = _context.Stations.FromSql<Station>
                ($"select st_id, name from travel.stations where st_id >= {Math.Min(depStationId,arrStationId)} and st_id <= {Math.Max(depStationId, arrStationId)} order by st_id "+order).ToList();

            foreach (var i in stationListQuery)
            {
                stationNameList.Add(i.Name);
                stationIdList.Add(i.Id);
            }
           
     //Формируем список маршрутов, доступных в выбранный день.
            IEnumerable<Train> routeDayQuery = _context.Trains.FromSql<Train>
                ($"select * from travel.trains").ToList();
            List<string> routeDayList = new List<string>();

            MethodsStruct.RoutesOnDay(routeDayQuery, day, ref routeDayList);

            if (routeDayList == null)
                flag = false;


    //Для каждого маршрута формируем список станций с учетом направления.
            List<string> resultingRoutes = new List<string>();

            foreach(var selectedRoute in routeDayList)
            {
                string routeDepStation = "";
                int routeDepStationId = 0;
                string routeArrStation = "";
                int routeArrStationId = 0;

     //Выбираем станции и все остальное по маршруту из расписания
                IEnumerable<Route> routeStationsQuery = _context.Routes.FromSql<Route>
                ($"select * from travel.Routes where r_name = {selectedRoute}").ToList();
                foreach (var i in routeStationsQuery)
                {
                    routeDepStation = i.Dep;
                    routeArrStation = i.Arr;
                }
      //Сравниваем со станциями желаемого маршрута
                IEnumerable<Station> routeDepStationQuery = _context.Stations.FromSql<Station>
                    ($"select st_id, name from travel.stations where name = {routeDepStation}").ToList();
                IEnumerable<Station> routeArrStationQuery = _context.Stations.FromSql<Station>
                    ($"select st_id, name from travel.stations where name = {routeArrStation}").ToList();

                MethodsStruct.GetVal(ref routeDepStation, ref routeDepStationId, routeDepStationQuery);
                MethodsStruct.GetVal(ref routeArrStation, ref routeArrStationId, routeArrStationQuery);
      //Проверяем вывод и создаем список станций с учетом направления из расписания
                if (flag)
                    Console.WriteLine($"On {daySelected} route {selectedRoute} goes from {routeDepStation} to {routeArrStation}");


                List<int> routeStationIdList = new List<int>();
                List<string> routeStationNameList = new List<string>();

                string orderForRoute = MethodsStruct.OrderQuery(routeDepStationId, routeArrStationId, ref flag);

                IEnumerable<Station> routeStationListQuery = _context.Stations.FromSql<Station>
                    ($"select st_id, name from travel.stations where st_id >= {Math.Min(routeDepStationId, routeArrStationId)} and st_id <= {Math.Max(routeDepStationId, routeArrStationId)} order by st_id " + orderForRoute).ToList();
                foreach (var i in routeStationListQuery)
                {
                    routeStationNameList.Add(i.Name);
                    routeStationIdList.Add(i.Id);
                }

       //Преобразуем в строки и сравниваем, выбираем, что подходит.
                string stationNameString = string.Join("", stationNameList);
                string routeStationNameString = string.Join("", routeStationNameList);
                if ((routeStationNameString.Length >= stationNameString.Length) && (routeStationNameString.Contains(stationNameString)))
                    resultingRoutes.Add(selectedRoute);
             }
            if (!resultingRoutes.Any())
                flag = false;

            //Проверка вывода
            if (flag)
            {
                Console.WriteLine("Use these routes: ");
                foreach (var i in resultingRoutes)
                    Console.Write(i + " ");
                Console.WriteLine("");
            }


        //Выдаем поезда
            List<int> finalTrainList = new List<int>();
            List<string> finalDepTimeList = new List<string>();
            List<string> finalArrTimeList = new List<string>();

            foreach (var selectResultRoute in resultingRoutes)
            {
                string resRouteDepTime = "";
                string resRouteArrTime = "";
                string resRouteArrStation = "";
                string resRouteDepStation = "";
                int resRouteTrainId = 0;
                int trainNum = 0;
                IEnumerable<Route> resRoutesQuery = _context.Routes.FromSql<Route>
                ($"select * from travel.Routes where r_name = {selectResultRoute}").ToList();
                foreach (var i in resRoutesQuery)
                {
                    resRouteDepTime = i.Dep_time;
                    resRouteArrTime = i.Arr_time;
                    resRouteTrainId = i.Train_id;
                    resRouteArrStation = i.Arr;
                    resRouteDepStation = i.Dep;
                }
                finalDepTimeList.Add(resRouteDepTime);
                finalArrTimeList.Add(resRouteArrTime);
                IEnumerable<Train> resTrainsQuery = _context.Trains.FromSql<Train>
                ($"select * from travel.Trains where tr_id = {resRouteTrainId}").ToList();
                foreach (var i in resTrainsQuery)
                {
                    trainNum = i.Number;
                }
                finalTrainList.Add(trainNum);
                if (flag)
                    Console.WriteLine($"Train #{trainNum} goes from {resRouteDepStation} at {resRouteDepTime} arrives at {resRouteArrStation} at {resRouteArrTime}");
                else Console.WriteLine("No routes found. Try another day.");

            }
            if (!finalTrainList.Any())
                Console.WriteLine("No routes found. Try another day.");

            return await _context.Stations.ToListAsync();
        }

    }
}
