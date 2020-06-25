using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models 
{
    public class SalesReportQueryViewModel : IValidatableObject
    {
        public List<SalesReport> reports {get; set;}
        public SearchOrdersQuery search { get; set;}
        public List<SelectListItem> reportsList { get; set; }
        public string Id { get; set; }


        public List<SelectListItem> GenerateUsersList(List<ApplicationUser> users)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem blank = new SelectListItem();
            blank.Value = null;
            blank.Text = "all";
            items.Add(blank);
            foreach (var m in users)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.Id.ToString();
                item.Text = m.UserName;
                items.Add(item);
            }
            

            return items;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if(!string.IsNullOrEmpty(search.MinOrderDate.ToString()))
            {
                DateTime temp;
                if (DateTime.TryParse(search.MinOrderDate.ToString(), out temp))
                {

                }
                else
                {
                    errors.Add(new ValidationResult("Please enter a valid date",
                        new[] { "search.MinOrderDate" }));
                }
            }
            if (!string.IsNullOrEmpty(search.MaxOrderDate.ToString()))
            {
                DateTime temp;
                if (DateTime.TryParse(search.MaxOrderDate.ToString(), out temp))
                {

                }
                else
                {
                    errors.Add(new ValidationResult("Please enter a valid date",
                        new[] { "search.MaxOrderDate" }));
                }
            }

            return errors;

        }

    }
}