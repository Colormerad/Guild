using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicles
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
        public int NewUsedId { get; set; }
        public int BodyStyleId { get; set; }
        public int InteriorColorId { get; set; }
        public int ExteriorColorId { get; set; }
        public int TransmissionId { get; set; }
        public string ImageFileName { get; set; }
        public DateTime DateAdded { get; set; }
        public bool HasBeenSold { get; set; }
        public bool IsFeatured { get; set; }

    }
}
