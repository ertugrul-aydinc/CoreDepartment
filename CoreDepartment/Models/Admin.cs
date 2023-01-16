using System.ComponentModel.DataAnnotations;

namespace CoreDepartment.Models
{
	public class Admin
	{
		public int Id { get; set; }
		[StringLength(20)]
		public string Username { get; set; }
		[StringLength(10)]
		public string Password { get; set; }
	}
}
