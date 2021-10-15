﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YCRGroupProject
{
    class InventoryList
    {
        //Store Inventory
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

        //Cart for customer
        List<Product> Cart = new List<Product>();

        public void ProductList()
        {
            for (int i = 0; i < InventoryProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {InventoryProducts[i].ToString()}");
            }

        }

        //methods
        public void NameSelector(string choice)
        {
            
                                     
                foreach (Product p in InventoryProducts)
                {
                    if (choice == p.Name)
                    {
                        Cart.Add(p);
                        Console.WriteLine($"You bought a {p.Name} for {p.Price}!");
                        break;
                    }

                }
                
                bool addProduct = Validator.Validator.GetContinue("Would you like to purchase another product? y/n");
                //if (addProduct == false)
                //{
                    
                //}
                if (addProduct == true)
                {
                    bool seeMenu = Validator.Validator.GetContinue("Would you like to see the menu? y/n");
                    if (seeMenu == true)
                    {
                        ProductList();
                    }

                }


            

        }
        public void SelectorMethod()
        {
            bool isNum = true;
            Console.WriteLine("Please enter a product number");
            string choice = Console.ReadLine();
            isNum = int.TryParse(choice, out int result);

            if (isNum == false)
            {
                
                NameSelector(choice);
                
            }

            else if (result > 0 && result < 14)
            {

            }

            else
            {

                Console.WriteLine("We do not have that product");
            }

            

        }



    }


}
