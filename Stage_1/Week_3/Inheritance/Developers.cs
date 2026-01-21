using System;

namespace Inheritance
{
    public class Developers : EmployeesBase
    {
        public string DeveloperName { get; set; }
        public Developers(string developerName, string departmentName, int departmentId, double salary) : base(departmentName, departmentId, salary)
        {
            DeveloperName = developerName;
        }

        public double SalaryWithTax(double es)
        {

            return es = (es * 80) / 100;
        }

        public override string ToString()
        {

            return $"Developer: {DeveloperName} \nDepartment Id: {DepartmentId} \nSalary: {SalaryWithTax(base.Salary)}";
        }
    }

}