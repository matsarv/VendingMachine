using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Snack : Product
    {
        // Fileds
        string quantityName = "";

        //Constructor
        public Snack(string name, int price, int quantity) : base(name, price, quantity)
        {
            this.Name = name;

        }

        // Method
        public override void BuyProduct()
        {
            if (Quantity.Equals(1))
            {
                quantityName = "Single";
            }
            else
            {
                quantityName = "Double";
            }

            Program.DisplayColorLine("\nYou selected a " + quantityName + " " + Name + " and the Money Deposit will be reduced by " + Price + " kr", ConsoleColor.Green);

        }

        // Method
        public override void ConsumeProduct()
        {
            Program.DisplayColorLine("\nEat your snack", ConsoleColor.Green);
        }

    }
}