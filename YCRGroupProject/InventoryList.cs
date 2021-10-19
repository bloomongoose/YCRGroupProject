using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace YCRGroupProject
{
    class InventoryList
    {
        //Store Inventory List 
        List<Product> StoreList = new List<Product>
            {
                new Product("Turtleneck", "Clothing", "It's Time To Start Caring About Your Neck", 18.99),
                new Product("Pineapple", "Food", "Delicious Fruit", 1.99),
                new Product("Coffee", "Drink", "Dark Roast", .99),
                new Product ("Doritos", "Snack", "Nacho Cheese", 2.99),
                new Product ("Soap", "Home Goods", "Lavender Scent", 2.99),
                new Product ("Gum", "Snacks", "Spearmint", 1.99),
                new Product ("Socks", "Clothing", "For Feet", 3.99),
                new Product ("Sunglasses", "Accessories", "For Style", 4.99),
                new Product ("Mystery Bag", "Random Goods" , "Buy At Your Own Risk", 19.99),
                new Product ("Beanie", "Clothing", "Keep Your Head Warm", 5.99),
                new Product ("Taco", "Food", "Who Doesn’t Love Tacos?", 2.99),
                new Product ("Suspenders", "Clothing", "Unleash Your Inner Terry Crews", 8.99),
                new Product ("Speakers", "Electronics", "For Surround Sound", 24.99)
            };
        //Quantitiy list for customer
        List<double> Quantity = new List<double>();


        //creating new method run at beginning of code
        //file method
        public void FileCheck()
        {
            string filepath = @"..\..\..\YCR_Group_Project";
            if (File.Exists(filepath) == false)
            {
                StreamWriter sw = new StreamWriter(filepath);
                foreach (Product pro in StoreList)
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
                foreach (string line in lines)
                {
                    if (line.Length < 2)
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
        //Add item method, adds to file as well
        public void AddProduct()
        {
            string filepath = @"..\..\..\YCR_Group_Project";
            FileCheck();

            Console.WriteLine("What is the name of the product?");
            string prodName = Console.ReadLine();

            Console.WriteLine("What category is the product in?");
            string prodCategory = Console.ReadLine();

            Console.WriteLine("Please write a description for the product: ");
            string prodDescription = Console.ReadLine();

            Console.WriteLine("What is the product's price?");
            double prodPrice = Validator.Validator.GetNumber();

            Product prod = new Product(prodName, prodCategory, prodDescription, prodPrice);
            StoreList.Add(prod);
            StreamWriter sw = new StreamWriter(filepath, append: true);
            sw.WriteLine($"{prod.Name},{prod.Category},{prod.Description},{prod.Price}");
            sw.Close();

        }

        //displays product list 
        public void ProductList()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < StoreList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {StoreList[i].ToString()}");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        //method for selecting item by name
        public Product NameSelector(string choice)
        {
            Product Purchased = new Product();

            foreach (Product p in StoreList)
            {
                if (choice.ToLower().Trim() == p.Name.ToLower().Trim())
                {
                    Purchased = p;
                    break;
                }
            }
            return Purchased;
        }

        //select item by number method
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

        //method to check number or word within itemlist
        public Product SelectorMethod()
        {
            Product Purchased = new Product();
            bool isNum = true;
            while (true)
            {
                Console.WriteLine("\t\t\t\tPlease enter a product number or product name.");
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
                else if (result > 0 && result <= StoreList.Count)
                {
                    Purchased = numSelector(result);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("We do not have that product");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return Purchased;
        }

        //asks for a quantity for selected item
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

        //displays cart total, tax, and grand total
        public double cartTotal(List<Product> cartListTotal)
        {
            double subTotal = 0;
            double salesTax = 0.06;
            for (int i = 0; i < cartListTotal.Count; i++)
            {
                subTotal += cartListTotal[i].Price * Quantity[i];
            }
            double grandTotal = (subTotal * salesTax) + subTotal;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Subtotal: ${subTotal.ToString("0.00")} | Sales Tax: {salesTax}% | Grand total: ${(grandTotal.ToString("0.00"))}");
            Console.ForegroundColor = ConsoleColor.White;
            return grandTotal;
        }

        //checks to see if user wants to see menu or finish purchase
        public bool getContinue()
        {
            bool keepGoing = true;
            double result = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter 1 to see the menu, 2 to checkout.");
                    result = double.Parse(Console.ReadLine());
                    if (result == 1)
                    {
                        ProductList();
                        break;
                    }
                    else if (result == 2)
                    {
                        keepGoing = false;
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
            return keepGoing;
        }

        //asks user how they will be paying
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

        //Cash payment option
        public double payByCash(double total)
        {
            double change = 0;
            while (true)
            {
                Console.WriteLine("How much cash would you like to pay with?");
                double cash = Validator.Validator.GetNumber();
                change = cash - total;
                if (cash >= total)
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
            return change;
        }

        //credit payment option
        public void payByCredit()
        {
            string cvv = "";
            string ccn = "";
            string exp = "";
            while (true)
            {

                //checks for real credit card number
                Console.WriteLine("Enter your 16 digit credit card number.");
                ccn = Console.ReadLine();
                if (Regex.IsMatch(ccn, @"(^4[0-9]{12}(?:[0-9]{3})?$)|(^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$)|(3[47][0-9]{13})|(^3(?:0[0-5]|[68][0-9])[0-9]{11}$)|(^6(?:011|5[0-9]{2})[0-9]{12}$)|(^(?:2131|1800|35\d{3})\d{11}$)
"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Great!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That was not a valid input. Try again.");
                    Console.ForegroundColor = ConsoleColor.White;
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Cannot be in the past.");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        else if (userDateTime.Month < DateTime.Now.Month)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Cannot be in the past.");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Accepted");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please follow the correct format. MM/YYYY");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    };
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That was not a valid input. Try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter your 3 digit CVV number (located on the back of your card).");
                cvv = Console.ReadLine();
                if (Regex.IsMatch(cvv, "^[0-9]{3}$"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Great!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That was not a valid input. Try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine($"CC#: xxxx-xxxx-xxxx-{ccn.Substring(12)} | Exp Date: {exp} | CVV: {cvv} ");
        }

        //check payment option
        public void paybyCheck()
        {
            Console.WriteLine("Enter your check number.");
            double check = Validator.Validator.GetNumber();

            Console.WriteLine($"Your check number is {check}.");
        }

        //displays receipt to user
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

        //asks user to continue, end session or add product, after initial purchase
        public bool askAddOrEndSession()
        {
            bool keepGoing = true;
            double result = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter 1 to continue shopping, 2 to end session, or 3 to add a product.");
                    result = double.Parse(Console.ReadLine());
                    if (result == 1)
                    {
                        break;
                    }
                    else if (result == 2)
                    {
                        keepGoing = false;
                        break;
                    }
                    else if (result == 3)
                    {
                        AddProduct();
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
            return keepGoing;
        }
    }
}



