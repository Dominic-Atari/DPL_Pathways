using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Encapsulation
{
    public class Week_Chalange
    {

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


            string? input;
            string storeRate;
            string storeRestaurant;
            string storeCuisines;
            int arraySize = 25;
            string mainFile = "mainFile.txt";
            bool hasPending = true;
            string[] nameArray = new string[arraySize];
            Restaurant rest = new Restaurant(string.Empty, string.Empty, string.Empty); // Creating an object instance of Restaurant class

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

                if (input == "Q")
                {
                    running = false;
                }
                else if (!input.Equals("L") && !input.Equals("S") &&
                        !input.Equals("C") && !input.Equals("R") &&
                        !input.Equals("U") && !input.Equals("D"))
                {

                    Console.WriteLine("Error: Invalid input please try again");

                }

                // Load the user's list of restaurants, cuisine and ratings (from a data file into a data structure)

                int index = 0;
                if (input == "L")
                {
                    //Console.WriteLine("You are Loading all L");
                    using (StreamReader read = File.OpenText(mainFile))
                    {
                        if (index < 26)
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
                            catch (Exception)
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
                    string? name = "";
                    while (true)
                    {
                        Console.WriteLine("Enter the name of the Resetaurant");
                        name = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z ]+$")) // allows string inputs and space to the right.
                        {
                            rest.Name = name.Trim();
                            break;
                        }
                        Console.WriteLine("Error: Invalid Input");
                    }

                    // Rate (1 to 5 stars)
                    string? rate = "";
                    while (true)
                    {
                        Console.WriteLine("Rate the Cuisine by entering * one to five.");
                        rate = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(rate) && Regex.IsMatch(rate, @"^\*{1,5}$"))
                        {
                            rest.Rate = rate.Trim();
                            break;
                        }
                        Console.WriteLine("Rate only accepts * from 1 to 5 times.");
                    }

                    // Restaurant
                    string? cuisine = "";
                    while (true)
                    {
                        Console.WriteLine("Enter Cuisine type");
                        cuisine = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(cuisine) && Regex.IsMatch(cuisine, @"^[a-zA-Z ]+$"))
                        {
                            rest.Cuisine = cuisine.Trim();
                            break;
                        }
                        Console.WriteLine("Error: enter letters only");
                    }

                    // Mark as ready for saving
                    hasPending = true;


                    Console.WriteLine("C");

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
                        // check for null
                        if (string.IsNullOrWhiteSpace(rest.Name) ||
                            string.IsNullOrWhiteSpace(rest.Rate) ||
                            string.IsNullOrWhiteSpace(rest.Cuisine))
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
                                        $"{rest.Name.PadRight(28)}{rest.Rate.PadRight(28)}{rest.Cuisine}"
                                    );
                                }

                                // Clear to avoid double saving.
                                storeCuisines = "";
                                storeRate = "";
                                storeRestaurant = "";
                                hasPending = false;

                                Console.WriteLine("Saved into file");
                            }
                            else
                            {
                                Console.WriteLine("Error: You are out of bound.");
                            }
                        }
                    }

                }

                // Print a list of all the restaurants and their cuisine and rating,
                // Bonus - only print a list of the restaurants - no blank lines in your list
                // Make sure to handle the case where there are no restaurants in the list
                else if (input == "R")
                {
                    Console.WriteLine("Waiting to be saved");

                    // Restaurant name
                    Console.WriteLine(rest);

                }

                //Update the rating for a restaurant, (Bonus: Update the restaurant name and cuisine)
                else if (input == "U")
                {
                    // Create Restaurant object with file data
                    string[] fileLines = File.ReadAllLines(mainFile);
                    Restaurant update = new Restaurant(fileLines);
                    bool continueUpdating = true;

                    while (continueUpdating)
                    {
                        Console.Write("Enter the index of the Restaurant to update (or Q to cancel): ");
                        string? index1 = Console.ReadLine();

                        if (index1?.ToUpper() == "Q")
                        {
                            continueUpdating = false;
                            break;
                        }

                        if (int.TryParse(index1, out int validIndex) && validIndex > 0 && validIndex <= update.Update.Length)
                        {
                            Console.WriteLine("Enter Rating to update (1-5 stars as *)");
                            string? ratingInput = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(ratingInput) && Regex.IsMatch(ratingInput, @"^\*{1,5}$"))
                            {
                                int indexFound = validIndex - 1;
                                string line = update.Update[indexFound];

                                int starStart = line.IndexOf('*');
                                if (starStart >= 0)
                                {
                                    int starEnd = starStart;
                                    while (starEnd < line.Length && line[starEnd] == '*')
                                    {
                                        starEnd++;
                                    }

                                    string updateLine = line.Substring(0, starStart) + ratingInput + line.Substring(starEnd);
                                    update.Update[indexFound] = updateLine;
                                    File.WriteAllLines(mainFile, update.Update);

                                    Console.WriteLine("Rating updated successfully!");
                                    continueUpdating = false; // Exit back to main menu
                                }
                                else
                                {
                                    Console.WriteLine("Error: Could not find rating in that line");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: Rating must be * (1 to 5 stars)");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid index");
                        }
                    }
                }

                // Delete a restaurant
                else if (input == "D")
                {
                    // Console.WriteLine("Enter the index of the Cuisine you would want to delete");
                    // string name = Console.ReadLine();
                    string[] load = File.ReadAllLines(mainFile);
                    Restaurant lines = new Restaurant(load);

                    bool exit = false;
                    while (!exit)
                    {

                        Console.WriteLine("Enter index to delete");

                        if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                        {

                            if (deleteIndex > 0 && deleteIndex <= lines.Update.Length)
                            {

                                string[] updateWithNewLine = new string[lines.Update.Length - 1];
                                Restaurant del = new Restaurant(updateWithNewLine);

                                int j = 0;
                                for (int i = 0; i < load.Length; i++)
                                {
                                    if (i == (deleteIndex - 1))
                                    {
                                        continue;
                                    }
                                    updateWithNewLine[j] = load[i];

                                    j++;
                                }

                                File.WriteAllLines(mainFile, del.Update);
                                Console.WriteLine("Name Deleted Successfully.");
                                exit = true;
                            }
                            else
                            {

                                Console.WriteLine("Error: deleting choice out of bound");
                                return;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Error: input should be a number.");
                            return;
                        }

                    }
                }
            } while (running);



        }
    }
}
