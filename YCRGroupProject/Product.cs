using System;
using System.Collections.Generic;
using System.Text;

namespace YCRGroupProject
{


    class Product
    {
        public void ProductList()
        {
            List<Product> InventoryProducts = new List<Product>
            {
                new Product("Turtleneck", "Clothing", "It's time to start caring about your neck", 18.99),
                new Product("Pineapple", "Food", "Delicious Fruit", 1.99),
                new Product("Coffee", "Drink", "Dark Roast", .99),
                new Product ("Doritos", "Snack", "Nacho Cheese", 2.99),
                new Product ("Soap", "Home Goods", "Lavender Scent", 2.99),
                new Product ("Gum", "Snacks", "Spearmint", 1.99),
                new Product ("Socks", "Clothing", "For Feet", 3.99),
                new Product ("Sunglasses", "Accessories", "For Style", 4.99),
                new Product ("Mystery Bag", "Miscellaneous Goods" , "Buy At Your Own Risk", 19.99),
                new Product ("Beanie", "Clothing", "Keep your head warm", 5.99),
                new Product ("Taco", "Food", "Who doesn’t love tacos?", 2.99),
                new Product ("Suspenders", "Clothing", "Unleash your inner Terry Crews", 8.99),
                new Product ("Speakers", "Electronics", "For surround sound", 24.99)
            };
            foreach (Product p in InventoryProducts)
            {
                Console.WriteLine(p.ToString());
            }

        }
        //methods
        public override string ToString()
        {
            return $"Item : {Name} | Category: {Category} | Description: {Description} | Price: ${Price}";

        }

        public void DisplayCars()
        {

        }
        //properties
        public string Name;
        public string Category;
        public string Description;
        public double Price;

        //constructors
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


    }
}
