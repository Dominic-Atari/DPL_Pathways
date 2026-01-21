using System;

namespace Inheritance
{
    public class EmployeesBase
    {
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public double Salary { get; set; }

        public EmployeesBase(string departmentName, int departmentId, double salary)
        {
            DepartmentName = departmentName;
            DepartmentId = departmentId;
            Salary = salary;
        }

        public double SalaryWithTax(double s)
        {
            return Salary;
        }

        public override string ToString()
        {
            return $"employe name: {DepartmentName} department {DepartmentId} salary: {Salary}";
        }
    }
}