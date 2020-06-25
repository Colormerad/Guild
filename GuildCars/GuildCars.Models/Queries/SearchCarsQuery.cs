using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class SearchCarsQuery
    {
        public string SearchField { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public int YearMin { get; set; }
        public int YearMax { get; set; }

        public string Condition { get; set; }
    }
}
