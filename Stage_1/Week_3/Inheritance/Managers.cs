using System;
using Microsoft.VisualBasic;

namespace Inheritance
{
    public class Managers : EmployeesBase
    {
        public string ManagerName { get; set; }

        public Managers(string managerName, string departmentName, int departmentId, double salary) : base(departmentName, departmentId, salary)
        {
            ManagerName = managerName;
        }


        public double SalaryWithTax(double ms)
        {
            return ms = (ms * 82) / 100;
        }

        public override string ToString()
        {
            return $"Manager Name: {ManagerName} \nDepartmentId: {DepartmentId} \nSalary: {SalaryWithTax(base.Salary)}";
        }
    }
}