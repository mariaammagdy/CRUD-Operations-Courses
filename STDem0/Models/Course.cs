using System.ComponentModel.DataAnnotations;

namespace STDem0.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(30, 60)]
        public int Duration { get; set; }
        public override string ToString()
        {
            return $"{Id} : {Name} : {Duration}";
        }

    }
}
