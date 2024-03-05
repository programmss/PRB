using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsTest2024.Models
{
	public class User
	{
		[Key]
		[Column("user_id")]
		public int User_ID { get; set; }

		public string FIO { get; set; }

		public double Balance { get; set; }
	}
}
