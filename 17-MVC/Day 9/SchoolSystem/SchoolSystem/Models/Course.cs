using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public enum Topic
    {
        Math,
        Science,
        History,
        Literature
    }

    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Topic Topic { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public int Grade { get; set; }

        #region relation with Trainee // a course is only taken by 1 trainene, weird but yeah

        /* The relation should have been M:M with trainee , but this is easier
         It's not logical... but easier...
        
         edit : I made it M:M 
        */
        public ICollection<TraineeCourse>? TraineeCourses { get; set; }


        #endregion
    }
}
