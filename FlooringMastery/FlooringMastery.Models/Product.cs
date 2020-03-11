using System;
using System.Collections.Generic;
using System.Text;

namespace FlooringMastery.Models
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostPerSqareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
    }
}
