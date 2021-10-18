using System;
using System.Collections.Generic;
using System.Text;

namespace YCRGroupProject
{

    class Product
    { 
        //properties
        public string Name;
        public string Category;
        public string Description;
        public double Price;

        //constructor
        public Product()
        {
            Name = "";
            Category = "";
            Description = "";
            Price = 0;
        }
        public Product(string name, string category, string description, double price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }

        //methods
        public override string ToString()
        {
            return $"Item : {Name} | Category: {Category} | Description: {Description} | Price: ${Price}";
        }
    }
}
