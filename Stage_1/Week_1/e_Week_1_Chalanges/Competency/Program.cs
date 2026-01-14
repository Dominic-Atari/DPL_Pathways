using System;
using System.Text.RegularExpressions;
public class Competency
{
    static void Main(string[] args)
    {

        /*  The instructor will provide the number of students for which grades need to be calculated.  
            This number must be at least one.
            For each student, the instructor will provide five homework grades, three quiz grades, and two exam grades.  
            All grades must be between 0 and 100 inclusively.
            A student's final grade average is calculated by adding together 50% of the homework average, 30% of the quiz average and 20% of the exam average.
            A student's final grade is calculated  based on the final grade average.  
            If it is 90% or greater, it is an A; 80% or better is a B; 70% or better is a C; 60% or better is a D; and anything less than 60% is an F.
            Once calculated, the program will display the student's name, homework average, quiz average, exam average, final average and final grade.

            promt: enter atlist one student or -0 to Exit
                do
                    read line 
                    if: to parse read line to int
                        if parsed int is > 0
                            for loop (outer) to enter home work 5 time

                                NAME
                                do
                                    promt: enter name
                                    read line as string
                                    if - is emty, all not to characte, one letter and  above 50 characters: Error
                                    else if - not an int accept any input
                                    store the input
                                    exit the loop
                                while
                                    increase the number of students (pased the conditions in the loop)

                                    if - number in the loop in greater than the stored number of students

                                        HOME WORK
                                        for loop (first inner loop)
                                            do
                                                Promt: Enter students home work
                                                string home Work Input
                                                convert to int
                                                if - number is not on range: Error
                                                else - log the number
                                                add the number to the variables
                                                exit the loop
                                            while
                                            do the calculation (based on the condition within the loop)
                                            log the result

                                                QUIZE
                                                for loop (second inner loop)
                                                    do
                                                        Promt: Enter students quiz
                                                        string quiz Input
                                                        convert to int
                                                        if - number is not on range: Error
                                                        else - log the number
                                                        add the number to the variables
                                                        exit the loop
                                                    while
                                                    do the calculation (based on the condition within the loop)
                                                    log the result

                                                        EXAM
                                                        for loop (third inner loop)
                                                            do
                                                                Promt: Enter students exam
                                                                string exam Input
                                                                convert to int
                                                                if - number is not on range: Error
                                                                else - log the number
                                                                add the number to the variables
                                                                exit the loop
                                                            while
                                                            do the calculation (based on the condition within the loop)
                                                            log the result

                                    if s counter in loop in equal to the students entered - exit the entire program. 

                                    CALCULATE TOTAL AVARAGE.
                                    sting to hold grade
                                    if to validate range
                                    pring Student name
                                    avarages
                                    and grade.

                                log the home work
                                calculate the avarage
                        else - Error.       

                    else - Error.

                while



             */
        Console.WriteLine("enter number of students you want to calculate their avarage or -0 to exit");
        int numberOfStudents = 0;
        int homeWorkValidNum = 0;
        int homeWorkTotal = 0;
        double homeWorkAvarage = 0;

        //double quize = 0;
        int quizeValidNum = 0;
        double quizeTotal = 0;
        double quizeAvarage = 0;

        //double exam = 0;
        double examTotal = 0;
        double examAvarage = 0;
        int examValidateNum = 0;

        string storeStudentsNames = "";

        double finalAvarage = 0;

        bool stop = false;
        do
        {



            string? input = Console.ReadLine();

            if (int.TryParse(input, out int students))
            {
                Exit(input);

                if (students > 0) // student must be entred
                {
                    for (int s = 1; s <= students; s++) // loop to go 5 times as needed
                    {
                        bool validName = false;
                        do
                        {
                            
                            Console.WriteLine("Enter student name");
                            string? name = Console.ReadLine();

                            Exit(input); // exit method.
                            if(string.IsNullOrWhiteSpace(name) || name.Length < 2 || name.Length > 50) // check for null, empty || range for the string name.
                            {
                                Console.WriteLine("Invalid name. Please enter a name with only letters and between 2 and 50 characters.");
                            } 
                            else if(Regex.IsMatch(name, @"^[a-zA-Z]+$")) // only letters are allowed.
                            {
                                
                                storeStudentsNames = name;
                                validName = true;
                            }
                        
                        }while(!validName);

                        numberOfStudents++;
                        if (s <= numberOfStudents)
                        {

                            // HOME WORK.
                            for (int h = 1; h < 6; h++)
                            {
                                Console.WriteLine("Enter Home Work grades or -0 to exit");
                                var homeWorkGrade = GetValidQuize();
                                Console.WriteLine($"[{h}] Home work is = {homeWorkGrade}");
                                homeWorkTotal += homeWorkGrade;
                            }
                            //home work average calculation
                            homeWorkAvarage = (homeWorkTotal / 5.0) * 0.5;
                            Console.WriteLine("Home work average is = " + Math.Round(homeWorkAvarage));

                            // QUIZE
                            for (int q = 1; q < 4; q++)
                            {
                                Console.WriteLine("Enter Quize grade or -0 to exit");
                                int quizeGrade = GetValidQuize();
                                Console.WriteLine($"[{q}] Quize is = {quizeGrade}");
                                quizeTotal += quizeGrade;
                                
                            }
                            // quize avarage calculationn
                            quizeAvarage = (quizeTotal / 3.0) * 0.3;
                            Console.WriteLine($"Quze avarage is = {Math.Round(quizeAvarage)}");

                            // EXAM
                            for (int e = 1; e < 3; e++)
                            {
                                Console.WriteLine("Enter Exam grade or -0 to exit");
                                var examGrade = GetValidQuize();
                                Console.WriteLine($"[{e}] Exam is = {examGrade}");
                                examTotal += examGrade;
                            }
                            // exam avarage calculation.
                            examAvarage = (examTotal / 2.0) * 0.2;
                            Console.WriteLine("Exam avarage is = " + Math.Round(examAvarage));

                        }
                        // exit the loop if s in the for loop equals to students entered
                        if (s == students)
                        {
                            stop = true;
                        }

                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Name: " + storeStudentsNames);
                        Console.WriteLine("Home work avarage = " + Math.Round(homeWorkAvarage));
                        Console.WriteLine("Quize avarage = " + Math.Round(quizeAvarage));
                        Console.WriteLine("Exam avarage = " + Math.Round(examAvarage));

                        finalAvarage = (homeWorkAvarage + quizeAvarage + examAvarage) / numberOfStudents;
                        Console.WriteLine($"Final avarage = {Math.Round(finalAvarage)}%");

                        string finalGrade; // to read user input and compare to grade in string format.
                        if (finalAvarage >= 90)
                        {
                            finalGrade = "A";
                        }
                        else if (finalAvarage >= 80)
                        {
                            finalGrade = "B";
                        }
                        else if (finalAvarage >= 70)
                        {
                            finalGrade = "C";
                        }
                        else if (finalAvarage >= 60)
                        {
                            finalGrade = "D";
                        }
                        else
                        {
                            finalGrade = "F";
                        }

                        Console.WriteLine($"Final grade = {finalGrade}");
                        Console.WriteLine("----------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Enter at least one student.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        } while (!stop);
    }
    // handles inputs and range validation.
    static int GetValidQuize()
    {
        int min = 0; 
        int max = 100;
        int quizeValidNum = 0;
        bool validQuize = false;
        do
        {
            
            string? input = Console.ReadLine();

            Exit(input); // exit calles.

            if (int.TryParse(input, out quizeValidNum) && quizeValidNum >= min && quizeValidNum <= max)
            {
                validQuize = true;  // exits the do-while loop if the logi passes.
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }   
        } while (!validQuize);
        return quizeValidNum;
    }
    // methos to handle exit.
    static void Exit(string input)
    {
        if (input == "-0") // this reads the input befor it is try parsed.
        {
            Environment.Exit(-0); // automat convert input to int and run the execution.
        }
    }
}