using System;

public class Day_1_Chalange
{
    static void Main(string[] args)
    {
        /*
        
            Problem description: 
            Given a two-dimensional array of scores (a column contains the scores for a student), 
            find the average score for each student, and the minimum, maximum and average for the class.
            

            declear int for minimun, maiximum, studentAvarage, classAvarage variables.
            
            Create 2D dinamic array of int called students
            loop through the rows but on GetLength(1) - outer loop
                loop through the columns but on GetLength(0) - inner loop
                    add all the students[i, j] to a varialbe to hold data for AVERAGE.
                    if the minimum is smaller than students[i, j]
                        asign values at students[i, j] to the minimum variables.
                    if the minimum is smaller than students[i, j]
                        asign values at students[i, J] to the maximum and variables
                    add all the students[i, j] to a varialbe to hold data for CLASS AVERAGE.
                find the calculation of each as you print the anser the to console.
                clear maximum and minimum data to start the next student.

        */

        // Console.WriteLine("");
        // Console.WriteLine("");

        // int minimum = int.MinValue;
        // int maximum = int.MaxValue;
        // double studentAvarage = 0.0;
        // double classAverage = 0.0;

        // int rowsNumber = 0;
        // int columnsNumber = 0;


        int[,] students =
                            {
                                { 78, 98, 69, 87, 60, 10},
                                { 90, 80, 76, 65, 100, 66},
                                { 99, 76, 75, 77, 89, 20}
                            };

        double studentTotalScore = 0;
        int studentsNoOfSubjects = 0;

        int minimum = int.MaxValue;
        Console.WriteLine(minimum + " is min value");
        int maximum = int.MinValue;

        int classNumberOfSubjects = 0;
        double classsScore = 0;

        int j = 0;
        do
        {
            //bool exit = true;
            int i = 0;
            do
            {
                // NUM OF SUBJECTS (columns)
                studentsNoOfSubjects = students.GetLength(0);

                //STUDENTS AVERAGE
                studentTotalScore += students[i, j];

                

               

                // CLASS AVERAGE
                // num of subjects (rows).
                classNumberOfSubjects = students.GetLength(1);
                classsScore += students[i, j];

                i++; 

            }while(i < students.GetLength(0));


            int thidStudentAverage = (int)(studentTotalScore / studentsNoOfSubjects);
            // STUDENT MINIMUM
            if (minimum > thidStudentAverage)
            {
                minimum = thidStudentAverage;
            }
            // STUDENT MAXIMUM
            if (maximum < thidStudentAverage)
            {
                maximum = thidStudentAverage;
            }

            Console.WriteLine("student average: " + Math.Round(studentTotalScore / studentsNoOfSubjects));
            studentTotalScore = 0;

            j++;
        }while(j < students.GetLength(1));

        Console.WriteLine($"class average: {Math.Round(classsScore / (classNumberOfSubjects * studentsNoOfSubjects))}");
            Console.WriteLine($"student minimum: {minimum}");
            Console.WriteLine($"student maximum: {maximum}");
            //Console.WriteLine($"student maximum: {classsScore / classNumberOfSubjects}");
            Console.WriteLine("");
    }
}
        // for(int j = 0; j < students.GetLength(1); j++) // columns
        // {

        //     for(int i = 0; i < students.GetLength(0); i++) // rows
        //     {
        //         // STUDENT AVARAHE
        //         studentAvarage += students[i, j];
        //         rowsNumber = students.GetLength(0); // required to get student average.
        //         columnsNumber = students.GetLength(1); // required to ge class average.

        //         // MINIMUM
        //         if(students[i, j] > minimum )
        //         {
                    
        //         minimum = students[i, j];
        //         }
        //         // MAXIMUM
        //         if( maximum < students[i, j])
        //         {
        //             maximum = students[i, j];
        //         }

        //         // CLASS AVERAGE.
        //         classAverage += students[i, j];
        //         //classAverageNum = students[i, j];

        //     }
            
        //         Console.WriteLine($"Student average = {Math.Round(studentAvarage / rowsNumber)}"); // Print avarage.
        //         studentAvarage = 0; // reset back to 0 to aavoid auto increment.

        //         Console.WriteLine($"Student minimum = {minimum}"); // print minimum

        //         Console.WriteLine($"Student maximum = {maximum}"); // print maximum
        //         maximum = 0; // reset maximum back to 0.
        //         Console.WriteLine("");
        // }
        // Console.WriteLine($"Class average = {Math.Round(classAverage / (rowsNumber * columnsNumber))}"); // print class average
        // Console.WriteLine("");
        // Console.WriteLine("");