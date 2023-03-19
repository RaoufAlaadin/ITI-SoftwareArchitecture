using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Track
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }


        // This will help us in the generated controllers and views I think 
        public  ICollection<Trainee>? Trainees { get; set; }
    }
}
