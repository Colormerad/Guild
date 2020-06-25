using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class SearchOrdersQuery
    {
        public DateTime MinOrderDate { get; set; }
        public DateTime MaxOrderDate { get; set; }
        public string UserName { get; set; }
    }
}
