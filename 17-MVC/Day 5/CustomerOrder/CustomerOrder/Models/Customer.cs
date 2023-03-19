using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerOrder.Models
{
    public class Customer
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [EnumDataType(typeof(GenderType), ErrorMessage = "Invalid gender")]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [EmailDomain(new string[]{ "gmail.com" , "yahoo.com"})]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid PhoneNumber format")]
        public string PhoneNum { get; set; }
        

        // Set as virtual to activate lazyLoading
        public virtual ICollection<Order> Orders { get; set; }

    }

    public enum GenderType
    {
        Male,
        Female
    }





}