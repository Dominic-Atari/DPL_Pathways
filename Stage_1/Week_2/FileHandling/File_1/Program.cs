using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            // Declare variables
            bool userChoice;
            string userChoiceString;
            const int arraySize = 12;
            string[] nameArray = new string[arraySize];
            string fileName = "names.txt";

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
                            Console.WriteLine(" Here is the content of the file names.txt : ");
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
                    
                    File.WriteAllLines(fileName, nameArray);
                    Console.WriteLine("File saved");
                }

                //  TODO: Else if the option is a C or c then add a name to the array (if there's room there)

                else if (userChoiceString == "C" || userChoiceString == "c")
                {
                    Console.WriteLine("In the C/c area");

                    // I.   Prompt the user and get a new name

                    Console.Write("Please enter the name to add> ");
                    string newName = Console.ReadLine();

                    /*   II.  Find an empty spot in the array 
                            A. Initialize indexFound to -1
                            B. For each index from 0 to 12 in the array
                                  if the item at that index is a blank then set itemFound to the index 
                    */

                    int indexFound = -1;
                    Console.WriteLine(nameArray.GetLength(0));
                    for (int i = 0; i < arraySize; i++)
                    {
                        if (nameArray[i] == " ")
                        {
                            indexFound = i;
                            //Console.WriteLine(indexFound);
                        }

                    }

                    /*   III. If itemFound does not equal -1
                               Add the name to that spot in the array 
                            else give an error message */

                    if (indexFound != -1)
                    {
                        nameArray[indexFound] = newName;
                        File.WriteAllLines(fileName, nameArray);
                        
                    }
                    else
                    {
                        
                        Console.WriteLine("Sorry no room for the name."); //Error
                    }

                }

                //  TODO: Else if the option is an R or r then print the array

                else if (userChoiceString == "R" || userChoiceString == "r")
                {
                    Console.WriteLine("In the R/r area");
                    for (int index = 0; index < arraySize; index++)
                    {
                        if ((nameArray[index]) != " ")
                            Console.WriteLine("Index " + index + " is " + nameArray[index]);
                        else
                            Console.WriteLine("Index " + index + " is available.");
                    }

                }
                //  TODO: Else if the option is a U or u then update a name in the array (if it's there)

                else if (userChoiceString == "U" || userChoiceString == "u")
                {
                    Console.WriteLine("In the U/u area");

                    //  I. Prompt the user to enter the name they would want to updaye.

                        Console.WriteLine("Enter the name you would like to update.");
                        string existingName = Console.ReadLine();

                    /*  
                        II. 
                            Find the name in the array (loop)
                                if the name exist
                                    store the index in nameFound
                            
                            if the name was found
                                Prompt the user to enter the new name
                                Read line
                                if check for not null
                                    array = read line input
                                    store the updated array to the file
                                    print success message
                                else: Error
                            else : Error
                    */  
                    int nameFound = -1;
                    
                    for (int check = 0; check < arraySize; check++)
                    {
                        if (nameArray[check] == existingName)
                        {
                            nameFound = check;
                        }
                    }
                    if (nameFound != -1) // name was found
                    {
                        Console.WriteLine( "Enter the new name.");
                        string updateName = Console.ReadLine();
                        //string store = (nameArray[nameFound] = name).Trim();

                        if(!string.IsNullOrWhiteSpace(updateName))
                        {
                            
                        nameArray[nameFound] = updateName.Trim();
                        File.WriteAllLines(fileName, nameArray); 

                        Console.WriteLine("Name updated Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Error: You did not entered anything.");
                        }   
                    }
                    else
                    {
                        Console.WriteLine("Error: Sorry that name is not found.");
                        
                    }
                }
                //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)

                else if (userChoiceString == "D" || userChoiceString == "d")
                {
                    Console.WriteLine("In the D/d area");

                // Promt the user to enter the index of the namse they would like to delete.
                    Console.WriteLine("Enter the index of the name you would like to delete");
                    string index = Console.ReadLine();


                    /*
                        bool variable to hold -1 for not found
                        find the index (loop)
                            check null: Error
                            check non int inputs: Error.
                            if index has value
                                make -1 true

                        if -1 is true
                            delete from the file
                        else Error:
                    
                    */
                        if (string.IsNullOrWhiteSpace(index))
                        {
                            Console.WriteLine("Error: You did not entered anything");
                        }
                        if(!int.TryParse(index, out int _))
                        {
                            Console.WriteLine("Error: Only numberse are allowed");
                        }
                        else
                        {
                        
                            int notFound = -1;
                            //string store = "";
                            for(int d = 0; d < arraySize; d++)
                            {
                                if(d == Convert.ToInt32(index))
                                {
                                    notFound = d;
                                    nameArray[d] = " "; // set the value to empty.
                                    Console.WriteLine(nameArray[d]);

                                    
                                }
                            }

                            if (notFound != -1)
                            {
                                
                                File.WriteAllLines(fileName, nameArray);
                                Console.WriteLine("Name Deleted Successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Error: value is empty or wrong input");
                            }
                        }
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