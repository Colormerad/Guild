using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class InventoryViewModel
    {
        public IEnumerable<Queries.VehicleCondition> vehicles { get; set; }
    }
}