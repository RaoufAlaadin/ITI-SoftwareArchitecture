using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClientName { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}