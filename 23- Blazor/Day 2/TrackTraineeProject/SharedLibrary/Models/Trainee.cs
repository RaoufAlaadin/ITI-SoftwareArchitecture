using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Trainee name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Trainee name should be between 3 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Trainee gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Trainee email is required")]
        [RegularExpression(@"^([\w\.\-]+)@(gmail|yahoo)\.com$", ErrorMessage = "Email must be a valid gmail or yahoo address.")]
        public string Email { get; set; } = "RaoufAlaadin97@gmail.com";

        [Required(ErrorMessage = "Trainee mobile number is required")]
        [RegularExpression(@"^(012|010|011|015)\d{8}$", ErrorMessage = "Mobile number must be a valid Egyptian number starting with 012, 010, 011, or 015 and have a total of 11 digits.")]
        public string? MobileNo { get; set; }

        [Required(ErrorMessage = "Trainee birth date is required")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public bool IsGraduated { get; set; }

        [ForeignKey("Track")]
        public int TrackId { get; set; }

        [JsonIgnore]
        public Track? Track { get; set; }
    }


}
