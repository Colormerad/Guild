using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class ContactUsViewModel   : IValidatableObject
    {

        public ContactUs contactus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(contactus.Name))
            {
                errors.Add(new ValidationResult("Please enter your name",
                    new[] { "contactus.Name" }));
            }
            if (string.IsNullOrEmpty(contactus.Email) && string.IsNullOrEmpty(contactus.Phone))
            {
                errors.Add(new ValidationResult("Please enter your email or phone number",
                    new[] { "contactus.Email" }));
            }
            
            if (string.IsNullOrEmpty(contactus.Message))
            {
                errors.Add(new ValidationResult("Please enter your message",
                    new[] { "contactus.Message" }));
            }
            return errors;

        }
    }

    
}