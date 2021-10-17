using System;
using System.Collections.Generic;

namespace YCRGroupProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //GROUP PROJECT BABY LET'S GOOOOOOOOO
            InventoryList store = new InventoryList();
            //testers
            List<Product> cart = new List<Product>();




            store.ProductList();

            while (true)
                {
                
                Product purchased = store.SelectorMethod();              
                cart.Add(purchased);
               if (!store.getContinue())
                {
                    break;

                }
                

                }

            double total = store.cartTotal(cart);
            string paymentType = store.askPayment();
            if(paymentType == "cash")
            {

                store.payByCash(total);

            }

            else if(paymentType == "credit")
            {

                store.payByCredit();
            }
            else if(paymentType == "check")
            {
                store.paybyCheck();

            }
            
            



        }

            
           
        }
      

        }

