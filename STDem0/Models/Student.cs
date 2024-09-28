using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using STDem0.ValidationAttributes;

namespace STDem0.Models
{
    [Index("Email", IsUnique = true)]
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(10, 30)]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        public string Email { get; set; }
        [Required, StringLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [MyValidation("Password", ErrorMessage = "Passwords do not match.")]
        public string CPassword { get; set; }
        [ForeignKey("Department")]
        public int DeptNo { get; set; }
        public virtual Department Department { get; set; }
        public override string ToString()
        {
            return $"{Id} : {Name} : {Age} : {DeptNo}";
        }
    }
}
