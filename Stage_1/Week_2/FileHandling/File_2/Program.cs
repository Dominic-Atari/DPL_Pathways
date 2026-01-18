using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            // Declare variables
            bool userChoice;
            string? userChoiceString;
            const int arraySize = 12;

            string[] nameArray = new string[arraySize];
            string fileName = "students.txt";

            string[] homeWorkArray = new string[arraySize];
            string homeWorkFile = "homeWork.txt";

            // Repeat main loop
            do
            {

                // TODO: Get a valid input
                do
                {
                    //  Initialize variables

                    userChoice = false;

                    //  TODO: Provide the user a menu of options

                    Console.WriteLine("What's your pleasure? ");
                    Console.WriteLine("L: Load the data file into an array.");
                    Console.WriteLine("S: Save the array to the data file.");
                    Console.WriteLine("C: Add a name to the array.");
                    Console.WriteLine("R: Read a name from the array.");
                    Console.WriteLine("U: Update a name in the array.");
                    Console.WriteLine("D: Delete a name from the array.");
                    Console.WriteLine("Q: Quit the program.");

                    //  TODO: Get a user option (valid means its on the menu)

                    userChoiceString = Console.ReadLine();

                    userChoice = (userChoiceString == "L" || userChoiceString == "l" ||
                                userChoiceString == "S" || userChoiceString == "s" ||
                                userChoiceString == "C" || userChoiceString == "c" ||
                                userChoiceString == "R" || userChoiceString == "r" ||
                                userChoiceString == "U" || userChoiceString == "u" ||
                                userChoiceString == "D" || userChoiceString == "d" ||
                                userChoiceString == "Q" || userChoiceString == "q");

                    if (!userChoice)
                    {
                        Console.WriteLine("Please enter a valid option.");
                    }

                } while (!userChoice);

                //  TODO: If the option is L or l then load the text file (names.txt) into the array of strings (nameArray)

                if (userChoiceString == "L" || userChoiceString == "l")
                {
                    try
                    {
                        Console.WriteLine("In the L/l area");

                        int index = 0;  // index for my array
                        using (StreamReader sr = File.OpenText(fileName))
                        {
                            string s = "";
                            Console.WriteLine(" Here is the content of the file students.txt : ");
                            while ((s = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(s);
                                nameArray[index] = s;
                                index = index + 1;
                            }
                            Console.WriteLine("");
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Sorry that file isn't found");
                    }
                    finally
                    {
                        Console.WriteLine("Let's move on...");
                    }

                }

                //  TODO: Else if the option is an S or s then store the array of strings into the text file

                else if (userChoiceString == "S" || userChoiceString == "s")
                {
                    Console.WriteLine("In the S/s area");
                }

                //  TODO: Else if the option is a C or c then add a name to the array (if there's room there)

                else if (userChoiceString == "C" || userChoiceString == "c")
                {
                    Console.WriteLine("In the C/c area");

                    // I.   Prompt the user and get a new name

                    Console.Write("Please enter the name to add> ");
                    string? newName = Console.ReadLine();

                    /*   II.  Find an empty spot in the array 
                            A. Initialize indexFound to -1
                            B. For each index from 0 to 12 in the array
                                  if the item at that index is a blank then set itemFound to the index 
                    */

                    int indexFound = -1;
                    bool exit = false;
                    string? validScore;
                    do
                    {
                        Console.WriteLine(nameArray.GetLength(0));
                        for (int i = 0; i < nameArray.GetLength(0); i++)
                        {
                            if (nameArray[i] == "")
                            {
                                indexFound = i;
                                Console.WriteLine(indexFound);
                            }
                            /*
                            do
                                Prompt for the student score
                                read line

                                    loop
                                    if index == input
                                        prompt enter home work Id
                                        strem open the home work file
                                        add the input into the home work file (tied to the Id)
                            */
                        }
                            
                            
                        Console.WriteLine("Enter students score");
                        validScore = Console.ReadLine();

                            if(int.Parse(validScore) > 1 && int.Parse(validScore) < 101)
                            {
                            }
                            else
                            {
                                Console.WriteLine("Soce is between 0 and 100");
                                
                            }
                        for(int id = 0; id < arraySize; id++)
                        {
                            if(homeWorkArray[id] == "")
                            {
                                indexFound = id;
                                Console.WriteLine(indexFound + "for home work");
                                validScore = validScore;

                                exit = true;
                            }
                        }
                    } while(exit);
                    


                    /*   III. If itemFound does not equal -1
                               Add the name to that spot in the array 
                            else give an error message */


                    if (indexFound != -1)
                    {
                        using(StreamWriter write = new StreamWriter(fileName, append: true))
                        {
                            
                            write.WriteLine(newName);
                        }

                        using (StreamWriter writeHomeWork = new StreamWriter(homeWorkFile, append: true))
                        {

                            writeHomeWork.WriteLine(validScore);
                        }

                    }
                    else
                        Console.WriteLine("Sorry no room for the name.");

                }

                //  TODO: Else if the option is an R or r then print the array

                else if (userChoiceString == "R" || userChoiceString == "r")
                {
                    Console.WriteLine("In the R/r area");
                    for (int index = 0; index < arraySize; index++)
                    {
                        if ((nameArray[index]) == " ")
                            Console.WriteLine("Index " + index + " is " + nameArray[index]);
                        else
                            Console.WriteLine("Index " + index + " is available.");
                    }

                }
                //  TODO: Else if the option is a U or u then update a name in the array (if it's there)

                else if (userChoiceString == "U" || userChoiceString == "u")
                {
                    Console.WriteLine("In the U/u area");

                    // I. Prompt the user
                        Console.WriteLine("Enter the name you would like to update");
                }

                //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)

                else if (userChoiceString == "D" || userChoiceString == "d")
                {
                    Console.WriteLine("In the D/d area");
                }
                //  TODO: Else if the option is a Q or q then quit the program

                else
                {
                    Console.WriteLine("Good-bye!");
                }
            } while (!(userChoiceString == "Q") && !(userChoiceString == "q"));
        }  // end main
    }  // end program
}  // end namespace