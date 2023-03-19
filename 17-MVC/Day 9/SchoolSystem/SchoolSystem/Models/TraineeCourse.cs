using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{

    /* IMPORTANT NOTE: 
        * [Composite Keys] can be only created using fluent API
       */
    public class TraineeCourse
    {
        public int TraineeID { get; set; }

      
        public int CourseID { get; set; }

        [StringLength(500, ErrorMessage = "notes cannot be longer than 500 characters")]
        public string notes { get; set; }



        [ForeignKey("TraineeID")]
        public Trainee? Trainee { get; set; }

        [ForeignKey("CourseID")]
        public Course? Course { get; set; }

       
    }
}
