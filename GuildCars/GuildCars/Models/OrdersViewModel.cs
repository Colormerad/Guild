using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class OrdersViewModel : IValidatableObject
    {
        public VehicleDetails vehicleDetail { get; set; }
        public Orders order { get; set; }
        public List<SelectListItem> PurchaseTypeList { get; set; }
        public List<SelectListItem> GeneratePurchaseTypeList(List<PurchaseType> purchaseTypes)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var m in purchaseTypes)
            {
                SelectListItem item = new SelectListItem();
                item.Value = m.PurchaseTypeId.ToString();
                item.Text = m.PurchaseTypeName;
                items.Add(item);
            }

            return items;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(order.CustomerPhone))
            {
                errors.Add(new ValidationResult("Please enter the customer's phone number.",
                    new[] { "order.CustomerPhone" }));
            }
            if (string.IsNullOrEmpty(order.CustomerEmail))
            {
                errors.Add(new ValidationResult("Please enter the customer's email.",
                    new[] { "order.CustomerEmail" }));
            }
            if (!string.IsNullOrEmpty(order.CustomerEmail))
            {
                try
                {
                    MailAddress mailAddress = new MailAddress(order.CustomerEmail);
                }
                catch (Exception)
                {
                    errors.Add(new ValidationResult("Please enter Valid email address.",
                    new[] { "order.CustomerEmail" }));
                }
            }
            if (!string.IsNullOrEmpty(order.CustomerPhone))
            {
                if(Regex.Match(order.CustomerPhone, @"^(\+[0-9]{9})$").Success)
                {

                }
            }
            if((order.CustomerZipcode).ToString().Length != 5)
            {
                errors.Add(new ValidationResult("Please enter Valid Zipcode.",
                    new[] { "order.CustomerZipcode" }));
            }

            if((order.OrderTotal * .95) < vehicleDetail.SalePrice)
            {
                errors.Add(new ValidationResult("The order total cannot be more than 5% discounted.",
                    new[] { "order.OrderTotal" }));
            }
            if(order.OrderTotal > vehicleDetail.MSRP)
            {
                errors.Add(new ValidationResult("The order total cannot be more than MSRP.",
                    new[] { "order.OrderTotal" }));
            }
            if (string.IsNullOrEmpty(order.CustomerName) )
            {
                errors.Add(new ValidationResult("Please enter the customer's name.",
                    new[] { "order.CustomerName" }));
            }
            if (string.IsNullOrEmpty(order.CustomerStreet1))
            {
                errors.Add(new ValidationResult("Please enter the customer's address.",
                    new[] { "order.CustomerStreet1" }));
            }
            if (string.IsNullOrEmpty(order.CustomerState))
            {
                errors.Add(new ValidationResult("Please enter the customer's state.",
                    new[] { "order.CustomerState" }));
            }
            if (string.IsNullOrEmpty(order.CustomerCity))
            {
                errors.Add(new ValidationResult("Please enter the customer's city.",
                    new[] { "order.CustomerCity" }));
            }


            return errors;

        }
    }
}

