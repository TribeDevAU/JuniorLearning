﻿using System;
using CalculatorLibrary;

namespace CalculatorProgram
{
   

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
           
            // Display title...
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            // create calculator variable
            Calculator calculator = new Calculator();

            while (!endApp)
            {
                // Declare variable & set to empty
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask user for 1st number
                Console.WriteLine("Type a number, and then press Enter");
                numInput1 =Console.ReadLine();

                double cleanNum1 = 0;
                while(!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask user for 2nd number
                Console.WriteLine("Type another number, and then press Enter");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask user to choose operation option
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occured trying to do the math. \n - Details: " + e.Message);
                }
                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n")
                {
                    endApp = true;
                }

                Console.WriteLine("\n");    // to add line space before next calc
            }

            // Call Finish method to close out JSON writer
            calculator.Finish();
            return;
        }
    }
}
