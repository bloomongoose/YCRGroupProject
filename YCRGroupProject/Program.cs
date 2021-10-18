using System;
using System.Collections.Generic;
using System.IO;

namespace YCRGroupProject
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryList store = new InventoryList();
            store.FileCheck();

            bool runProgram = true;
            while (runProgram)
            {

                Console.WriteLine("\t\t\t\tWelcome to the Ultimate Corner Bodega!\n");
                                             
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
                    Console.WriteLine($"Your change is ${change.ToString("0.00")}");
                }

                Console.WriteLine("--------------------------------------------------\n\n");

                runProgram = store.askAddOrEndSession();
                


            }
            

        }

        
    
    }
}

