using STDem0.ValidationAttributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace STDem0.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		[Required]
		[RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
		public string Email { get; set; }
		[Required, StringLength(15)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[NotMapped]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords do not match.")]
		[MyValidation("Password", ErrorMessage = "Passwords do not match.")]
		public string CPassword { get; set; }
	}
}
