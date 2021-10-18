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
                catch(Exception e)
                {
                    Console.WriteLine("That was not a valid input. Please enter a number.");
                }
            }

            return result;
        }
        public static double GetNumber(string input)
        {
            double result = 0;

            while (true)
            {
                try
                {
                    result = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("That was not a valid input. Please enter a number.");
                }
            }

            return result;
        }

        public static double GetNumberRange(double min, double max)
        {
           // double min = 1000000000000000;
          // double max = 9999999999999999;
            double result = 0;

            while (true)
            {
                try
                {
                    result = double.Parse(Console.ReadLine());
                    if(result < min || result > max)
                    {
                        Console.WriteLine("That was not a valid number. Please try again.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("That was not a valid input. Please enter a number.");
                }
            }

            return result;
        }

        public static double KeepGoing()
        {
            double result = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter 1 to see the menu. Enter two to checkout.");
                    result = double.Parse(Console.ReadLine());
                    if (result == 1 )
                    {
                        
                    }
                    else if(result == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid number. ");
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
                    Console.Clear();
                    break;
                }
                else if (choice == "n")
                {
                    result = false;
                    Console.Clear();
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
