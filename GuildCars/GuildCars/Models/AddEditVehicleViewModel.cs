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
    public class AddEditVehicleViewModel :IValidatableObject
    {
        public List<SelectListItem> bodyStylesList { get; set; }
        public List<SelectListItem> GenerateBodyStylesList(List<BodyStyle> bodystyles)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var m in bodystyles)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.BodyStyleId.ToString();
                item.Text = m.BodyStyleName;
                items.Add(item);
            }

            return items;
        }
        public List<SelectListItem> exteriorColorsList { get; set; }
        public List<SelectListItem> GenerateExteriorColorList(List<ExteriorColor> exteriorColors)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var m in exteriorColors)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.ExteriorColorId.ToString();
                item.Text = m.ExteriorColorName;
                items.Add(item);
            }

            return items;
        }

        public List<SelectListItem> interiorColorsList { get; set; }
        public List<SelectListItem> GenerateInteriorColorList(List<InteriorColor> interiorColors)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var m in interiorColors)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.InteriorColorId.ToString();
                item.Text = m.InteriorColorName;
                items.Add(item);
            }

            return items;
        }
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
        public List<SelectListItem> newUsedsList { get; set; }
        public List<SelectListItem> GenerateNewUsedList(List<NewUsed> newUseds)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var m in newUseds)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.NewUsedId.ToString();
                item.Text = m.NewUsedName;
                items.Add(item);
            }

            return items;
        }
        public List<SelectListItem> transmissionsList { get; set; }
        public List<SelectListItem> GenerateTransmissionsList(List<Transmission> transmissions)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var m in transmissions)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.TransmissionId.ToString();
                item.Text = m.TransmissionName;
                items.Add(item);
            }

            return items;
        }
        public Vehicles vehicle { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(vehicle.Description))
            {
                errors.Add(new ValidationResult("Please enter a vehicle description",
                    new[] { "vehicle.Description" }));
            }
            if (vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("Please enter a valid MSRP",
                    new[] { "vehicle.MSRP" }));
            }
            if (vehicle.SalePrice <= 0)
            {
                errors.Add(new ValidationResult("Please enter a valid Sale Price",
                    new[] { "vehicle.SalePrice" }));
            }
            if (string.IsNullOrEmpty(vehicle.VIN))
            {
                errors.Add(new ValidationResult("Please enter a VIN #",
                    new[] { "vehicle.VIN" }));
            }
            if(vehicle.NewUsedId == 1)
            {
                if((vehicle.Mileage > 100) || (vehicle.Mileage < 0))
                {
                    errors.Add(new ValidationResult("Please enter mileage between 1 & 100",
                    new[] { "vehicle.Mileage" }));
                }
            }
            if (vehicle.NewUsedId == 2)
            {
                if (vehicle.Mileage < 101)
                {
                    errors.Add(new ValidationResult("Please enter mileage greater than 101",
                    new[] { "vehicle.Mileage" }));
                }
            }
            if (vehicle.Year > 2021 && vehicle.Year < 1818)
            {
                errors.Add(new ValidationResult("Please enter a valid year between 1818 & 2021",
                    new[] { "vehicle.Year" }));
            }

            return errors;

        }
    }
}