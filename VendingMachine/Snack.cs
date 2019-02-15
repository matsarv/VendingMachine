using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Snack : Product
    {

        //Constructor
        public Snack(string name, double price, int quantity) : base(name, price, quantity)
        {

        }

        // Constructor
        public override void ConsumeProduct()
        {
            Console.WriteLine("Eat your snack");
        }

    }
}