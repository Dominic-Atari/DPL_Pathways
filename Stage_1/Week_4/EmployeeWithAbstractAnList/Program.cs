using System;
using System.Text.RegularExpressions;

namespace Stage_1.Week_3.z_Competency
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Each employee will have a last name, first name and employee type (hourly or salary).
                An hourly employee will have an hourly rate. 
                A salary employee will have an annual salary.
                Bonuses are calculated as followed:
                If not hourly or salary, the bonus is 0.
                Hourly, the bonus is two weeks pay (40 hours per week)
                Salary, the bonus is 10%
                You want a menu that will provide you the options of doing the following:
                L - Load the single text file into the program.  The text file stores four lines 
                    for each employee including last name, first name, employee type and hourly rate or salary 
                    (depending on employee type - H or S)
                S - Store the current employee information in the text file
                C - Add an employee
                R - Print a list of all the employees including their calculated bonus,
                U - Update information for an employee,
                D - Delete an employee
                Q - Quit the program
                We will discuss your class design before you start, but it will include encapsulation, 
                    inheritance, and polymorphism.  Classes will include:
                Employee (last name, first name, employee type; constructors, calculate bonus, toString)
                HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
                SalaryEmployee (annual salary; constructors, calculate bonus, toString
                Be sure to follow best programming practices (no code smell!)
            */
            //Employee employee = new Employee(string.Empty, string.Empty, string.Empty);
            SalaryEmployee salary = new SalaryEmployee(string.Empty, 0.0, string.Empty, string.Empty);
            List<SalaryEmployee> salaryList = new List<SalaryEmployee>
            {
                new SalaryEmployee(salary.FirstName = string.Empty,
                                    0.0,
                                    salary.LastName = string.Empty,
                                    salary.EmployeeType = string.Empty)
            };

            HourlyEmployee hourly = new HourlyEmployee(string.Empty, 0.0, string.Empty, string.Empty);
            List<HourlyEmployee> hourlyList = new List<HourlyEmployee>
            {
                new HourlyEmployee(hourly.FirstName = string.Empty,
                                    0.0,
                                    hourly.LastName = string.Empty,
                                    hourly.EmployeeType = string.Empty)
            };
            // string storeFistName = "";
            // string storeLastName = "";
            string storeType = "";
            // int storeEarnings = 0;
            // double storeRate = 0.0;

            string? typeInput;

            string mainFile1 = "mainFile1.txt";
            string[] arraySize = new string[21];
            int limit = 21;
            //bool hasPending = false;

            string? input;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("L - Load the single text file into the program.");
                Console.WriteLine("S - Store the current employee information in the text file");
                Console.WriteLine("C - Add an employee");
                Console.WriteLine("R - Print a list of all the employees including their calculated bonus,");
                Console.WriteLine("U - Update information for an employee,");
                Console.WriteLine("D - Delete an employee");
                Console.WriteLine("Q - Quit the program");

                input = Console.ReadLine().ToUpper();

                if (input != "L" && input != "S" &&
                    input != "C" && input != "R" &&
                    input != "U" && input != "D" &&
                    input != "Q")
                {
                    Console.WriteLine("Error: Invalid input");
                }
                else
                {
                    if (input == "Q")
                    {
                        exit = true;
                    }
                    else if (input == "L")
                    {
                        // Load file
                        int counter = 0;
                        string lines = "";

                        try
                        {


                            using (StreamReader loadFile = File.OpenText(mainFile1))
                            {
                                if (counter > limit)
                                {
                                    Console.WriteLine("Error: Out of bound.");
                                }

                                else
                                {

                                    Console.WriteLine("");
                                    Console.WriteLine("Here is the result!");
                                    while ((lines = loadFile.ReadLine()) != null)
                                    {
                                        Console.WriteLine(lines);
                                        arraySize[counter] = lines;
                                        counter++;
                                        //return;
                                    }
                                    //return; // end of the loop.
                                    continue;
                                }

                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Errir: File is not found.");
                        }

                    }
                    else if (input == "C")
                    {
                        // Create employee based on their Type.

                        // Salary Employee.
                        Console.WriteLine("Enter Employee Type (H for Hourly, S for Salary)");
                        string? readType = Console.ReadLine()?.ToUpper();

                        if (readType == "S")
                        {
                            salary.EmployeeType = "S";
                            while (string.IsNullOrWhiteSpace(salary.EmployeeType) || Regex.IsMatch(salary.EmployeeType, @"^[^S]+$"))
                            {
                                Console.WriteLine("Error: Type should be H or S.");
                                salary.EmployeeType = Console.ReadLine()?.ToUpper();
                            }
                            salaryList.Add(salary);

                            System.Console.WriteLine("Enter Employee Salary");
                            salary.Salary = double.Parse(Console.ReadLine());
                            while (salary.Salary <= 0 || salary.Salary > 1000000 || string.IsNullOrWhiteSpace(salary.Salary.ToString()) || !Regex.IsMatch(salary.Salary.ToString(), @"^[0-9]+(\.[0-9]{1,2})?$"))
                            {
                                Console.WriteLine("Error: Salary should be greater than 0 and less than 1000000.");
                                salary.Salary = double.Parse(Console.ReadLine()?.Trim());
                            }
                            // [5] Store salary (not bonus) - bonus calculated when displaying
                            double salaryBonus = salary.Bonus(salary.Salary);
                            int convert = (int)salaryBonus;
                            salaryList.Add(salary);

                            //bool hasPending = false;
                            // [0] Add employee
                            Console.WriteLine("Enter Employee First Name");
                            salary.FirstName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(salary.FirstName) || !Regex.IsMatch(salary.FirstName, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("Error: name should have letters only. Please re-enter Employee First Name");
                                salary.FirstName = Console.ReadLine();
                            }
                            salaryList.Add(salary);

                            Console.WriteLine("Enter Employee Last Name");
                            salary.LastName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(salary.LastName) || !Regex.IsMatch(salary.LastName, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("Error: name should have letters only.");
                                salary.LastName = Console.ReadLine();
                            }
                            salaryList.Add(salary);
                        }

                        // Hourly Employee.
                        if (readType == "H")
                        {
                            hourly.EmployeeType = "H";
                            while (string.IsNullOrWhiteSpace(hourly.EmployeeType) || Regex.IsMatch(hourly.EmployeeType, @"^[^H]+$"))
                            {
                                Console.WriteLine("Error: Type should be H or S.");
                                hourly.EmployeeType = Console.ReadLine()?.ToUpper();
                            }
                            hourlyList.Add(hourly);

                            System.Console.WriteLine("Enter Employee Hourly Rate");
                            hourly.HRate = double.Parse(Console.ReadLine());
                            while (hourly.HRate <= 0 || hourly.HRate > 1000 || string.IsNullOrWhiteSpace(hourly.HRate.ToString()) || !Regex.IsMatch(hourly.HRate.ToString(), @"^[0-9]+(\.[0-9]{1,2})?$"))
                            {
                                Console.WriteLine("Error: Hourly Rate should be greater than 0 and less than 1000.");
                                hourly.HRate = double.Parse(Console.ReadLine());
                            }
                            // [3] Store rate (not bonus) - bonus calculated when displaying
                            int convert = (int)hourly.HRate;
                            hourlyList.Add(hourly);

                            //bool hasPending = false;
                            // [0] Add employee
                            Console.WriteLine("Enter Employee First Name");
                            hourly.FirstName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(hourly.FirstName) || !Regex.IsMatch(hourly.FirstName, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("Error: name should have letters only. Please re-enter Employee First Name");
                                hourly.FirstName = Console.ReadLine();
                            }
                            hourlyList.Add(hourly);

                            Console.WriteLine("Enter Employee Last Name");
                            hourly.LastName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(hourly.LastName) || !Regex.IsMatch(hourly.LastName, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("Error: name should have letters only.");
                                hourly.LastName = Console.ReadLine();
                            }
                            hourlyList.Add(hourly);
                        }
                    }
                    else if (input == "S")
                    {
                        if (hourly.EmployeeType == "H")
                        {
                            if (string.IsNullOrWhiteSpace(hourly.EmployeeType))
                            {
                            }
                            else
                            {
                                using (StreamWriter read = new StreamWriter(mainFile1, append: true))
                                {
                                    int indexFound = 0;
                                    for (var list = 0; list < hourlyList.Count; list++)
                                    {
                                        if (list < hourlyList.Count && list > 0)
                                        {
                                            indexFound = list;
                                        }
                                    }

                                    if (indexFound != 0)
                                    {
                                        var s = hourlyList[indexFound];
                                        read.WriteLine($"{s.FirstName.PadRight(20)}{s.LastName.PadRight(20)}{s.EmployeeType.PadRight(20)}{s.HRate}"); // write data to file line by line.
                                        Console.WriteLine("Hourly employee data stored successfully.");
                                        // clear after saving
                                        hourlyList.Clear();
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Error: Hourly Empty entries can't be saved.");
                                    }
                                }
                            }
                        }
                        else if (salary.EmployeeType == "S")
                        {

                            while (string.IsNullOrWhiteSpace(salary.EmployeeType) || string.IsNullOrWhiteSpace(hourly.EmployeeType))
                            {
                                System.Console.WriteLine("Error: Hourly or Salary Empty Entry can not be saved");
                            }

                            using (StreamWriter read2 = new StreamWriter(mainFile1, append: true)) // adds data line by line.
                            {

                                int indexFound = 1;
                                for (var list = 0; list < salaryList.Count; list++)
                                {
                                    if (list > 0 && list < salaryList.Count)
                                    {
                                        indexFound = list;
                                    }
                                    if (indexFound != 1)
                                    {
                                        var s = salaryList[indexFound];
                                        read2.WriteLine($"{s.FirstName.PadRight(20)}{s.LastName.PadRight(20)}{s.EmployeeType.PadRight(20)}{s.Salary}"); // write data to file line by line.
                                        Console.WriteLine("Salary employee data stored successfully.");
                                        // clear after saving
                                        salaryList.Clear();
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Error: Salary Empty entries can't be saved.");
                                    }
                                }
                            }
                        }

                        else
                        {
                            System.Console.WriteLine("Error: Wrong choice, cant save Empty entry");
                        }
                    }
                    else if (input == "R")
                    {
                        // Print all employees first name, last name, type, bonus
                        Console.WriteLine("First Name".PadRight(20) + "Last Name".PadRight(20) + "Employee Type".PadRight(20) + "Bonus"); // heading
                        System.Console.WriteLine("----------------------------------------------------------------");
                        List<string> list = File.ReadAllLines(mainFile1).ToList();

                        if (list.Count == 0) // check if file is empty
                        {
                            Console.WriteLine("Error: No data found in the file.");
                            continue;
                        }
                        foreach (var raw in list)
                        {
                            // make sure the line is long enough for 4 columns (80 chars)
                            string line = raw.PadRight(80);

                            string col1 = line.Substring(0, 20).Trim();
                            string col2 = line.Substring(20, 20).Trim();
                            string col3 = line.Substring(40, 20).Trim();
                            string col4 = line.Substring(60, 10).Trim();   // number column

                            if (line.Substring(40, 20).Trim() == "S")
                            {
                                // returns 10% of salary
                                Console.WriteLine($"{col1.PadRight(20)}{col2.PadRight(20)}{col3.PadRight(20)}{int.Parse(col4) * 0.1}");
                            }
                            else if (line.Substring(40, 20).Trim() == "H")
                            {
                                // returns 2 weeks of hourly rate
                                Console.WriteLine($"{col1.PadRight(20)}{col2.PadRight(20)}{col3.PadRight(20)}{int.Parse(col4) * (40 * 2)}");
                            }
                        }

                    }
                    else if (input == "U")
                    {
                        //const int W = 20; // padding from saved data in the file.

                        Console.WriteLine("Enter the index of the employee to update:");
                        string? indexInput = Console.ReadLine();

                        List<string> read = File.ReadAllLines(mainFile1).ToList(); // reading file as a list.
                        int validNum;
                        while (!int.TryParse(indexInput, out validNum) || validNum < 1 || validNum > read.Count)
                        {
                            Console.WriteLine("Error: Invalid index.");
                            indexInput = Console.ReadLine();
                        }

                        // need more pading to avoid breaking the length of the line.
                        string line = read[validNum - 1].PadRight(100);
                        // Just for 1 index base for user friendliness.
                        int indexFound = -1;
                        for (int i = 0; i < read.Count; i++)
                        {
                            indexFound = i;

                        }
                        // If index found, proceed to update.
                        if (indexFound != -1)
                        {

                            // get position of each data in the line.
                            string storeNewFirstName = line.Substring(0, 20).Trim(); // index 0
                            string storeNewLastName = line.Substring(20, 20).Trim(); // next 20 chars
                            string storeNewType = line.Substring(40, 20).Trim(); // next 40 chars
                            string storeNewRate = line.Substring(60, 20).Trim(); // next 60 chars

                            // inner menu for updating
                            Console.WriteLine("Enter 1 ) to update First Name");
                            Console.WriteLine("Enter 2 ) to update Last Name");
                            Console.WriteLine("Enter 3 ) to update Employee Type (H or S)");
                            Console.WriteLine("Enter 4 ) to update Employee Rate/Salary");

                            string? choice = Console.ReadLine();
                            while (choice != "1" && choice != "2" && choice != "3" && choice != "4")
                            {
                                Console.WriteLine("Error: enter 1, 2, 3, or 4:");
                                choice = Console.ReadLine();
                            }

                            // Update by choices.
                            if (choice == "1")
                            {
                                Console.WriteLine("Enter new First Name:");
                                string? newFirstName = Console.ReadLine();
                                while (string.IsNullOrWhiteSpace(newFirstName) || !Regex.IsMatch(newFirstName.Trim(), @"^[a-zA-Z]+$"))
                                {
                                    Console.WriteLine("Error: letters only.");
                                    newFirstName = Console.ReadLine();
                                }
                                storeNewFirstName = newFirstName.Trim();
                            }
                            else if (choice == "2")
                            {
                                Console.WriteLine("Enter new Last Name:");
                                string? newLastName = Console.ReadLine();
                                while (string.IsNullOrWhiteSpace(newLastName) || !Regex.IsMatch(newLastName.Trim(), @"^[a-zA-Z]+$"))
                                {
                                    Console.WriteLine("Error: letters only.");
                                    newLastName = Console.ReadLine();
                                }
                                storeNewLastName = newLastName.Trim();
                            }
                            else if (choice == "3")
                            {
                                Console.WriteLine("Enter new Employee Type (H or S):");
                                string? newType = Console.ReadLine()?.Trim().ToUpper();
                                while (newType != "H" && newType != "S")
                                {
                                    Console.WriteLine("Error: must be H or S.");
                                    newType = Console.ReadLine()?.Trim().ToUpper();
                                }
                                storeNewType = newType!;
                            }
                            else if (choice == "4")
                            {
                                // Baby menue handlimg H and S.
                                if (storeNewType == "H")
                                {
                                    Console.WriteLine("Enter new Hourly Rate:");
                                    string? rateInput = Console.ReadLine();
                                    double newRate;
                                    while (!double.TryParse(rateInput, out newRate) || newRate <= 0 || newRate > 1000 || Regex.IsMatch(rateInput, @"^[^0-9]+$"))
                                    {
                                        Console.WriteLine("Error: Hourly Rate must be more than 0 and less than 1,000$.");
                                        rateInput = Console.ReadLine();
                                    }
                                    storeNewRate = newRate.ToString();
                                }
                                else if (storeNewType == "S")
                                {
                                    Console.WriteLine("Enter new Salary:");
                                    string? salInput = Console.ReadLine();
                                    double newSalary;
                                    while (!double.TryParse(salInput, out newSalary) || newSalary <= 1000 || newSalary > 500000 || Regex.IsMatch(salInput, @"^[^0-9]+$"))
                                    {
                                        Console.WriteLine("Error: salary must be more than 1,000 and less than 500,000$.");
                                        salInput = Console.ReadLine();
                                    }
                                    storeNewRate = newSalary.ToString();
                                }
                            }
                            // useing string format to maintain padding
                            read[validNum - 1] = string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", storeNewFirstName, storeNewLastName, storeNewType, storeNewRate).TrimEnd();


                            // Save file
                            File.WriteAllLines(mainFile1, read);

                            Console.WriteLine("Employee updated successfully!");
                            Console.WriteLine($"Updated row:\n{read[validNum - 1]}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Index not found.");
                            return;
                        }
                    }
                    else if (input == "D")
                    {
                        // Delete employee
                        List<string> load = File.ReadAllLines(mainFile1).ToList();

                        bool breakOut = false;
                        while (!breakOut)
                        {

                            Console.WriteLine("Enter index to delete");

                            if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                            {

                                if (deleteIndex > 0 && deleteIndex <= load.Count)
                                {

                                    string[] updateWithNewLine = new string[load.Count - 1]; // new array with one less line to append new array after deletion

                                    int j = 0;
                                    for (int i = 0; i < load.Count; i++)
                                    {
                                        if (i == (deleteIndex - 1)) // 1 index base no more 0 index base
                                        {
                                            continue; // do nothing.
                                        }
                                        updateWithNewLine[j] = load[i]; // what is deleted becomes new empty array but in the lase index in the file.

                                        j++;
                                    }

                                    File.WriteAllLines(mainFile1, updateWithNewLine);
                                    Console.WriteLine("Name Deleted Successfully.");
                                    breakOut = true;
                                }
                                else
                                {
                                    Console.WriteLine("Error: deleting choice out of bound");
                                    breakOut = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: input should be a number.");
                            }
                        }
                    }
                }

            } // end of the loop
        }
    }
}
