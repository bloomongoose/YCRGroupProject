using System;
using System.Collections.Generic;


namespace YCRGroupProject
{
    class Program
    {
        static void Main(string[] args)
        {



            bool runProgram = true;
            while (runProgram)
            {

                Console.WriteLine("\t\t\t\tWelcome to the Ultimate Corner Bodega!\n");
                
                InventoryList store = new InventoryList();
                
                List<Product> cart = new List<Product>();
                List<double> quantity = new List<double>();

                store.ProductList();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                while (true)
                {
                    Product purchased = store.SelectorMethod();
                    double itemQuantity = store.GetAmount(purchased);
                    quantity.Add(itemQuantity);
                    cart.Add(purchased);
                    if (!store.getContinue())
                    {
                        break;
                    }
                }

                double total = store.cartTotal(cart);
                double change = 0;
                string paymentType = store.askPayment();
                if (paymentType == "cash")
                {
                    change = store.payByCash(total);
                }
                else if (paymentType == "credit")
                {
                    store.payByCredit();
                }
                else if (paymentType == "check")
                {
                    store.paybyCheck();
                }
                store.DisplayReceipt(cart, quantity);
                Console.WriteLine("\n");
                store.cartTotal(cart);
                if (paymentType == "cash")
                {
                    Console.WriteLine($"Your change is ${Math.Round(change, 2)}.");
                }

                Console.WriteLine("--------------------------------------------------\n\n");

                runProgram = Validator.Validator.GetContinue("Would you like to continue shopping? y/n");


            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Font font = new Font("Times New Roman", 12.0f);

        }
    }
}

