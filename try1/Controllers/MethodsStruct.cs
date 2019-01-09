using System;
using System.Collections.Generic;

namespace try1.Controllers
{


    public struct MethodsStruct
    {
        //Сопоставление номера дня со столбиками таблицы
        public static string DaysMatch(int a)
        {
            string daySelect = "";
            switch (a)
            {
                case 1:
                    daySelect = "Mon";
                    break;
                case 2:
                    daySelect = "Tue";
                    break;
                case 3:
                    daySelect = "Wed";
                    break;
                case 4:
                    daySelect = "Thu";
                    break;
                case 5:
                    daySelect = "Fri";
                    break;
                case 6:
                    daySelect = "Sat";
                    break;
                case 7:
                    daySelect = "Sun";
                    break;
            }
            return daySelect;
        }

        //Получение номеров станций и их имен из таблицы Stations
        public static void GetVal(ref string a, ref int b, IEnumerable<try1.Models.Station> statData)
        {
            a = "";
            b = 0;
            foreach (var i in statData)
            {
                a = i.Name;
                b = i.Id;
            }

        }

        //Выбор столбца таблицы машрутов в зависимости от дня.
        public static void RoutesOnDay(IEnumerable<try1.Models.Train> queryList, int dayInput, ref List<string> routesList)
        {
            switch(dayInput)
            {
                case 1:
                    foreach (var i in queryList)
                        if (i.Mon != null) routesList.Add(i.Mon);
                    break;
                case 2:
                    foreach (var i in queryList)
                        if (i.Tue != null) routesList.Add(i.Tue);
                    break;
                case 3:
                    foreach (var i in queryList)
                        if (i.Wed != null) routesList.Add(i.Wed);
                    break;
                case 4:
                    foreach (var i in queryList)
                        if (i.Thu != null) routesList.Add(i.Thu);
                    break;
                case 5:
                    foreach (var i in queryList)
                        if (i.Fri != null) routesList?.Add(i.Fri);
                    break;
                case 6:
                    foreach (var i in queryList)
                        if (i.Sat != null) routesList.Add(i.Sat);
                    break;
                case 7:
                    foreach (var i in queryList)
                        if (i.Sun != null) routesList.Add(i.Sun);
                    break;

            }
        }

        public static string OrderQuery(int fromId, int toId)
        {
            string order = "asc";
            if (fromId < toId)
                order = "asc";
            else if (fromId > toId)
                order = "desc";
            else Console.WriteLine("Дома сидим!");
            return order;
        }


    }



}
