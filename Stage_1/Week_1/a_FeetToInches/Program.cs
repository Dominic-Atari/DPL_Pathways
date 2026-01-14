using System; 

namespace FeetToInches

{

    class Program

    {

        static void Main(string[] args)

        {

            // [1] Prompt the user to enter a value in feet
            // [2] and read the input from the console
            // [3] Convert the input string to a double
            // [4] Multiply the value in feet by 12 to convert to inches
            // [5] Display the result in inches to the console

            // [1] Prompt the user to enter a value in feet
                Console.WriteLine("Input the Foots you would want to convert to inches");

            // [2] and read the input from the console
                string input = Console.ReadLine();

            // [3] Convert the input string to a double
                double convert = Convert.ToDouble(input);

            // [4] Multiply the value in feet by 12 to convert to inches
                convert *= 12;
            // [5] Display the result in inches to the console
                Console.WriteLine("{0} feet is {1} in inches", input, convert);

                // END OF FEET TO INCHES

                //Q2

                // REST DOMINIC IT IS TO SIMPLE FOR YOU, WAIT FOR YOUR AGEMATE LOL .
        } // end of the main program

    } // end of the class Program

} // end of the namespace FeetToInches