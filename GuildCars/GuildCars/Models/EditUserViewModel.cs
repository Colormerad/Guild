using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GuildCars.Models
{
    public class EditUserViewModel : IValidatableObject
    {
        public ApplicationUser user { get; set; }
        public List<SelectListItem> rolelist { get; set; }
        public string RoleId { get; set; }
        public string currentRole { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public List<SelectListItem> GenerateIdentityRolesList(List<IdentityRole> roles)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var m in roles)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.Id;
                item.Text = m.Name;
                items.Add(item);
            }

            return items;
        }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(user.FirstName))
            {
                errors.Add(new ValidationResult("Please enter a first name",
                    new[] { "user.FirstName" }));
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                errors.Add(new ValidationResult("Please enter a last name",
                    new[] { "user.LastName" }));
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                errors.Add(new ValidationResult("Please enter an email",
                    new[] { "user.Email" }));
            }

            return errors;
        }
    }
}