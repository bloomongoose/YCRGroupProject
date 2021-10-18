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




        //methods
        public void ProductList()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < InventoryProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {InventoryProducts[i].ToString()}");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }



        public Product NameSelector(string choice)
        {
            Product Purchased = new Product();
            //while (true)
            //{
            foreach (Product p in InventoryProducts)
            {
                if (choice == p.Name)
                {
                    Purchased = p;
                    break;
                }

            }
            //}

            return Purchased;
        }



        public void seeMenu()
        {
            Console.WriteLine($"Select 1 to see the menu, or 2 to complete your purchase.");
            double choice2 = Validator.Validator.GetNumber();
            if (choice2 == 1)
            {
                ProductList();
                SelectorMethod();
            }
            else if (choice2 == 2)
            {

                Console.WriteLine("THANKS!!!");
            }

        }


        public Product numSelector(int result)
        {
            Product Purchased = new Product();
            for (int i = 0; i < InventoryProducts.Count; i++)
            {
                if (result == i + 1)
                {
                    Purchased = InventoryProducts[i];
                    break;

                }

            }
            return Purchased;

        }



        public Product SelectorMethod()
        {
            Product Purchased = new Product();
            bool isNum = true;
            while (true)
            {
                Console.WriteLine("Please enter a product number or product name.");
                string choice = Console.ReadLine();

                isNum = int.TryParse(choice, out int result);

                if (isNum == false)
                {
                    Purchased = NameSelector(choice);
                    if (Purchased.Name == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("That was not a valid input.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (result > 0 && result < 14)
                {
                    Purchased = numSelector(result);
                    break;
                }

                else
                {
                    Console.WriteLine("We do not have that product");

                }
            }

            return Purchased;
        }



        public double GetAmount(Product t)
        {
            double result = 0;

            while (true)
            {
                Console.WriteLine("How many would you like to buy?");
                result = Validator.Validator.GetNumber();

                //0 or lower
                if (result <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You cannot purchase 0 or a negative amount.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //1 or higher
                else
                {
                    Quantity.Add(result);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You bought {result} {t.Name}(s) at ${t.Price}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
            return result;
        }


        public double cartTotal(List<Product> RadeenIsTheMan)
        {
            double subTotal = 0;
            double salesTax = 0.06;
            for (int i = 0; i < Quantity.Count; i++)
            {
                subTotal += RadeenIsTheMan[i].Price * Quantity[i];

            }
            double grandTotal = (subTotal * salesTax) + subTotal;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Subtotal: ${Math.Round(subTotal, 2)} | Sales Tax: {salesTax}% | Grand total: ${Math.Round(grandTotal, 2)}");
            Console.ForegroundColor = ConsoleColor.White;
            return grandTotal;
        }



        public bool getContinue()
        {
            bool iAmLosingMyGodDamnMind = true;
            double result = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter 1 to see the menu. Enter 2 to checkout.");
                    result = double.Parse(Console.ReadLine());
                    if (result == 1)
                    {
                        ProductList();
                        break;
                    }
                    else if (result == 2)
                    {
                        iAmLosingMyGodDamnMind = false;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That was not a valid number. ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That wasn't a number. Try again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return iAmLosingMyGodDamnMind;

        }



        public string askPayment()
        {
            string payment = "";
            while (true)
            {
                Console.WriteLine("How would you like to pay? Cash / Credit / Check");
                payment = Console.ReadLine().ToLower().Trim();
                if (payment == "cash")
                {
                    //go to cash method


                    break;
                }
                else if (payment == "credit")
                {
                    //go to credit method

                    break;
                }
                else if (payment == "check")
                {
                    //go to check method               

                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That's not an acceptable form of payment. Try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return payment;
        }


        public double payByCash(double total)
        {

            double change = 0;
            //tesTotal is a placeholder. Enter user's actual total here
            while (true)
            {
                Console.WriteLine("How much cash would you like to pay with?");
                double cash = Validator.Validator.GetNumber();
                change = cash - total;
                if(cash >= total)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not enough money");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            //Console.WriteLine($"Your change is ${Math.Round(change, 2)}.");
            return change;
        }

        public void payByCredit()
        {
            double cvv = 0;
            Console.WriteLine("Enter your 16 digit credit card number.");
            double ccn = Validator.Validator.GetNumberRange(1000000000000000, 9999999999999999);
            Console.WriteLine("Enter your expiration date in MMYYYY format.");
            double exp = Validator.Validator.GetNumberRange(100000, 999999);
            while (true)
            {
                Console.WriteLine("Enter your 3 digit CVV number (located on the back of your card).");
                cvv = Validator.Validator.GetNumberRange(001, 999);
                if (cvv.ToString().Length != 3)
                {
                    Console.WriteLine("That was not a valid input. Try again.");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine( $"CC#: {ccn} | Exp Date: {exp} | CVV: {cvv} ");
        }
        public void paybyCheck()
        {
            Console.WriteLine("Enter your check number.");
            double check = Validator.Validator.GetNumber();

            Console.WriteLine($"Your check number is {check}.");
        }

        public void DisplayReceipt(List<Product> recieptCart, List<double> quant)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("Thank you for shopping with us! See you soon!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(string.Format($"{"Quantity",-15}{"Item",-15}{"Price",-15}"));
            Console.WriteLine();
            for (int i = 0; i < recieptCart.Count; i++)
            {
                Console.WriteLine(string.Format($"{quant[i],-15}{recieptCart[i].Name,-15}${recieptCart[i].Price.ToString("0.00"),-15}"));
            }
        }
    }
}



