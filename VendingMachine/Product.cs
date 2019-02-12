using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Product
    {
        // alla produkter i denna lista
        public string Name { get; set; }
        List<string> Products { get; set; }
        
        public Product()
        {
            //Product new List<Product>();
        }
    }
}
