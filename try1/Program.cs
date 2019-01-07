using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using try1.Models;

namespace try1
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();




            /*
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureCreated();

                Station St1 = new Station { Id = 7, Name = "E" };
                //User user2 = new User { Name = "Alice", Age = 26 };

                db.Stations.Add(St1);

                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                var stations = db.Stations.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Station u in stations)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
            }
            Console.Read();



        }
        */

    }
}
