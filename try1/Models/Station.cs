using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace try1.Models
{
    [Table("Stations")]
    public class Station
    {
        [Column("st_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
