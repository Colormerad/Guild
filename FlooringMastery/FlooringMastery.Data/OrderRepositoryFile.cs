using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FlooringMastery.Data
{
    public class OrderRepositoryFile : IOrderRepository

    {
        string orderPath = @"C:\Data\Orders_";
        char delimiter = ',';
        

        public Order Create(Order order)
        {
            List<Order> orders = Load(order.orderDate);
            if (orders.Count == 0)
            {
                order.OrderNumber = 1;         
            }
            else
            {
                order.OrderNumber = ((from o in orders
                                     select o.OrderNumber).Max() + 1);
            }
                
            orders.Add(order);
            Save(order.orderDate, orders);
            return order;

        }

        public Order Delete(DateTime orderDate, int orderNumber)
        {
            List<Order> orders = Load(orderDate);
            orders.RemoveAll(o => o.OrderNumber == orderNumber);
            Save(orderDate, orders);
            Order order = new Order();
            return order;
            
        }

        private List<Order> Load(DateTime orderDate)
        {
            string strDate = orderDate.ToString("MMddyyyy");

            string Path = orderPath + strDate;
            List<Order> orders = new List<Order>();
            if (!File.Exists(orderPath + strDate + ".txt"))
            {
                File.Create(orderPath + strDate + ".txt").Close();

            }
            using (StreamReader reader = new StreamReader(Path))
            {

                string[] rows = File.ReadAllLines(Path);
                for (int i = 1; i <rows.Length; i++)
                {
                    Order order = new Order();
                    string[] columns = rows[i].Split(delimiter);

                    order.OrderNumber = Convert.ToInt32(columns[0]);
                    order.CustomerName = columns[1];
                    order.State = columns[2];
                    order.TaxRate = Convert.ToDecimal(columns[3]);
                    order.ProductType = columns[4];
                    order.Area = Convert.ToDecimal(columns[5]);
                    order.CostPerSqareFoot = Convert.ToDecimal(columns[6]);
                    order.LaborCostPerSquareFoot = Convert.ToDecimal(columns[7]);
                    order.MaterialCost = Convert.ToDecimal(columns[8]);
                    order.LaborCost = Convert.ToDecimal(columns[9]);
                    order.Tax = Convert.ToDecimal(columns[10]);
                    order.Total = Convert.ToDecimal(columns[11]);
                    orders.Add(order);       
               
                }
            }

            return orders;
            
        }

        public List<Order> ReadAllByDate(DateTime orderDate)
        {
            
            List<Order> orders = Load(orderDate);
            return orders;
            
        }

        public Order ReadById(DateTime orderDate, int orderNumber)
        {
            Order order = new Order();
            List<Order> orders = Load(orderDate);
            order = orders.Where(x => x.OrderNumber == orderNumber).FirstOrDefault();
            return order;
          
        }

              
        private void Save(DateTime orderDate, List<Order> orders)
        {
            string strDate = orderDate.ToString("MMddyyyy");
            Load(orderDate);
            if (!File.Exists(orderPath + strDate + ".txt"))
            {
                File.Create(orderPath + strDate + ".txt").Close();
            }

            using (StreamWriter writer = new StreamWriter(orderPath + strDate + ".txt"))
            {
                writer.WriteLine("Order Number,Customer Name,State,Tax Rate,Product Type,Area,Cost Per Square Foot,Labor Cost Per Square Foot,Material Cost,Labor Cost,Tax,Total");
                foreach (var o in orders)
                {
                    string _order = convertToTextLine(o);
                    writer.WriteLine(_order);
                }
            }
        }
        private string convertToTextLine(Order order)
        {
            string textLine = order.OrderNumber.ToString() + "," + order.CustomerName + "," + order.State + "," + order.TaxRate.ToString() + "," + order.ProductType + "," + order.Area.ToString() + "," + order.CostPerSqareFoot.ToString() + "," + order.LaborCostPerSquareFoot.ToString() + "," + order.MaterialCost.ToString() + "," + order.LaborCost.ToString() + "," + order.Tax.ToString() + "," + order.Total.ToString();
            return textLine;
        }

        public Order Update(Order order)
        {
            List<Order> orders = Load(order.orderDate);         
            var oldOrder = orders.Where(x => x.OrderNumber == order.OrderNumber).FirstOrDefault();
            oldOrder.CustomerName = order.CustomerName;
            oldOrder.State = order.State;
            oldOrder.Tax = order.Tax;
            oldOrder.TaxRate = order.TaxRate;
            oldOrder.orderDate = order.orderDate;
            oldOrder.Area = order.Area;
            oldOrder.CostPerSqareFoot = order.CostPerSqareFoot;
            oldOrder.LaborCost = order.LaborCost;
            oldOrder.LaborCostPerSquareFoot = order.LaborCostPerSquareFoot;
            oldOrder.MaterialCost = order.MaterialCost;
            oldOrder.ProductType = order.ProductType;
            oldOrder.Total = order.Total;

            Save(order.orderDate, orders);
            return order;

        }
    }
}
