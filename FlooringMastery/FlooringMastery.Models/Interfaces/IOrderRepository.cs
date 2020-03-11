using System;
using System.Collections.Generic;
using System.Text;

namespace FlooringMastery.Models.Interfaces
{
   public interface IOrderRepository
    {
        
        Order Create(Order order);

        List<Order> ReadAllByDate(DateTime orderDate);

        Order ReadById(DateTime orderDate, int orderId);

        Order Update(Order orderDate);

        Order Delete(DateTime orderDate, int orderNumber);

        
    }
}
