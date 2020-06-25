using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class MakesViewModel : IValidatableObject
    {
        public List<Make> makes { get; set; }
        public Make make { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(make.MakeName))
            {
                errors.Add(new ValidationResult("Please enter a make name",
                    new[] { "make.MakeName" }));
            }
           
            return errors;

        }

    }
}