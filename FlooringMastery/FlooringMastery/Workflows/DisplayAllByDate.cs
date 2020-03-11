using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Workflows
{
    public class DisplayAllByDate
    {
        public void Execute()
        {
            Console.Clear();
            OrderManager orderManager = OrderManagerFactory.Create();
            ConsoleIO consoleIO = new ConsoleIO();
            Console.WriteLine("Enter a date");
            string _orderDate = Console.ReadLine();
            DateTime orderDate = DateTime.Parse(_orderDate);

            

            OrdersLookupResponse response = orderManager.LookupOrders(orderDate);

            if (response.Success)
            {
                consoleIO.DisplayOrders(response.Orders); 
            }
            else
            {
                Console.WriteLine("An error has occured: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
