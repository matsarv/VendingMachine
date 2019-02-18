using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class VendingMachine1
    {

        public VendingMachine1(List<Product> product)
        {
            // Fileds
            char keyPress = 'x';
            bool keepAlive = true;
            int moneyDeposited = 0;

            Console.ForegroundColor = ConsoleColor.White;

            while (keepAlive)
            {
                Console.Clear();
                Console.Write("::: Welcome to the Vending Machine :::\n\n");
                if (moneyDeposited > 0)
                {
                    Program.DisplayColorLine("MONEY DEPOSIT: " + moneyDeposited, ConsoleColor.Green);
                }
                else
                {
                    Program.DisplayColorLine("MONEY DEPOSIT: " + moneyDeposited, ConsoleColor.Red);
                }

                Console.Write("\n" +
                    " (S)nack\n" +
                    " (B)eer\n" +
                    " (C)igarette\n" +
                    " \n" +
                    " (I)nsert money\n" +
                    " (F)inish\n" +
                    "\n"
                    );

                if (moneyDeposited < 1)
                {
                    Program.DisplayColorLine("Please inset money or show the products", ConsoleColor.White);
                }
                else
                {
                    Program.DisplayColorLine("Please buy a product", ConsoleColor.White);
                }

                if (keyPress.Equals('i') || keyPress.Equals('f') || keyPress.Equals('s') || keyPress.Equals('b') || keyPress.Equals('c'))
                { }
                else
                {
                    keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                }


                switch (keyPress)
                {
                    case 's':
                        Program.DisplayColorLine("\nSNACK", ConsoleColor.Yellow);
                        DisplayProducts(product, "snack");


                        if (moneyDeposited < 1)
                        {
                            Program.DisplayColorLine("\nYou need to insert money before buying a product", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            moneyDeposited = ByProduct(product, moneyDeposited);
                            keyPress = 'x';
                            //Console.ReadKey();
                        }

                        break;

                    case 'b':
                        Program.DisplayColorLine("\nBEER", ConsoleColor.Yellow);
                        DisplayProducts(product, "beer");

                        if (moneyDeposited < 1)
                        {
                            Program.DisplayColorLine("\nYou need to insert money before buying a product", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            // Add BuyProduct() 
                            moneyDeposited = ByProduct(product, moneyDeposited);
                            keyPress = 'x';
                        }
                        break;

                    case 'c':
                        Program.DisplayColorLine("\nCIGARETTE", ConsoleColor.Yellow);
                        DisplayProducts(product, "cigarette");

                        if (moneyDeposited < 1)
                        {
                            Program.DisplayColorLine("\nYou need to insert money before buying a product", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            moneyDeposited = ByProduct(product, moneyDeposited);
                            keyPress = 'x';
                        }
                        break;

                    case 'i':
                        MoneyDeposit money = new MoneyDeposit(moneyDeposited);

                        foreach (var item in money.MoneyPool)
                        {
                            moneyDeposited = moneyDeposited + item;
                        }

                        keyPress = 'x';

                        break;

                    case 'f':

                        GoodBye(moneyDeposited);
                        keepAlive = false; // Exit program

                        break;

                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Function to buy a product and return money left in Money Deposit
        /// </summary>
        static int ByProduct(List<Product> product, int moneyDeposited)
        {
            bool notFound = true;
            string message = "";

            Program.DisplayColorLine("\nPlease select a number for by product", ConsoleColor.Yellow);

            int selected = Program.AskUserForNumberX("");

            foreach (Product item in product)
            {
                if (item.Id == selected) // if found
                {
                    if (item.Price <= moneyDeposited)
                    {
                        moneyDeposited = moneyDeposited - item.Price;

                        item.BuyProduct();
                        item.ConsumeProduct();
                        
                        Program.DisplayColorLine("\nPress any key to continue...", ConsoleColor.White);
                        notFound = false;
                        break;
                    }
                    else
                    {
                        Program.DisplayColorLine("\nYou don't have enough money \n Please insert more money", ConsoleColor.Red);
                        Program.DisplayColorLine("\nPress any key to continue...", ConsoleColor.White);
                        notFound = false;
                    }
                }
            }

            if (notFound)
            {
                Program.DisplayColorLine("\nNo product with that number was found", ConsoleColor.Red);
                Program.DisplayColorLine("\nPress any key to continue...", ConsoleColor.White);
            }
            //else
            //{
            //    Console.WriteLine("Product with Id: " + selected);

            //}

            
            Console.ReadKey();
            return moneyDeposited;

        }

        /// <summary>
        /// Give money back and ending the Vending Machine
        /// </summary>
        static void GoodBye(int moneyDeposited)
        {
            // Use MoneyDeposit instead
            int[] currency = new int[10] { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

            //Console.WriteLine(moneyDeposited);
            Program.DisplayColorLine("\nRemaining money in Money Deposit: " + moneyDeposited + " kr.\n", ConsoleColor.Green);
            if (!moneyDeposited.Equals(0))
            {
                Console.WriteLine("Your change will be:\n");

                foreach (int money in currency)
                {
                    int change = moneyDeposited / money;

                    if (change >= 1)
                    {
                        moneyDeposited = moneyDeposited - (change * money);
                    }
                    if (!change.Equals(0))
                    {
                        Console.WriteLine(" " + change + " st - " + money + " kr.");
                    }
                }
            }
            Program.DisplayColorLine("\nHave a nice day!", ConsoleColor.Yellow);
            Console.ReadKey();
        }


        /// <summary>
        /// Display product list dependig on type
        /// </summary>
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

    }
}
