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
        public Beer(string name, double price, int quantity, int size) : base(name, price, quantity)
        {
            this.Size = size;
        }

        // Override
        public override void ConsumeProduct()
        {
            Console.WriteLine("Drink your beer");
        }

    }


}

