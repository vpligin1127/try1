using System;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;


namespace try1.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
           optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=rootradical;database=Travel;");

        }
    }
}
