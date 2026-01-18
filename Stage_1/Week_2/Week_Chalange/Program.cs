using System;
using System.IO;
using System.Text.RegularExpressions;

public class Week_Chalange
{
    static string? input;
    static string storeRate;
    static string storeRestaurant;
    static string storeCuisines;
    static string[] nameArray = new string[25];
    static int arraySize = 25; 
    static string mainFile = "mainFile.txt";
    static bool hasPending = true;
    static void Main(string[] srgd)
    {
        /*
        
            You want to keep track of the name, cuisine (ie Italian, Greek, etc.) and your review of restaurants (0-5 stars) and you want it to be persistent (stored in a text file).  Provide room for 25 restaurants.
            You want a menu that will provide you the options of doing the following:
            L - Load the user's list of restaurants, cuisine and ratings (from a data file into a data structure),
            S -  Save the user's list of restaurants (from a data structure to a data file)
            Bonus - save them so there are no blank lines in the data file 
            C - Add a restaurant, cuisine and rating,
            Make sure the user provides a restaurant, cuisine and rating
            Make sure to handle the "file full" case
            R - Print a list of all the restaurants and their cuisine and rating,
            Bonus - only print a list of the restaurants - no blank lines in your list
            Make sure to handle the case where there are no restaurants in the list
            U - Update the rating for a restaurant, (Bonus: Update the restaurant name and cuisine)
            D - Delete a restaurant
            Q - Quit the program
        
        */

        // MENUE
            
            bool running = true;
        do
        {

            Console.WriteLine("L - Load the user's list of restaurants, cuisine and ratings");
            Console.WriteLine("S - Save the user's list of restaurants");
            Console.WriteLine("C - Add a restaurant, cuisine and rating");
            Console.WriteLine("R - Print a list of all the restaurants and their cuisine and rating");
            Console.WriteLine("U - Update the rating for a restaurant");
            Console.WriteLine("D - Delete a restaurant");
            Console.WriteLine("Q - Quit the program");


            input = Console.ReadLine().ToUpper();
                
                if(input == "Q")
                {
                    running = false;
                }
                else if(!input.Equals("L") && !input.Equals("S") &&
                        !input.Equals("C") && !input.Equals("R") &&
                        !input.Equals("U") && !input.Equals("D"))
                {

                    Console.WriteLine("Error: Invalid input please try again");
                }
                else
                {
                    
                    ProcessChoices();
                }

        } while(running);

    }
    static void ProcessChoices()
    {
        // Load the user's list of restaurants, cuisine and ratings (from a data file into a data structure)

        int index = 0;
        if (input == "L")
        {
            //Console.WriteLine("You are Loading all L");
            using(StreamReader read = File.OpenText(mainFile))
            {
                if(index < 26)
                {
                    
                    try
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Here is the result!");

                        string s = "";
                        while ((s = read.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                            nameArray[index] = s;
                            index = index + 1;
                        }
                        Console.WriteLine("");
                    }
                    catch(Exception )
                    {
                        Console.WriteLine("File failed to load: Contact Anchovy");

                    }
                }
                else
                {
                    Console.WriteLine("You exided the limit");
                }
                
            }
        }

        //Add a restaurant, cuisine and rating,
        //Make sure the user provides a restaurant, cuisine and rating
        //Make sure to handle the "file full" case
        else if (input == "C")
        {
            // Cuisine
            string cuisine = "";
            while (true)
            {
                Console.WriteLine("Enter the name of the Cuisine");
                cuisine = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(cuisine) && Regex.IsMatch(cuisine, @"^[a-zA-Z]+$"))
                {
                    storeCuisines = cuisine.Trim();
                    break;
                }
                Console.WriteLine("Error: Invalid Input");
            }

            // Rate (1 to 5 stars)
            string rate = "";
            while (true)
            {
                Console.WriteLine("Rate the Cuisine by entering * one to five.");
                rate = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(rate) && Regex.IsMatch(rate, @"^\*{1,5}$"))
                {
                    storeRate = rate.Trim();
                    break;
                }
                Console.WriteLine("Rate only accepts * from 1 to 5 times.");
            }

