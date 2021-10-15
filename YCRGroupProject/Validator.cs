using System;
using System.Collections.Generic;
using System.Text;

namespace Validator
{
    class Validator
    {
        //for getting numeric input from user
        public static double GetNumber()
        {
            double result = 0;

            while (true)
            {
                try
                {
                    result = double.Parse(Console.ReadLine());
                    break;
                }
                catch(FormatException e)
                {
                    Console.WriteLine("That was not a number. Try again.");
                }
            }

            return result;
        }

        public static double GetNumber(double min, double max)
        {
            double result = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine($"Enter a number between {min} and {max}.");
                    result = double.Parse(Console.ReadLine());
                    if (result > max)
                    {
                        throw new Exception ("That number's too large.");
                    }
                    else if(result < min)
                    {
                        throw new Exception("That number's too smol.");
                    }
                    else
                    {
                        break;
                    }
                    
                }
                catch(FormatException e)
                {
                    Console.WriteLine("That wasn't a number. Try again");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //catch(ArgumentOutOfRangeException e)
                //{
                //    Console.WriteLine("That was outside the allowable range. Try again.");
                //}
            }
            return result;
        }

        //for continuing asking user to begin again
        public static bool GetContinue()
        {
            bool result = true;

            while (true)
            {
                Console.WriteLine("Would you like to keep running the program? y/n");
                string choice = Console.ReadLine().ToLower().Trim();
                if(choice == "y")
                {
                    result = true;
                    break;
                }
                else if(choice == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid option. Try again.");
                }
            }

            return result;
        }

        public static bool GetContinue(string custom)
        {
            bool result = true;

            while (true)
            {
                Console.WriteLine(custom);
                string choice = Console.ReadLine().ToLower().Trim();
                if(choice == "y")
                {
                    result = true;
                    break;
                }
                else if (choice == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("That wasn't a valid option. Try again.");
                }
            }

            return result;
        }
    }
}
