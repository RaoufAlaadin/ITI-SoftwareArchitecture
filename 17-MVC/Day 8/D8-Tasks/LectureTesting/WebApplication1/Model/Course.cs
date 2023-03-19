using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{

    public enum Topic
    {
        Math,
        Science,
        History,
        Literature,
        Art
    }

    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Topic is required")]
        public Topic Topic { get; set; }

        [Range(0, 100, ErrorMessage = "Course Grade must be between 0 and 100")]
        public double CourseGrade { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        // Enable lazy loading
        public virtual Student Student { get; set; }
    }
}
