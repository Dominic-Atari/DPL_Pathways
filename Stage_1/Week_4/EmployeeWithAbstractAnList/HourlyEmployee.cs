using System;

namespace Stage_1.Week_3.z_Competency
{
    public class HourlyEmployee : Employee
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
        public double HRate { get; set; }

        public HourlyEmployee(string employeeType, double hRate, string firstName, string lastName) : base(employeeType, firstName, lastName)
        {
            HRate = hRate;
        }

        // Calculate bonus
        public override double Bonus(double bonus)
        {
            // Hourly, the bonus is two weeks pay (40 hours per week)
            //HRate = HRate * (40 * 2);
            return bonus * (40 * 2);
        }
        public override string ToString()
        {
            return $"{FirstName.PadRight(20)}{LastName.PadRight(20)}{EmployeeType.PadRight(20)}{HRate.ToString()}";
        }
    }
}