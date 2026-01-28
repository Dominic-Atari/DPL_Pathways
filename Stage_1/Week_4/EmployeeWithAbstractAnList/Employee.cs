using System;

namespace Stage_1.Week_3.z_Competency
{
    public abstract class Employee
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

        // polymorphism
        public abstract double Bonus(double bonus);

        // constructor to access the properties through get and set.
        public Employee(string firstName, string lastName, string employeeType)
        {
            FirstName = firstName;
            LastName = lastName;
            EmployeeType = employeeType;
        }
    }
}