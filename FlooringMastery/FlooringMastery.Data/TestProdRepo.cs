using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlooringMastery.Data
{
    public class TestProdRepo : IProductRepository

    {
        public List<Product> ReadAll()
        {
            string path = @"C:\Data\Products.txt";
            char delimiter = ',';
            List<Product> products = new List<Product>();

            using (StreamReader reader = new StreamReader(path))
            {
                string[] rows = File.ReadAllLines(path);
                for (int i = 1; i < rows.Length; i++)
                {
                    Product product = new Product();
                    string[] columns = rows[i].Split(delimiter);

                    product.ProductType = columns[0];
                    product.CostPerSqareFoot = Convert.ToDecimal(columns[1]);
                    product.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);
                    products.Add(product);
                }
                return products;
            }
        }

        public Product ReadByProductType(Order order)
        {
            Product product = new Product();
            while (true)
            {
                List<Product> products = ReadAll();
                product = products.Where(x => x.ProductType.ToUpper() == order.ProductType).FirstOrDefault();
                return product;
            }

        }
    }
}
