using System;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;

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
            Employee employee = new Employee(string.Empty, string.Empty, string.Empty);
            HourlyEmployee hourly = new HourlyEmployee(string.Empty, string.Empty, string.Empty, 0.0);
            SalaryEmployee salary = new SalaryEmployee(string.Empty, string.Empty, string.Empty, 0.0);
            string storeFistName = "";
            string storeLastName = "";
            string storeType = "";
            double storeEarnings = 0.0;
            double storeRate = 0.0;

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
                                    } // end of the loop.
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
                        // Add employee
                        Console.WriteLine("Enter Employee First Name");
                        hourly.FirstName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(hourly.FirstName) || !Regex.IsMatch(hourly.FirstName, @"^[a-zA-Z]+$"))
                        {
                            Console.WriteLine("Error: name should have latters only. Please re-enter Employee First Name");
                            hourly.FirstName = Console.ReadLine();
                        }

                        storeFistName = hourly.FirstName;


                        Console.WriteLine("Enter Employee Last Name");
                        hourly.LastName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(hourly.LastName) || !Regex.IsMatch(hourly.LastName, @"^[a-zA-Z]+$"))
                        {
                            Console.WriteLine("Error: name should have latters only. Please re-enter Employee Last Name");
                            hourly.LastName = Console.ReadLine();
                        }

                        storeLastName = hourly.LastName;

                        Console.WriteLine("Enter Employee Type");
                        employee.EmployeeType = Console.ReadLine().ToUpper();
                        while (string.IsNullOrWhiteSpace(employee.EmployeeType) || Regex.IsMatch(employee.EmployeeType, @"^[^HS]+$"))
                        {
                            Console.WriteLine("Error: Type should be H or S. Please re-enter Employee Type");
                            employee.EmployeeType = Console.ReadLine().ToUpper();
                        }
                        storeType = employee.EmployeeType;
                        if (employee.EmployeeType == "H")
                        {
                            // salary.EmployeeType = "H";
                            System.Console.WriteLine("Enter Employee Hourly Rate");
                            hourly.HRate = double.Parse(Console.ReadLine());
                            while (hourly.HRate <= 0 || hourly.HRate > 1000 || string.IsNullOrWhiteSpace(hourly.HRate.ToString()) || !Regex.IsMatch(hourly.HRate.ToString(), @"^[0-9]+([0-9]{1,2})?$"))
                            {
                                Console.WriteLine("Error: Hourly Rate should be greater than 0 and less than 1000. Please re-enter Employee Hourly Rate");
                                hourly.HRate = double.Parse(Console.ReadLine());
                            }
                            storeEarnings = hourly.HRate;
                        }
                        else if (employee.EmployeeType == "S")
                        {
                            // salary.EmployeeType = "S";
                            System.Console.WriteLine("Enter Employee Salary");
                            salary.Salary = double.Parse(Console.ReadLine());
                            while (salary.Salary <= 0 || string.IsNullOrWhiteSpace(salary.Salary.ToString()) || !Regex.IsMatch(salary.Salary.ToString(), @"^[0-9]+(\.[0-9]{1,2})?$")) // no characters allowed
                            {
                                Console.WriteLine("Error: Salary should be greater than 0. Please re-enter Employee Salary");
                                salary.Salary = double.Parse(Console.ReadLine());
                            }
                            storeEarnings = salary.Salary;
                        }
                        else
                        {
                            Console.WriteLine($"Type is noly {"H"} or {"S"}");
                        }

                    }
                    else if (input == "S")
                    {
                        // Store data in the file
                        if (employee.EmployeeType == "S")
                        {
                            Employee salaryE = new SalaryEmployee(storeFistName, storeLastName, storeType, storeEarnings);

                            using (StreamWriter read = new StreamWriter(mainFile1, append: true))
                            {
                                read.WriteLine(salaryE); // write data to file line by line.

                                // clear after saving
                                storeFistName = "";
                                storeLastName = "";
                                storeType = "";
                                storeEarnings = 0.0;

                                if (storeFistName == "")
                                {
                                    Console.WriteLine("Error: No employee data to store.");
                                }
                            }
                        }
                        else if (employee.EmployeeType == "H")
                        {
                            Employee hourlyE = new HourlyEmployee(storeFistName, storeLastName, storeType, storeEarnings);

                            using (StreamWriter read = new StreamWriter(mainFile1, append: true))
                            {
                                read.WriteLine(hourlyE); // write data to file line by line.

                                // clear after saving
                                storeFistName = "";
                                storeLastName = "";
                                storeType = "";
                                storeEarnings = 0.0;

                                if (storeFistName == "")
                                {
                                    Console.WriteLine("Error: No employee data to store.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: No employee data to store. Please add employee first.");
                        }


                    }
                    else if (input == "R")
                    {
                        // Print all employees first name, last name, type, bonus
                        Console.WriteLine("First Name".PadRight(20) + "Last Name".PadRight(20) + "Employee Type".PadRight(20) + "Bonus"); // heading
                        System.Console.WriteLine("----------------------------------------------------------------");
                        string[] list = File.ReadAllLines(mainFile1);


                        foreach (var raw in list)
                        {
                            // make sure the line is long enough for 4 columns (80 chars)
                            //

                            string line = raw.PadRight(80);

                            string col1 = line.Substring(0, 20).Trim();
                            string col2 = line.Substring(20, 20).Trim();
                            string col3 = line.Substring(40, 20).Trim();
                            string col4 = line.Substring(60, 10).Trim();   // <-- number column

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

                        string[] read = File.ReadAllLines(mainFile1);
                        int validNum;
                        while (!int.TryParse(indexInput, out validNum) || validNum < 0 || validNum >= read.Length)
                        {
                            Console.WriteLine("Error: Invalid index.");
                            indexInput = Console.ReadLine();
                        }

                        // need more pading to avoid breaking the length of the line.
                        string line = read[validNum - 1].PadRight(100);
                        // Just for 1 index base for user friendliness.
                        int indexFound = -1;
                        for (int i = 0; i < read.Length; i++)
                        {
                            indexFound = i;

                        }
                        // If index found, proceed to update.
                        if (indexFound != -1)
                        {

                            // get position of each data in the line.
                            string storeNewFirstName = line.Substring(0, 20).Trim(); // first 20 chars
                            string storeNewLastName = line.Substring(20, 20).Trim(); // next 20 chars
                            string storeNewType = line.Substring(40, 20).Trim(); // next 20 chars
                            string storeNewRate = line.Substring(60, 20).Trim(); // next 20 chars

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
                            read[validNum - 1] = string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", storeNewFirstName, storeNewLastName, storeNewType, storeNewRate);

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
                        string[] load = File.ReadAllLines(mainFile1);

                        bool breakOut = false;
                        while (!breakOut)
                        {

                            Console.WriteLine("Enter index to delete");

                            if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                            {

                                if (deleteIndex > 0 && deleteIndex <= load.Length)
                                {

                                    string[] updateWithNewLine = new string[load.Length - 1];

                                    int j = 0;
                                    for (int i = 0; i < load.Length; i++)
                                    {
                                        if (i == (deleteIndex - 1)) // 1 index base no more 0 index base
                                        {
                                            continue;
                                        }
                                        updateWithNewLine[j] = load[i];

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
