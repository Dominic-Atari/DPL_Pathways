using System;

public class Chalange_3
{
    static void Main(string[] args)
    {
        
        /*
        Problem description: Create a program to count the user's daily calories and then indicate 
        if the daily goal has been met.  Here is an example output:
        Welcome to the Calorie Tracker!
        Your daily goal is 2000 calories.

        Enter meal calories (or type 'quit'): 500
        Current total: 500 calories.

        Enter meal calories (or type 'quit'): 800
        Current total: 1300 calories.

        Enter meal calories (or type 'quit'): burger
        Invalid input. Please enter a number or 'quit'.
        Current total: 1300 calories.

        Enter meal calories (or type 'quit'): 450
        Current total: 1750 calories.

        Enter meal calories (or type 'quit'): quit

        --- Daily Summary ---
        Total Calories: 1750
        Goal: 2000
        Great job! You stayed under your daily goal.
        */
        

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Welcome to the Calorie Tracker!");
        Console.WriteLine("Your daily goal is 2000 calories.");

        int limit = 2000;
        int total = 0;
        bool stop = false;
        do
        {
            Console.WriteLine("Enter meal calories (or type 'quit')");
            string input = Console.ReadLine();
            
            // Exit.
            if(input.ToLower() == "quit")
            {
                stop = true;
            }
            else if(int.TryParse(input, out int calories))
            {
                total += calories;
                if(total < limit)
                {
                    
                Console.WriteLine($"Current total: {total} calories.");
                }
                else if(total > limit)
                {
                    Console.WriteLine($"Current total: {total} calories.");
                    Console.WriteLine("You have exceeded your daily goal!");
                    var transferData = total;
                    total = 0; // reset total to 0.
                }
                else
                {
                    Console.WriteLine($"Current total: {total} calories.");
                    Console.WriteLine("You have met your daily goal!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number or 'quit'.");
                Console.WriteLine($"Current total: {total} calories.");
            }
            

            
        }while(stop == false);

        Console.WriteLine();
        Console.WriteLine("--- Daily Summary ---");
        Console.WriteLine($"Total Calories: {total}");
        Console.WriteLine($"Goal: {limit}");
        Console.WriteLine("Great job! You stayed under your daily goal.");
    }
}