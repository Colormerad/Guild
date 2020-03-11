using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlooringMastery.Data
{
    public class TestRepository : IOrderRepository
    {
        public List<Order> orders = new List<Order>();

        public Order Create(Order order)
        {
            
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
            return order;

        }

        public Order Delete(DateTime orderDate, int orderNumber)
        {

            orders.RemoveAll(o => o.OrderNumber == orderNumber );
            Order order = new Order();
            return order;
        }

        
        public List<Order> ReadAllByDate(DateTime orderDate)
        {
            orders.Where(o => o.orderDate == orderDate);
            return orders;
        }

        public Order ReadById(DateTime orderDate, int orderNumber)
        {
            Order order = new Order();
            order = orders.Where(x => x.OrderNumber == orderNumber).FirstOrDefault();
            return order;
        }

        public Order Update(Order order)
        {
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
            return order;
        }
    }
}
