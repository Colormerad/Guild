using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery
{
    public class ConsoleIO
    {
        public int PromptInt (string message)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(message);
                string number = Console.ReadLine();
                if (!int.TryParse(number, out int orderNumber))
                {
                        Console.WriteLine("That's not a valid input.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                }
                return orderNumber;
            }     
        }

        public void DisplayOrderDetails(Order order)
        {
            Console.Clear();
            Console.WriteLine("Customer Name: " + order.CustomerName);
            Console.WriteLine("State: " + order.State);
            Console.WriteLine("Order Number: " + order.OrderNumber);
            Console.WriteLine("Product Type: " + order.ProductType);
            Console.WriteLine("Area: " + order.Area);
            Console.WriteLine("Labor Cost: " + "{0:c}", order.LaborCost);
            Console.WriteLine("Material Cost: " + "{0:c}", order.MaterialCost);
            Console.WriteLine("Tax: " + "{0:c}", order.Tax);
            Console.WriteLine("Total: " + "{0:c}", order.Total);

        }

        public string PromptString(string message, bool isAllowedToBeBlank)
        {
            
            while(true)
            {
                Console.Clear();
                Console.WriteLine(message);
                string X = Console.ReadLine();
                    if (isAllowedToBeBlank == false && string.IsNullOrEmpty(X))
                    {
                        Console.WriteLine("That's not a valid input.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    
                return X;
            }

        }


        public DateTime PromptDateTime(string message)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(message);
                string _orderDate = Console.ReadLine();
                if  (!DateTime.TryParse(_orderDate, out DateTime orderDate))
                {
                        Console.WriteLine("That's not a valid input.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                }
                if(orderDate < DateTime.Now)
                {
                    Console.WriteLine("Orders cannot be in the past.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                return orderDate;
            }
        }

        public decimal PromptDecimal(string message, bool isAllowedToBeBlank)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine(message);
                string _area = Console.ReadLine();
                if (isAllowedToBeBlank == true && _area == "")
                {
                    return -1;
                }
                if (!decimal.TryParse(_area, out decimal Area))
                {
                    Console.WriteLine("That's not a valid input.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;


                }
                if (Area < 100)
                {
                    Console.WriteLine("Minimum order is 100 units");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                return Area;
            }
  
        }
        public void DisplayOrders(List<Order> Orders)
        {
            Console.Clear();
           foreach (Order order in Orders)
            {
                Console.WriteLine("Customer Name: " + order.CustomerName);
                Console.WriteLine("State: " + order.State); 
                Console.WriteLine("Order Number: " + order.OrderNumber);
                Console.WriteLine("Product Type: " + order.ProductType);
                Console.WriteLine("Area: " + order.Area);
                Console.WriteLine("Labor Cost: " + "{0:c}", order.LaborCost);
                Console.WriteLine("Material Cost: " + "{0:c}", order.MaterialCost);
                Console.WriteLine("Tax: " + "{0:c}", order.Tax);
                Console.WriteLine("Total: " + "{0:c}", order.Total);
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine();

            }
        }

        public bool PromptBool(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string _confirm = Console.ReadLine();
                bool confirm;
                switch (_confirm.ToUpper())
                {
                    case "Y":
                        confirm = true;
                        break;
                    case "N":
                        confirm = false;
                        break;
                    default:
                        Console.WriteLine("That is not a valid input");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        continue;
                }
                return confirm;
            }
        }
    }
}
