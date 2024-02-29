using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fillPhotoInDB
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int Id { set; get; }
        public string fio { set; get;}

        public int passport { set; get;}
        [Column(TypeName = "Date")]
        public DateTime birthday { set; get;}
        public string sex { set; get;}
        public string address { set; get;}
        public string phone { set; get;}
        public string email { set; get;}
        [Column(TypeName = "MEDIUMBLOB")]
        public byte[] photo { set; get;}
    }
}
