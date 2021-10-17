using System;
using System.Collections.Generic;

namespace YCRGroupProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\t\t\t\tWelcome to the corner bodega!\n");
                //GROUP PROJECT BABY LET'S GOOOOOOOOO
                InventoryList store = new InventoryList();
                //testers
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
            }

        }

    }

}

