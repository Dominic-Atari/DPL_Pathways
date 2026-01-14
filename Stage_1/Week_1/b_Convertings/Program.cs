using System;

namespace MyApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      //  PROGRAM TO GET THE RIGHT AGE IF IT WAS REQUIRED TO TO BE ROUNDED TO THE NEAREST WHOLE NUMBER.

      // Promt the user to enter their aga
      Console.WriteLine("Enter your age:");

      // Read the user input.
      string age = Console.ReadLine();

      // Convert aget to double
      double convert = double.Parse(age);

      // Convert double to int and round
      int roundedAge = Convert.ToInt32(Math.Round(convert));

      // Print the result.
      Console.WriteLine("Your age is: " + roundedAge);

      // END OF THE PROGRAM.


    }
  }
}