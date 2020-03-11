using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Workflows
{
    public class DisplayById
    {
        public void Execute()
        {
            int orderNumber;
            DateTime orderDate; 
            Console.Clear();
            OrderManager orderManager = OrderManagerFactory.Create();
            ConsoleIO consoleIO = new ConsoleIO();
            orderDate = consoleIO.PromptDateTime("Enter a date:");

            orderNumber = consoleIO.PromptInt("Enter the order number:");

            OrderLookupResponse response = orderManager.LookupOrder(orderDate, orderNumber);

            if (response.Success)
            {
                consoleIO.DisplayOrderDetails(response.Order);
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
