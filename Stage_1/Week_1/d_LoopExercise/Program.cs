using System;

public class LoopExercise
{

    static void Main(string[] args)
    {
        // PROGRAM TO PERFORM THE MIN VALUE OF NUMBERS


        // Display menue options for the user to view the numbers they have entered by Prompting and show other selections.
        // Promt the user to enter numbers they would want to get the minimump of those numbers
        // a) Declear a variable of int to be used to store the maximum value
        // b) Declear a variable of string to be used to store the numbers entered
        // after viewing, let the user have option to select to get the minimum of those number
        // a) Use while loop to keep the user in the app until they chose to exit
        // b) in the loop, Read the input and look for any form of validating online
        // c) use if else statement to validate the user inpull by checking null values
        // d) alert the user if they entered incorrect values by only allowing choice form the ooptions we provided earlier and alert if the input is not what we expect
        // print to the user the minimum of those numbers

        //[6] Keep the user in a while loop untill they chose to exit
        Console.WriteLine();
        Console.WriteLine("\nWELCOME TO MY SIMPLE MATH APP");
        Console.WriteLine("Select the following options");
        Console.WriteLine(" C) to enter number you would like to get it's Minimum value");
        Console.WriteLine(" L) to view the numbers you have entered");
        Console.WriteLine(" 0) to exit the App");


        int minValue = int.MaxValue; // Will be used to compare the minimum value.
        string store = string.Empty; // to store the numbers entered

        bool running = true;

        while (running)
        {
            string choice = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("OPPS, You have not entered anything, Try Again!");
            }
            else if (choice != "C" && choice != "L" && choice != "0")
            {
                Console.WriteLine("OPPS, We only expect C, L or 0, Try Again!");
            }
            else if (choice == "C")
            {

                Console.WriteLine("Enter numbers you would like to get it's Minimum value");
                string numbers = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(numbers, out int validatedNumber))
                {
                    // Get the min number only.
                    minValue = Math.Min(minValue, validatedNumber);

                    // convsrt the int back to string and store the in string variable delceared on top of the program.
                    store = validatedNumber.ToString();

                    //Print back the entered number.
                    Console.WriteLine($"Number entered: {validatedNumber}");
                    Console.WriteLine("You can enter C to enter another number or choose L to view the Minimum value of the numbers you have entered");
                }
                else
                {
                    // if the input is not a number print back to the console with some clear dierectin.
                    Console.WriteLine($"[{numbers}] Is not a number. Please enter a valid integer number.");
                    Console.WriteLine("chose C to start again.");
                }
            }
            else if (choice == "L")
            {
                // before listing check if the store has value (Minimum Value)
                if (!string.IsNullOrEmpty(store))
                {

                    Console.WriteLine($"The Minimum value of the numbers you have entered is: {minValue}");
                    Console.WriteLine("You can select C to enter another number or choose 0 to exit the App");
                }
                else
                {
                    Console.WriteLine("No numbers have been entered yet.");
                }
            }
            else if (choice == "0")
            {
                running = false;
                Console.WriteLine("Exiting the App. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

        }

    }
}