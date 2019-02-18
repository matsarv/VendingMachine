using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Beer : Product
    {

        // Field
        readonly int size;
        readonly string flavor;

        // Properties
        public int Size { get; set; }
        public string Flavour { get; set; }

        // Constructor
        public Beer(string name, int price, int quantity, int size) : base(name, price, quantity)
        {
            this.Size = size;
        }

        // Method
        public override void BuyProduct()
        {
            Program.DisplayColorLine("\nYou selected a " + Name + " and the Money Deposit will be reduced by " + Price + " kr", ConsoleColor.Green);
        }

        // Method
        public override void ConsumeProduct()
        {
            Program.DisplayColorLine("\nDrink your beer", ConsoleColor.Green);
        }

    }


}

