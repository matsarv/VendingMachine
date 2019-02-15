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
        public Cigarette(string name, double price, int quantity, string flavor = "") : base(name,price,quantity)
        {
            this.Flavor = flavor;
           
        }

        // Override
        public override void ConsumeProduct()
        {
            Console.WriteLine("Smoke your cig");
        }
    }
}
