using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace MovieActor.Model
{

    public enum Gender
    {
        Male,
        Female
    }

    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public double Salary { get; set; }

        // Foreign key for Movie 
        public int MovieId { get; set; }

        // Navigation property for Movie 
        [ForeignKey("MovieId")]
        public virtual Movie? Movie { get; set; }
    }
}