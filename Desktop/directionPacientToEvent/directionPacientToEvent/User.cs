using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace directionPacientToEvent
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }
        public string fio { get; set; }
        public int passport { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime birthday { get; set; }
        public string sex { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        [Column("place_work")]
        public string placeWork { get; set; }
        [Column(TypeName = "MEDIUMBLOB")]
        public byte[] photo { get; set; }
    }
}
