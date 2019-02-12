using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class MoneyDeposit
    {
        public int insertedMoney { get; set; }
        public List<int> MoneyPool { get; set; }

        int[] currency = new int[10] { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

        bool state;
        
        public MoneyDeposit() { }

        public MoneyDeposit(int insertedMoney)
        {
            this.insertedMoney = insertedMoney;
            bool keepAlive = true;

            MoneyPool = new List<int>();

            while (keepAlive)
            {
                try
                {
                    Console.Clear();
                    Console.Write("\nWelcome to the Vending Machine?\n");
                    Console.WriteLine("\n::::::::::::::Show all product::::::::::::::\n");
                    Program.DisplayColorLine("Inserted money: " + insertedMoney, ConsoleColor.Yellow);

                    int input = Program.AskUserForNumberX("\nInsert money (1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr, 1000kr and -1 = Go Back): ");

                    if (input.Equals(-1))
                    {
                        keepAlive = false;
                    }
                    else
                    {
                        state = ValidateMoney(input);
                        if (state.Equals(true))
                        {
                            insertedMoney = insertedMoney + input;  // to method?
                        }
                        else
                        {
                            Program.DisplayColorLine("Use only valid value of money!", ConsoleColor.Red);
                            Console.ReadKey();
                        }
                    }
                }
                catch (Exception)
                {
                    Program.DisplayColorLine("Wrong input", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }

            Console.Clear();
        }

        // Return Money 

        /// <summary>
        /// Validate inserted money against valid money
        /// </summary>
        /// <returns>true is valid money</returns>
        public bool ValidateMoney(int checkMoney)
        {
            foreach (var item in currency)
            {
                if (item.Equals(checkMoney))
                {
                    MoneyPool.Add(checkMoney);
                    return true;
                }
            }

            return false;
        }

    }
}
