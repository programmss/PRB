using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace directionPacientToEvent
{
    public class Doctor
    {
        [Key]
        [Column("doctor_id")]
        public int Id { get; set; }
        public string fio { get; set; }
        public string phone { get; set;}
        public string specialty { get; set;}
        [Column(TypeName = "DATE")]
        public DateTime birthday { get; set;}
        public double experience { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int? cabinet { get; set; }
    }
}
