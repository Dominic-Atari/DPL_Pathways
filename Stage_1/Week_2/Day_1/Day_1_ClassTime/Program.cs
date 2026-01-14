using System;

public class Day_1
{
    static void Main(string[] args)
    {
        /*
            Declare array of integers and set values

            Set max variable to highest possible value

            For each element of the array 

                If the current element is less than the max

                    set the max to the value of the current element

            Write out max value

        */
        int[] num = {50, 70, 1000, -4}; // Dinamic array of int with values
        int answer = CalculateMaximum(num); // store method in answer and pass is the values variable as arguments
        Console.WriteLine(answer); // print the result out of the loop.
        
    }

    static int CalculateMaximum(int[] values) // array named values pased as property
    {
        int max = 0; // max value to be compared to.

        for(int i = 0; i < values.Length; i++) // loop through the values in the array
        {
            if(max < values[i]) // conditional statement to check if the values[i] is less than the max.
            {
                max = values[i]; // if value is smalest asign the values[i] to the max value
            }
        }
        return max; // this return max as integer
    }
}
