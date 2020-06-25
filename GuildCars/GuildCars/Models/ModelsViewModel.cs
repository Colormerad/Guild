using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class ModelsViewModel : IValidatableObject
    {

        public List<ModelShortView> models { get; set; }
        
        public string modelName { get; set; }
        public string makeId { get; set; }
        public List<SelectListItem> makesList { get; set; }

        public List<SelectListItem> GenerateMakesList(List<Make> makes)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var m in makes)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.MakeId.ToString();
                item.Text = m.MakeName;
                items.Add(item);
            }

            return items;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(modelName))
            {
                errors.Add(new ValidationResult("Please enter a model name",
                    new[] { "modelName" }));
            }

            return errors;

        }
    }
}