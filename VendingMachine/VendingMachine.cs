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
                    Program.DisplayColorLine("MONEY DEPOSIT: " + moneyDeposited, ConsoleColor.Yellow);
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
                    Program.DisplayColorLine("Welcome. Please inset some money.", ConsoleColor.White);
                }
                else
                {
                    Program.DisplayColorLine("Please buy a product.", ConsoleColor.White);
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
                            Program.DisplayColorLine("\nYou need to insert money before buying a product.", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            // Goto  BuyProduct() ?
                            Program.DisplayColorLine("\n" +
                                "\n1 Check if enough money" +
                                "\n2 Reduce money to MoneyBank (-price)" +
                                "\n3 Buy selected prouduct" +
                                "\n4 Display message (Eat your...)" +
                                "\n5 Return to start" +
                                "", ConsoleColor.Yellow);
                            keyPress = 'x';
                            Console.ReadKey();
                        }

                        break;

                    case 'b':
                        Program.DisplayColorLine("\nBEER", ConsoleColor.Yellow);
                        DisplayProducts(product, "beer");

                        if (moneyDeposited < 1)
                        {
                            Program.DisplayColorLine("\nYou need to insert money before buying a product.", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            // Add BuyProduct() 
                            Program.DisplayColorLine("\nPlease select a number for by product.", ConsoleColor.Yellow);
                            keyPress = 'x';
                            Console.ReadKey();
                        }
                        break;

                    case 'c':
                        Program.DisplayColorLine("\nCIGARETTE", ConsoleColor.Yellow);
                        DisplayProducts(product, "cigarette");


                        if (moneyDeposited < 1)
                        {
                            Program.DisplayColorLine("\nYou need to insert money before buying a product.", ConsoleColor.Red);
                            keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                        }
                        else
                        {
                            // Add BuyProduct() 
                            Program.DisplayColorLine("\nPlease select a number for by product", ConsoleColor.Yellow);
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

                        GoodBye(moneyDeposited);
                        keepAlive = false; // Exit program

                        break;

                    default:
                        //Program.DisplayColorLine("Wrong input", ConsoleColor.Red);
                        //Console.ReadKey();
                        break;
                }

            }
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


        //static void PrintMoneyPool(int money)
        //{

        //}

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
