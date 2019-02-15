using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add menu if time exist
            bool showProducts = false;

            LoadVendingMachine1(showProducts);
        }

        /// <summary>
        /// Load VendinMachine with Products, true = display products
        /// </summary>
        private static void LoadVendingMachine1(bool showProducts)
        {
            Product mars = new Snack("Mars Bar", 12, 2);
            Product daijm = new Snack("Daijm", 10, 2);
            Product negerboll = new Snack("Negerboll", 15, 1);

            Product heineken = new Beer("Heineken", 5, 1, 33);
            Product pripps = new Beer("Pripps", 15, 1, 45);
            Product mariestad = new Beer("Mariestad", 18, 1, 45);

            Product blend = new Cigarette("Blend", 45, 20, "Mint");
            Product prins = new Cigarette("Prins", 48, 20);
            Product marlboro = new Cigarette("Marlboro", 48, 20);
            Product marlborolight = new Cigarette("Marlboro Light", 25, 10);

            List<Product> product = new List<Product>
            {
                mars, daijm, negerboll,
                heineken, pripps, mariestad,
                blend, prins, marlboro,marlborolight
            };

            if (showProducts)
            {
                foreach (var item in product)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Press any key to continue...");
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
