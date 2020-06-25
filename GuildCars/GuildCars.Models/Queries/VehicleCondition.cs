using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleCondition
    {
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public string ImageFileName { get; set; }
        public int SalePrice { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string  NewUsed { get; set; }
    }
}
