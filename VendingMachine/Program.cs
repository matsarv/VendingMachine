using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // true = Display products before VendingMachine
            bool showProducts = false;

            LoadVendingMachine1(showProducts);
        }

        /// <summary>
        /// Loading VendinMachine with products
        /// </summary>
        private static void LoadVendingMachine1(bool showProducts)
        {
            // Name, Price, Size
            Product mars = new Snack("Mars", 12, 2);
            Product daim = new Snack("Daim", 10, 2);
            Product negerboll = new Snack("Pigall", 15, 1);

            // Name, Price, Size
            Product heineken = new Beer("Heineken", 5, 1, 33);
            Product pripps = new Beer("Pripps", 15, 1, 45);
            Product mariestad = new Beer("Mariestad", 18, 1, 45);

            // Name, Price, Size, Flavor
            Product blend = new Cigarette("Blend", 45, 20, "Mint");
            Product prins = new Cigarette("Prins", 48, 20);
            Product marlboro = new Cigarette("Marlboro", 48, 20);
            Product marlborolight = new Cigarette("Marlboro Light", 25, 10);

            List<Product> product = new List<Product>
            {
                mars, daim, negerboll,
                heineken, pripps, mariestad,
                blend, prins, marlboro,marlborolight
            };

            if (showProducts)
            {
                foreach (var item in product)
                {
                    Console.WriteLine(item);
                }
                DisplayColorLine("\nPress any key to continue...", ConsoleColor.White);
                Console.ReadKey();
                VendingMachine1 products = new VendingMachine1(product);
            }
            else
            {
                VendingMachine1 products = new VendingMachine1(product);
            }
        }


        /// <summary>
        /// Display message line with color
        /// </summary>
        public static void DisplayColorLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Ask user for input string
        /// </summary>
        public static string AskUserForX(string x)
        {
            string input = "";

            while (input.Length == 0)
            {
                Console.Write(x); //Ask for text with input string
                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// Ask user for input number and handle exeptions
        /// </summary>
        public static int AskUserForNumberX(string x)
        {
            int number = 0;
            bool noNumber = true;
            while (noNumber)
            {
                try
                {
                    number = Convert.ToInt32(AskUserForX(x)); // Ask for number with string
                    noNumber = false;
                }
                catch (Exception)
                {
                    DisplayColorLine("Not a number. Please try again.", ConsoleColor.Red);

                }
            }

            return number;
        }
    }
}
