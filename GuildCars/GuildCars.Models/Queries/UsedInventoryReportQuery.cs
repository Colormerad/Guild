using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class UsedInventoryReportQuery
    {
        public int Total { get; set; }
        public int Count { get; set; }
        public int Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string NewUsedName { get; set; }
    }
}
