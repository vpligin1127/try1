using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace try1.Models
{
    [Table("Stations", Schema = "Travel")]
    public class Station
    {
        [Key]
        [Column("st_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
