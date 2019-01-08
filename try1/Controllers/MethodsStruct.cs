using System;
using System.Collections.Generic;

namespace try1.Controllers
{


    public struct MethodsStruct
    {
        public static string Days_match(int a)
        {
            string day_select = "";
            switch (a)
            {
                case 1:
                    day_select = "Mon";
                    break;
                case 2:
                    day_select = "Tue";
                    break;
                case 3:
                    day_select = "Wed";
                    break;
                case 4:
                    day_select = "Thu";
                    break;
                case 5:
                    day_select = "Fri";
                    break;
                case 6:
                    day_select = "Sat";
                    break;
                case 7:
                    day_select = "Sun";
                    break;
            }
            return day_select;
        }

        public static void GetVal(ref string a, ref int b, IEnumerable<try1.Models.Station> StatData)
        {
            a = "";
            b = 0;
            foreach (var i in StatData)
            {
                a = i.Name;
                b = i.Id;
            }

        }

    }



}
