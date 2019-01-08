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


    }



}
