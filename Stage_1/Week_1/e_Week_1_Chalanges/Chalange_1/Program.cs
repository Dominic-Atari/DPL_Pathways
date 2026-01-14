using System;

public class Chalange_1
{
    static void Main(string[] args)
    {
        /* Problem description:  
        Write a program that will obtain a base from the user and an exponent from the user and will print out the value of the base taken to the exponent power.  
        Use a method, Power, to calculate the value.  
        Be sure that both the base and exponent are integers greater than or equal to 1. 
        So, check that both the data type is valid and that the value is valid. Repeat the process until the user wants to quit. */


        /*
            SOLUTION.
            [0]create a list of integers, get valuses from the calculated input, store in the list and use the list to display the result in the next option.
            [1]Display program menue with options to guide the user through the program.
            [2]Use while loop to keep the user in the program untill they enter 0 to quit.
            [4]Inisde the while loop, prompt the user to enter a value they would like to calculate it's Power form.
            [5]Read users input and make sure it is an int value by tryparsing the variable name as (base).
            [6]usde if, if_else statement to validate the logic for the valies should be above 0.
            [7]do the calculation 
            [8]reeturn the calculated values to the user
            
        */

        List<int> list = new List<int>();
        //[1]Display program menue with options to guide the user through the program.
        Console.WriteLine("");
        Console.WriteLine("\n");
        Console.WriteLine("WELCOME TO THE SIMPLE APP FOR CALCULATING POWER FORM OF NUMBERS!");

        //[2]Use while loop to keep the user in the program untill they enter 0 to quit.
        bool running = true;
        while (running)
        {
            Console.WriteLine("Here are the options");
            Console.WriteLine("E) To calculate exponent");
            Console.WriteLine("L) Show the answers");

            string? option = Console.ReadLine();


            if (option == "E")
            {

                int baseNumber;
                int exponentNumber;
                string? input;

                do
                {
                    Console.WriteLine("Enter the Base number must be above 0):");
                    input = Console.ReadLine();

                    if (!int.TryParse(input, out baseNumber) || baseNumber <= 0)
                        Console.WriteLine("Invalid input. Try again.");

                } while (!int.TryParse(input, out baseNumber) || baseNumber <= 0);

                Console.WriteLine($"Base number = {baseNumber}");

                do
                {

                Console.WriteLine("Enter Exponent must be also above 0");
                input = Console.ReadLine();

                if (!int.TryParse( input, out exponentNumber) || exponentNumber <= 0)
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
                
                }while(!int.TryParse(input, out exponentNumber) || exponentNumber <= 0);

                    int result = (int)Power(baseNumber, exponentNumber);
                    Console.WriteLine($"The Power of number {baseNumber} to exponent {exponentNumber} is {result}");

                    list.Add(result);
            }
            else if (option == "L")
            {
                foreach (int li in list)
                {
                    Console.WriteLine(li);
                }
            }
            else if (option == "0")
            {
                Console.WriteLine("Exiting...GoodBye!");
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid Option, Please try again");
            }

        }
    }
    static double Power(int baseNumber, int exponentNumber)
    {
        return Math.Pow(baseNumber, exponentNumber);
    }

}
