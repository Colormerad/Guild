using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Queries.FeaturedVehicle> featuredVehicles { get; set; }
        public List<Specials> specials { get; set; }
    }
}