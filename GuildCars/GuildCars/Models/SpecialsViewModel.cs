using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class SpecialsViewModel : IValidatableObject
    {
        public List<Specials> specials { get; set; }
        public Specials special { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(special.SpecialName))
            {
                errors.Add(new ValidationResult("Please enter a Title",
                    new[] { "special.SpecialName" }));
            }
            if (string.IsNullOrEmpty(special.SpecialDescription))
            {
                errors.Add(new ValidationResult("Please enter a Description",
                    new[] { "special.SpecialDescription" }));
            }
            

            return errors;

        }
    }
}