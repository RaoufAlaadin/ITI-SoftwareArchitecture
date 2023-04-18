using System.ComponentModel.DataAnnotations;

namespace D01Cars.Validators
{
    public class DateInPast : ValidationAttribute
    {
        public override bool IsValid(object? value) =>

            value is DateTime date && date < DateTime.Now;
        
    }
}
