using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class MoneyDeposit
    {
        public int moneyDeposited;
        bool state;
        int[] currency = new int[10] { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

        public List<int> MoneyPool { get; set; }

        public MoneyDeposit() { }

        public MoneyDeposit(int moneyDeposited)
        {
            this.moneyDeposited = moneyDeposited;
            bool keepAlive = true;

            MoneyPool = new List<int>();

            while (keepAlive)
            {
                try
                {

                    Program.DisplayColorLine("Total ammount: " + moneyDeposited, ConsoleColor.Yellow);

                    int input = Program.AskUserForNumberX(" Insert (1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr, 1000kr and 0 = Back to menu): ");


                    if (input.Equals(0))
                    {

                        keepAlive = false;
                    }
                    else
                    {
                        state = ValidateMoney(input);
                        if (state.Equals(true))
                        {
                            moneyDeposited = moneyDeposited + input;  // to method?
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
        }


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
