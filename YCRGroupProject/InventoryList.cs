using System;
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
        List<double> Quantity = new List<double>();

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
                    
                    double amount = GetAmount(p.Name);

                    double itemTotal = amount * p.Price;
                    Console.WriteLine($"You bought {amount} {p.Name} for ${p.Price}, for a total of ${Math.Round(itemTotal)}!");
                    break;
                }
            }
            Console.WriteLine($"Select 1 to see the menu, or 2 to complete your purchase.");
            double choice2 = Validator.Validator.GetNumber();
            if (choice2 == 1)
            {
                ProductList();
            }
            else if (choice2 == 2)
            {
                cartTotal();
                //method for completing purchase
                Console.WriteLine("THANKS!!!");
            }
            //bool addProduct = Validator.Validator.GetContinue("Would you like to purchase another product? y/n");

            //if (addProduct == true)
            //{
            //    bool seeMenu = Validator.Validator.GetContinue("Would you like to see the menu? y/n");
            //    if (seeMenu == true)
            //    {
            //        ProductList();
            //    }
            //    else if (seeMenu == false)
            //    {
            //        SelectorMethod();
            //    }
            //}
        }
        public void NumberSelector(int result)
        {
            for (int i = 0; i < InventoryProducts.Count; i++)
            {
                if (result == i + 1)
                {
                    Cart.Add(InventoryProducts[i]);
                    double amount = GetAmount(InventoryProducts[i].Name);
                    
                    double itemTotal = amount * InventoryProducts[i].Price;
                    Console.WriteLine($"You bought {amount} {InventoryProducts[i].Name} for ${InventoryProducts[i].Price} each! For a total of ${Math.Round(itemTotal)}");
                    break;
                }
            }
            Console.WriteLine($"Select 1 to see the menu, or 2 to complete your purchase.");
            double choice = Validator.Validator.GetNumber();

            if (choice == 1)
            {
                ProductList();
            }
            else if (choice == 2)
            {
                cartTotal();
                //method for completing purchase
                Console.WriteLine("THANKS!!!");
            }

            //bool addProduct = Validator.Validator.GetContinue("Would you like to purchase another product? y/n");
            //if (addProduct == true)
            //{
            //    bool seeMenu = Validator.Validator.GetContinue("Would you like to see the menu or complete your purchase?");
            //    if (seeMenu == true)
            //    {
            //        ProductList();
            //    }
            //}
        }
        public void SelectorMethod()
        {
            bool isNum = true;
            Console.WriteLine("Please enter a product number or product name.");
            string choice = Console.ReadLine();

            isNum = int.TryParse(choice, out int result);

            if (isNum == false)
            {
                NameSelector(choice);
            }

            else if (result > 0 && result < 14)
            {
                NumberSelector(result);
            }
            else if (result == 15)
            {
                ProductList();
            }
            else if (result == 16)
            {
                //add checkout method (items, subtotal,sales tax, total) 
                //then into payment method
                //then into receipt

            }

            else
            {
                Console.WriteLine("We do not have that product");
            }
        }
        public double GetAmount(string name)
        {
            double result = 0;
            while (true)
            {
                Console.WriteLine("How many would you like to buy?");
                result = double.Parse(Console.ReadLine());
                Quantity.Add(result);
                //0 or lower
                if (result <= 0)
                {
                    Console.WriteLine("You cannot purchase 0 or a negative amount.");
                }
                //1 or higher
                else
                {
                    break;
                }
            }
            return result;
        }
        public void cartTotal()
        {
            double subTotal = 0;
            double salesTax = 0.06;
            for (int i = 0; i < Cart.Count; i++)
            {
                subTotal = Quantity[i] * Cart[i].Price;

            }
            double grandTotal = (subTotal * salesTax) + subTotal;

            Console.WriteLine($"Subtotal: ${Math.Round(subTotal, 2)} | Sales Tax: {salesTax}% | Grand total: ${Math.Round(grandTotal, 2)}");
        }

        public void getContinue()
        {
            while (true)
            {
                double choice = Validator.Validator.GetNumber();
                if (choice == 1)
                {
                    ProductList();
                    SelectorMethod();
                }
                else if (choice == 2)
                {
                    //method for completing purchase
                    cartTotal();
                    Console.WriteLine("THANKS!!!");
                }
            }
        }

    }
}
