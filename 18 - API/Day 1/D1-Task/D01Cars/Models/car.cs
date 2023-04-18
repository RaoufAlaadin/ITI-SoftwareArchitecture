using D01Cars.Validators;
using System.ComponentModel.DataAnnotations;

namespace D01Cars.Models
{
    public class car
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Enter Ur Name"), MaxLength(20)]
        public string? Name { get; set;}
        [Required]
        public string? Model { get; set;}
        [DateInPast]
        public DateTime OpenDate { get; set; }

        //[RegularExpression("^(Electrical|Gas|Diesel)$")]
        public string? Type { get; set; }

        public static int counter = 0;
    }
}
