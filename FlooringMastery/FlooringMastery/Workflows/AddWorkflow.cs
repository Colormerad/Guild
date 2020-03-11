using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Workflows
{
    public class AddWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            OrderManager orderManager = OrderManagerFactory.Create();
            ConsoleIO consoleIO = new ConsoleIO();
            Order order = new Order();
            bool confirmAdd;
            bool isAllowedToBeBlank;



            order.CustomerName = consoleIO.PromptString("Enter customer Name", false);
            order.orderDate = consoleIO.PromptDateTime("Enter order date");
            while(true)
            {
                order.State = consoleIO.PromptString("Enter state abbreviation", false).ToUpper();
                StateLookupResponse stateResponse = orderManager.LookupState(order);
                if(!stateResponse.Success)
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
            
            while(true)
            {
                order.ProductType = consoleIO.PromptString("Enter product type", false).ToUpper();
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
            
            order.Area = consoleIO.PromptDecimal("Enter flooring area", false);
            Console.Clear();
            Console.WriteLine("Customer Name: " + order.CustomerName);
            Console.WriteLine("Order date: " + order.orderDate);
            Console.WriteLine("State: " + order.State);
            Console.WriteLine("Product Type: " + order.ProductType);
            Console.WriteLine("Area: " + order.Area);
            confirmAdd = consoleIO.PromptBool("Would you like to add this order? Y/N");
            if (confirmAdd == true)
            {
                AddOrderResponse response = orderManager.AddOrder(order);
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
