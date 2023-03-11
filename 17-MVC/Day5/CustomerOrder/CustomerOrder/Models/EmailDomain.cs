using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerOrder.Models
{
        /*--It's server-side validation.
         it's Error shows first because it gets checked before the insideCode.

        -- It's currently only working on server-side, I guess there is something missing in the 
        create.cshtml
         */
    public class EmailDomain :ValidationAttribute
    {
        List<string> _allowedDomains; 

        public EmailDomain(string[] allowedDomains) { _allowedDomains = allowedDomains.ToList();}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value is string email)
            {
                var domain = email.Split('@')[1];

                foreach (var singleDomain in _allowedDomains)
                {
                    if (domain.Equals(singleDomain, StringComparison.OrdinalIgnoreCase))
                    {
                        return ValidationResult.Success;

                    }

                }
               
            }

            return new ValidationResult($"The email domain must be gmail.com or yahoo.com .");

        }
    }
}