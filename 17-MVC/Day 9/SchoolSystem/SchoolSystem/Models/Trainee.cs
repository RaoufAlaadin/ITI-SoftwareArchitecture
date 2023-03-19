using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Collections.Generic;

namespace SchoolSystem.Models
{

    public enum Gender
    {
        Male,
        Female
    }

    public class Trainee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string MobileNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        #region Relation with Course and track
        public int TrackID { get; set; }

        [ForeignKey("TrackID")]
        public  Track? Track { get; set; }

        public   ICollection<TraineeCourse>? TraineeCourses { get; set; }

        #endregion
    }
}