using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Cigarette: Product
    {
        // Fileds
        readonly string flavor;

        // Properties
        public string Flavor { get; set; }

        // Constructor
        public Cigarette(string name, int price, int quantity, string flavor = "") : base(name,price,quantity)
        {
            this.Flavor = flavor;
           
        }

        // Method
        public override void BuyProduct()
        {
            Program.DisplayColorLine("\nYou selected a "  + Name + " and the Money Deposit will be reduced by " + Price + " kr", ConsoleColor.Green);
        }

        // Method
        public override void ConsumeProduct()
        {
            Program.DisplayColorLine("\nSmoke your cigarette", ConsoleColor.Green);
        }
    }
}
