using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal static class Check
    {
        public static void PrintBuyDetails(Buy buy)
        {
            Console.WriteLine("Total buy price = " + buy.TotalPrice + " | Total buy weight = " + buy.TotalWeight);
            Console.WriteLine("All products:");
            Console.WriteLine($"{"Title",10} | {"Price",10} | {"Weight (g)",10}");
            foreach (Product product in buy.Products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
