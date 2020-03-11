using System;
using System.Collections.Generic;
using System.Text;

namespace FlooringMastery.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> ReadAll();
        Product ReadByProductType (Order order);
    }
}
