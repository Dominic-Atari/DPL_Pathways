using System;

public class Chalange_2
{
    static void Main(string[] args)
    {
        /* Problem description:  Create a program that will obtain a base from the user, a beginning exponent from the user, and an ending exponent from the user 
        and will print out the value of the base taken to the exponent power for all of the exponents from the beginning to the ending exponent.  
        Use a method, Power, to calculate the value.  Be sure that both the base and exponents are integers greater than or equal to 1, 
        and that the ending exponent is greater than the beginning exponent. Repeat the process until the user wants to quit. 

        /*
            SOLUTION.
        */
        int baseExponent = 0; // to be axesible from the second loop.
        int storeBaseExponent = 0;

        int beginingExponent = 0;
        int storeBeginingExponent = 0;

        int endingExponent = 0;
        int storeEndingExponent = 0;

        double multiplyBaseAndBbeginingEx = 0;

        bool stop = false;

        do
        {
            bool exitFirstLoop = false;
            do
            {
                
                Console.WriteLine("Enter base Number");
                string baseEx = Console.ReadLine();
                int.TryParse(baseEx, out baseExponent);

                if(baseExponent >= 1)
                {
                    storeBaseExponent = baseExponent;
                    exitFirstLoop = true;
                }
                else
                {
                    Console.WriteLine("Number should be greater than 0 or equals to 1");
                }
            }while(!exitFirstLoop);

            bool exitSecondLoop = false;
            do
            {
                Console.WriteLine("Enter the Begining Expponent");
                string beginingEx = Console.ReadLine();
                int.TryParse(beginingEx, out beginingExponent);

                
                    if(beginingExponent >= 1)
                    {
                        
                        storeBeginingExponent = beginingExponent;
                        multiplyBaseAndBbeginingEx = (double)Math.Pow(storeBeginingExponent, storeBaseExponent);
                        
                        exitSecondLoop = true;
                    }
                    else
                    {
                        Console.WriteLine($"begining exponent shpuld be greater than 0 or equals to 1");
                    }
                
            }while(!exitSecondLoop);

            bool exitThirdLoop = false;
            do
            {
                Console.WriteLine("Enter the Ending Exponent");
                string ending = Console.ReadLine();
                int.TryParse(ending, out endingExponent);

                if( endingExponent > beginingExponent)
                {
                    double answer = (multiplyBaseAndBbeginingEx / endingExponent);
                    Console.WriteLine($"{storeBaseExponent} ^ {storeBeginingExponent} = {endingExponent}\nAnswer is = {answer}");
                    exitThirdLoop = true;
                }
                else
                {
                    Console.WriteLine("Ending exponent should be greater than " + storeBeginingExponent);
                }
            }while(!exitThirdLoop);
            Console.WriteLine("Press Enter to Continue or select 0 to exit");
            if(Console.ReadLine() == "0")
            {
                stop = true;
            }
            
        }while( stop == false);   
    }
}