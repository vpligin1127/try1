using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace try1.Models
{
    [Table("Routes", Schema = "Travel")]
    public class Route
    {
        [Key]
        [Column("r_id")]
        public int R_id { get; set; }
        [Column("r_name")]
        public string RName { get; set; }
        [Column("dep")]
        public string Dep { get; set; }
        [Column("arr")]
        public string Arr { get; set; }
        [Column("dep_time")]
        public string Dep_time { get; set; }
        [Column("arr_time")]
        public string Arr_time { get; set; }
        [ForeignKey("Trains.tr_id")]
        [Column("train_id")]
        public int Train_id { get; set; }
    }
}
