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
        public double Price { get; set; }
        public int Id { get; private set; }

        // Constructor
        public Product(string Name, double Price) { }

        public Product()
        {
            Id = ++countid;
        }

        // Method
        public override string ToString()
        {
            return Id + ": " + Name + " - " + Price + " kr";
        }


        //public static string BuyProduct()
        //{
            
        //    return "";
        //}

        //public static string ConsumeProduct()
        //{
        //    return "";
        //}

    }
}
