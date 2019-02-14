using System;

using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fileds
            char keyPress = 'x';
            bool keepAlive = true;
            int moneyDeposited = 0;

            Product mars = new Snack() { Name = "Mars Bar", Price = 12 };
            Product daijm = new Snack() { Name = "Daijm", Price = 10 };
            Product negerboll = new Snack() { Name = "Negerboll", Price = 15 };

            Product heineken = new Beer() { Name = "Heineken", Price = 5, Size = 33 };
            Product pripps = new Beer() { Name = "Pripps", Price = 15, Size = 45 };
            Product mariestad = new Beer() { Name = "Mariestad", Price = 18, Size = 45 };

            Product blend = new Cigarette() { Name = "Blend", Price = 45 };
            Product prins = new Cigarette() { Name = "Prins", Price = 48 };
            Product marlboro = new Cigarette() { Name = "Marlboro", Price = 48 };

            List<Product> product = new List<Product>
            {
                mars, daijm, negerboll,
                heineken, pripps, mariestad,
                blend, prins, marlboro
            };

            Console.ForegroundColor = ConsoleColor.White;

            while (keepAlive)
            {
                Console.Clear();
                Console.Write("\nWelcome to the Vending Machine?\n");

                DisplayColorLine("Money Deposit: " + moneyDeposited, ConsoleColor.Yellow);

                Console.Write("\n" +
                    " (S)nack\n" +
                    " (B)eer\n" +
                    " (C)igarette\n" +
                    " (I)nsert money\n" +
                    " (F)inish\n" +
                    "\n"
                    );

                if (moneyDeposited < 1)
                {
                    DisplayColorLine("\nMoney Deposit is empty. Please use any menu item above.", ConsoleColor.Red);
                    
                }

                if (keyPress.Equals('i')  || keyPress.Equals('f') || keyPress.Equals('s') || keyPress.Equals('b') || keyPress.Equals('c'))
                { }
                else
                {
                    keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                }


                switch (keyPress)
                {
                    case 's':
                        Console.WriteLine("\nSNACK     ");
                        DisplayProducts(product, "snack");

                        
                        if (moneyDeposited < 1)
                        {
                            DisplayColorLine("\nInsert money to buy a product.", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            // Add BuyProduct() 
                            DisplayColorLine("\nPlease select a number for by product.", ConsoleColor.Yellow);
                            keyPress = 'x';
                            Console.ReadKey();
                        }

                        break;

                    case 'b':
                        Console.WriteLine("\nBEER    ");
                        DisplayProducts(product, "beer");


                        if (moneyDeposited < 1)
                        {
                            DisplayColorLine("\nInsert money to buy a product.", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            // Add BuyProduct() 
                            DisplayColorLine("\nPlease select a number for by product.", ConsoleColor.Yellow);
                            keyPress = 'x';
                            Console.ReadKey();
                        }
                        
                        break;

                    case 'c':
                        Console.WriteLine("\nCIGARETTE");
                        DisplayProducts(product, "cigarette");


                        if (moneyDeposited < 1)
                        {
                            DisplayColorLine("\nInsert money to buy a product.", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            // Add BuyProduct() 
                            DisplayColorLine("\nPlease select a number for by product", ConsoleColor.Yellow);
                            keyPress = 'x';
                            Console.ReadKey();
                        }
                        
                        break;

                    case 'i':
                        // Enter money in Money Deposit
                        MoneyDeposit money = new MoneyDeposit(moneyDeposited);

                        foreach (var item in money.MoneyPool)
                        {
                            moneyDeposited = moneyDeposited + item;
                        }

                        keyPress = 'x';
                        break;

                    case 'f':
                        DisplayColorLine("Goodby phrase and give money in return", ConsoleColor.Yellow);
                        // Add exit Method
                        Console.ReadKey();
                        keepAlive = false; // Exit program
                        break;

                    default:
                        break;
                }
                
            }
        }

        //static void PrintMoneyPool(int money)
        //{

        //}

        static void DisplayProducts(List<Product> product, string type)
        {
            
            foreach (var item in product)
            {
                if (type == "snack")
                {
                    if (item is Snack)
                    {
                        Console.WriteLine("\t" + item);
                    }
                }
                else if (type == "beer")
                {
                    if (item is Beer)
                    {
                        Console.WriteLine("\t" + item);
                    }
                }

                else if (type == "cigarette")
                {
                    if (item is Cigarette)
                    {
                        Console.WriteLine("\t" + item);
                    }
                }

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
