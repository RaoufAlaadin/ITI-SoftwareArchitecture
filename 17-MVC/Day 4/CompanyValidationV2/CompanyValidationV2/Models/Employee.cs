using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyValidationV2.Models
{
    public enum GenderType
    {
        Male,
        Female

    }

    public class Employee
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; } = "Ahmed";

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 50 characters")]
        public string Username { get; set; } = "user123";

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
        public string Password { get; set; } = "password123";

        [Required(ErrorMessage = "Gender is required")]
        [EnumDataType(typeof(GenderType), ErrorMessage = "Invalid gender")]
        public GenderType Gender { get; set; } = GenderType.Male;

        [Required(ErrorMessage = "Salary is required")]
        [Range(1, 1000000, ErrorMessage = "Salary must be between 1 and 1000000")]
        public decimal Salary { get; set; } = 0.00M;

        [Required(ErrorMessage = "Join date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "example@example.com";

        [Required(ErrorMessage = "Confirm email is required")]
        [Compare("Email", ErrorMessage = "Email and Confirm email must match")]
        [DataType(DataType.EmailAddress)]
        //[NotMapped] // to not add it to the Database. 
        public string ConfirmEmail { get; set; } = "example@example.com";

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; } = "1234567890";
    }
}