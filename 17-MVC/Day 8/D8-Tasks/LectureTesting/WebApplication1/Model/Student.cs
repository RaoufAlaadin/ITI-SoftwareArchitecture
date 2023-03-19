using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication1.Model
{
    /* Needed packages are EFCore - tools / sqlserver*/
    public enum Gender
    {
        Male,
        Female
    }

    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNum { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        // lazy loading 
        public virtual ICollection<Course> Courses { get; set; }
    }
}
