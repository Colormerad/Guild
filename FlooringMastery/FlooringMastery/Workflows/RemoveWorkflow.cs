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
    public class RemoveWorkflow
    {
        public void Execute()
        {
            int orderNumber;
            DateTime orderDate;
            bool confirmDelete;
            Order order = new Order();
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
                Console.WriteLine("The order could not be found");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            confirmDelete = consoleIO.PromptBool("Are you sure you want to remove order " + orderNumber + " on " + orderDate.ToString("MM/dd/yyyy") + "? Y/N");
            if (confirmDelete == true)
            {
                RemoveOrderResponse removeOrderResponse = orderManager.RemoveOrder(orderDate, orderNumber);
                Console.WriteLine("Order Cancelled.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
            else
                return;
        }
    }
}
