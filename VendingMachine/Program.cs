using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            char keyPress;
            bool keepAlive = true;
            int insertedMoney = 0;

            Console.ForegroundColor = ConsoleColor.White;



            while (keepAlive)
            {
                Console.Clear();

                Console.Write("\nWelcome to the Vending Machine?\n");
                Console.WriteLine("\n::::::::::::::Show all product::::::::::::::\n");

                Program.DisplayColorLine("Inserted money: " + insertedMoney, ConsoleColor.Yellow);

                Console.Write("\n" +
                    "(I)nsert money\n" +
                    "(B)y products\n" +
                    "(C)ancel\n"
                    );


                keyPress = char.ToLower(Console.ReadKey(true).KeyChar);
                switch (keyPress)
                {
                    case 'i':
                        MoneyDeposit money = new MoneyDeposit(insertedMoney);
                        foreach (var item in money.MoneyPool) // To method?
                        {
                            insertedMoney = insertedMoney + item;
                        }
                        break;
                    case 'b':
                        break;
                    case 'c':
                        break;
                    default:
                        break;
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
