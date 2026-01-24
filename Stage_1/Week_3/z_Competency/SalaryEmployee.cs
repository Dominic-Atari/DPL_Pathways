using System;

namespace Stage_1.Week_3.z_Competency
{
    public class SalaryEmployee : Employee
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
        public double Salary { get; set; }

        public SalaryEmployee(string firstName, string lastName, string employeeType, double salary) : base(firstName, lastName, employeeType)
        {
            //Salary = salary;
            Salary = salary;
        }

        public override double Bonus(double bonus)
        {
            Salary = bonus * 0.1;
            return Salary;
        }

        // Override to string method
        public override string ToString()
        {
            return $"{FirstName.PadRight(20)}{LastName.PadRight(20)}{EmployeeType.PadRight(20)}{Salary}";
        }
    }
}