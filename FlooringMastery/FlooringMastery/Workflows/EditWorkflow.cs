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
    public class EditWorkflow
    {
        public void Execute()
        {
            int orderNumber;
            DateTime orderDate;
            bool confirmEdit;
            Order order = new Order();
            bool isAllowedToBeBlank;
            Console.Clear();
            OrderManager orderManager = OrderManagerFactory.Create();
            ConsoleIO consoleIO = new ConsoleIO();
            orderDate = consoleIO.PromptDateTime("Enter a date:");
            
            orderNumber = consoleIO.PromptInt("Enter the order number:");
            OrderLookupResponse response = orderManager.LookupOrder(orderDate, orderNumber);

            if (response.Success)
            {
                consoleIO.DisplayOrderDetails(response.Order);
                order = response.Order;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The order could not be found");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            string newCustomerName = consoleIO.PromptString($"Enter updated customer name. The current name is: {order.CustomerName}", true);
            if (newCustomerName != "")
            {
                order.CustomerName = newCustomerName;
            }

            order.orderDate = orderDate;
            while (true)
            {
                string newState = consoleIO.PromptString("Enter state abbreviation. Current State is:" + order.State, true).ToUpper();
                if (newState != "")
                {
                    order.State = newState;
                }
                
                StateLookupResponse stateResponse = orderManager.LookupState(order);
                if (!stateResponse.Success)
                {
                    Console.WriteLine(stateResponse.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;

                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                string newProductType =  consoleIO.PromptString("Enter new product type. Current product type is: " + order.ProductType , true).ToUpper();
                if (newProductType != "")
                {
                    order.ProductType = newProductType;
                }
          
                ProductLookupResponse productResponse = orderManager.LookupProduct(order);

                if (!productResponse.Success)
                {
                    Console.WriteLine(productResponse.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    break;
                }
            }
            decimal newArea = consoleIO.PromptDecimal("Enter updated flooring area. Current flooring area is:" + order.Area, true); 
            if (newArea != -1)
            {
                order.Area = newArea;
            }

            order.OrderNumber = orderNumber;
            EditOrderResponse EditResponse = orderManager.EditOrder(order);

            if (response.Success)
            {
                consoleIO.DisplayOrderDetails(EditResponse.Order);
                Console.WriteLine("Order Updated.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("An error has occured: ");
                Console.WriteLine(EditResponse.Message);
            }
            Console.Clear();
            Console.WriteLine("Customer Name: " + order.CustomerName);
            Console.WriteLine("Order date: " + order.orderDate);
            Console.WriteLine("State: " + order.State);
            Console.WriteLine("Product Type: " + order.ProductType);
            Console.WriteLine("Area: " + order.Area);
            confirmEdit = consoleIO.PromptBool("Would you like to add this order? Y/N");
            if (confirmEdit == true)
            {
                EditOrderResponse _response = orderManager.EditOrder(order);
                if (response.Success)
                {
                    consoleIO.DisplayOrderDetails(response.Order);
                }
                else
                {
                    Console.WriteLine("An error has occured: ");
                    Console.WriteLine(response.Message);
                }

                Console.WriteLine("Order Added.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();


            }
            else
                return;


        }
    }
}
