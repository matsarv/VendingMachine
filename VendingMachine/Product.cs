using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    abstract class Product
    {
        // Fileds
        static int countid = 0;

        // Properties
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Id { get; private set; }

        // Constructor
        public Product(string name, int price, int quantity)
        {
            Id = ++countid;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        // Method
        public override string ToString()
        {
            return Id + ": " + Name + " (" + Quantity + ")  - " + Price + " kr";
        }

        //Method
        public abstract void BuyProduct();

        // Method
        public abstract void ConsumeProduct();
        

    }
}
