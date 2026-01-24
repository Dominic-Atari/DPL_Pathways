using System;

namespace Stage_1.Week_3.z_Competency
{
    public class Employee
    {
        /*
            Each employee will have a last name, first name and employee type (hourly or salary).
            An hourly employee will have an hourly rate. 
            A salary employee will have an annual salary.
            Bonuses are calculated as followed:
            If not hourly or salary, the bonus is 0.
            Hourly, the bonus is two weeks pay (40 hours per week)
            Salary, the bonus is 10%
        */

        // Encapsulate properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeType { get; set; }


        // display file content constructor

        public Employee()
        {

        }
        public Employee(string[] lines)
        {
            FirstName = lines[0];
            LastName = lines[1];
            EmployeeType = lines[2];

        }

        // polymorphism
        public virtual double Bonus(double bonus)
        {
            return 0; // if not hourly or salary, bonus is 0
        }
        // constructor to access the properties through get and set.
        public Employee(string firstName, string lastName, string employeeType)
        {
            FirstName = firstName;
            LastName = lastName;
            EmployeeType = employeeType;
        }
    }
}