using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STDem0.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }
        [Required(ErrorMessage = "*")]
     
        public string DeptName { get; set; }
        [Required(ErrorMessage = "*")]
        public int Capacity { get; set; }
        [Required]
        public bool Status { get; set; }
        public virtual List<Student> Students { get; set; } = new List<Student>();
        public override string ToString()
        {
            return $"{DeptId} : {DeptName} : {Capacity}";
        }
    }
}