            // Restaurant
            string restaurant = "";
            while (true)
            {
                Console.WriteLine("Enter Restaurant name");
                restaurant = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(restaurant) && Regex.IsMatch(restaurant, @"^[a-zA-Z]+$"))
                {
                    storeRestaurant = restaurant.Trim();
                    break;
                }
                Console.WriteLine("Error: letters a word only");
            }

            // Mark as ready for saving
            hasPending = true;
        }

        // Save the user's list of restaurants (from a data structure to a data file)
        // Bonus - save them so there are no blank lines in the data file
        else if (input == "S")
        {
            // 1) If nothing captured, don't save
            if (!hasPending)
            {
                Console.WriteLine("Nothing to save.");
            }
            else
            {
                // Validate stored values
                if (string.IsNullOrWhiteSpace(storeCuisines) ||
                    string.IsNullOrWhiteSpace(storeRate) ||
                    string.IsNullOrWhiteSpace(storeRestaurant))
                {
                    Console.WriteLine("Error: empty result can't be saved.");
                }
                else
                {
                    // Count lines first
                    int count = 0;

                    if (File.Exists(mainFile))
                    {
                        using (StreamReader read = new StreamReader(mainFile))
                        {
                            while (read.ReadLine() != null)
                            {
                                count++;
                            }
                        }
                    }

                    // Save only if within limit
                    if (count < 25)
                    {
                        using (StreamWriter writeCuisine = new StreamWriter(mainFile, append: true))
                        {
                            writeCuisine.WriteLine(
                                $"{storeCuisines.Trim().PadRight(28)}{storeRate.Trim().PadRight(28)}{storeRestaurant.Trim()}"
                            );
                        }

                        // Clear to avoid double daving.
                        storeCuisines = "";
                        storeRate = "";
                        storeRestaurant = "";
                        hasPending = false;

                        Console.WriteLine("Saved to file");
                    }
                    else
                    {
                        Console.WriteLine("Error: You are out of bound.");
                    }
                }
            }
        }


        //Print a list of all the restaurants and their cuisine and rating,
        //Bonus - only print a list of the restaurants -no blank lines in your list
        //Make sure to handle the case where there are no restaurants in the list
        else if (input == "R")
        {
            Console.WriteLine("Here is the list......!");
            string[] read = File.ReadAllLines(mainFile);

            read.ToString();
            //Console.WriteLine(read);
            for(int r = 0; r < read.Length; r++)
            {
                if(read[r] != null && read[r] != "")
                {
                    
                    Console.WriteLine(read[r]);
                }
            }
                    Console.WriteLine("");
        }

        //Update the rating for a restaurant, (Bonus: Update the restaurant name and cuisine)
        else if (input == "U")
        {
            
            string[] update = File.ReadAllLines(mainFile);
                

            for(int i = 0; i < update.Length; i++)
            {
                string index1;
                bool exit = true;
                while (exit)
                {
                    Console.Write("Enter the index of the Restaurant to update ");
                    index1 = Console.ReadLine();
                    int.TryParse(index1, out int validIndex);
                    if (validIndex > 0 && validIndex < update.Length)
                    {
                        
                        Console.WriteLine("Enter Rating to update");
                        string ratingInput = Console.ReadLine();
                        int indexFound = validIndex - 1;

                        int rate1 = ratingInput.Length;

                        while (true)
                        {
                            
                            if (rate1 > 0 || rate1 < 6 || !int.TryParse(ratingInput, out int _) || 
                                ratingInput.Contains("*") || Regex.IsMatch(ratingInput, @"^\*{1,5}$"))
                            {
                                string line = update[indexFound]; 

                                int starStart = line.IndexOf('*'); // index 28

                                int starEnd = starStart;
                                while(starEnd < line.Length && line[starEnd] == '*')
                                {
                                    starEnd++;
                                }
                                string newStar = new string('*', rate1);
                                string updateLine = line.Substring(0, starStart) + newStar + line.Substring(starEnd);
                                update[indexFound] = updateLine;
                                File.WriteAllLines(mainFile, update);
                                return; // return to the selection menue.

                            }
                            else
                            {
                                
                                Console.Write("Error: rating must be *");
                            }  
                        }
                    }
                    else if (index1.ToUpper() == "Q") // incase U is pressed by mistake. user can Quite
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        
                        Console.WriteLine("Error: Index is not found");
                    }

                }
                
                

                    //exitUpdate = true;
            
            }
        }

        // Delete a restaurant
        else if (input == "D")
        {
            // Console.WriteLine("Enter the index of the Cuisine you would want to delete");
            // string name = Console.ReadLine();
            
            string[] load = File.ReadAllLines(mainFile);
            while(true)
            {
                
                Console.WriteLine("Enter index to delete");

                if(int.TryParse(Console.ReadLine(), out int deleteIndex))
                {
                    
                    if(deleteIndex > 0 && deleteIndex <= load.Length)
                    {

                        string[] updateWithNewLine = new string[load.Length -1];

                        int j = 0;
                        for(int i = 0; i < load.Length; i++)
                        {
                            if(i == (deleteIndex -1))
                            {
                                continue;
                            }
                                updateWithNewLine[j] = load[i];
                            
                            j++;
                        }

                        File.WriteAllLines(mainFile, updateWithNewLine);
                        Console.WriteLine("Name Deleted Successfully.");
                        return;
                    }
                    else
                    {
                        
                        Console.WriteLine("Error: deleting choice out of bound");
                    }

                }
                else
                {
                    Console.WriteLine("Error: input should be a number.");
                }
                
            }
        }

    }
    
}