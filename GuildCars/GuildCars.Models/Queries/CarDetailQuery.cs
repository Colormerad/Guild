using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class CarDetailsQuery
    {
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int MSRP { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int SalePrice { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int TypeId { get; set; }
        public int BodyStyleId { get; set; }
        public int InteriorColorId { get; set; }
        public int ExteriorColorId { get; set; }
        public int TransmissionId { get; set; }
        public string ImageFileName { get; set; }

    }
}
