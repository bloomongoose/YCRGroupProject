using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace YCRGroupProject
{
    class InventoryList
    {
        //Store Inventory -- rename store items
        List<Product> StoreList = new List<Product>
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
        List<double> Quantity = new List<double>();


        //creating new method run at beginning of code
        public void FileCheck()
        {
            string filepath = @"..\..\..\YCR_Group_Project";
            if (File.Exists(filepath) == false)
            {
                Console.WriteLine("File not found, recreating now.");
                StreamWriter sw = new StreamWriter(filepath);
                foreach(Product pro in StoreList)
                {
                    sw.WriteLine($"{pro.Name},{pro.Category},{pro.Description},{ pro.Price}");

                }
                sw.Close();

            }
            else
            {
                StreamReader sr = new StreamReader(filepath);
                string output = sr.ReadToEnd();
                string[] lines = output.Split('\n');
                List<Product> textDocList = new List<Product>();
                foreach(string line in lines)
                 {  if(line.Length < 1 )
                    {
                        break;
                    }
                    string[] productProps = line.Split(",");
                    Product p = new Product(productProps[0], productProps[1], productProps[2], double.Parse(productProps[3]));
                    textDocList.Add(p);
                    
                                   
                }
                sr.Close();
                StoreList = textDocList;
            }

            

        }







        //methods
        public void ProductList()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < StoreList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {StoreList[i].ToString()}");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        public Product NameSelector(string choice)
        {
            Product Purchased = new Product();

            foreach (Product p in StoreList)
            {
                if (choice == p.Name)
                {
                    Purchased = p;
                    break;
                }
            }
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
            for (int i = 0; i < StoreList.Count; i++)
            {
                if (result == i + 1)
                {
                    Purchased = StoreList[i];
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
            string cvv = "";
            string ccn = "";
            string exp = "";
            while (true)
            {
                Console.WriteLine("Enter your 16 digit credit card number.");
                ccn = Console.ReadLine();
                if (Regex.IsMatch(ccn, @"(^4[0-9]{12}(?:[0-9]{3})?$)|(^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$)|(3[47][0-9]{13})|(^3(?:0[0-5]|[68][0-9])[0-9]{11}$)|(^6(?:011|5[0-9]{2})[0-9]{12}$)|(^(?:2131|1800|35\d{3})\d{11}$)
"))
                {
                    Console.WriteLine("Great!");
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Try again.");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter your expiration date in MM/YYYY format.");
                exp = Console.ReadLine();
                if (Regex.IsMatch(exp, @"^(0[1-9]|1[0-2])\/?(202[1-9])$"))
                {
                    DateTime userDateTime;

                    if (DateTime.TryParse(exp, out userDateTime))
                    {
                        if (userDateTime.Year < DateTime.Now.Year)
                        {
                            Console.WriteLine("Cannot be in the past.");
                            continue;
                        }
                        else if (userDateTime.Month < DateTime.Now.Month)
                        {
                            Console.WriteLine("Cannot be in the past.");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Accepted");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please follow the correct format. MM/YYYY");
                        continue;
                    };
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Try again.");
                } 
            }
            while (true)
            {
                Console.WriteLine("Enter your 3 digit CVV number (located on the back of your card).");
                cvv = Console.ReadLine();
                if (Regex.IsMatch(cvv, "^[0-9]{3}$"))
                {
                    Console.WriteLine("Great!");
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Try again.");
                }
            }
            Console.WriteLine($"CC#: xxxx-xxxx-xxxx-{ccn.Substring(12)} | Exp Date: {exp} | CVV: {cvv} ");
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



