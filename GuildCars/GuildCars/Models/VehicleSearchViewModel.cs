using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class VehicleSearchViewModel
    {
        public List<VehicleDetails> vehicles { get; set; }
        public SearchCarsQuery search { get; set; }
    }
}