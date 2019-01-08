using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace try1.Models
{
    [Table("Trains", Schema = "Travel")]
    public class Train
    {
        [Key]
        [Column("tr_id")]
        public int Tr_id { get; set; }
        [Column("tr_num")]
        public int Number { get; set; }
        [Column("Mon")]
        public string Mon { get; set; }
        [Column("Tue")]
        public string Tue { get; set; }
        [Column("Wed")]
        public string Wed { get; set; }
        [Column("Thu")]
        public string Thu { get; set; }
        [Column("Fri")]
        public string Fri { get; set; }
        [Column("Sat")]
        public string Sat { get; set; }
        [Column("Sun")]
        public string Sun { get; set; }
    }
}
