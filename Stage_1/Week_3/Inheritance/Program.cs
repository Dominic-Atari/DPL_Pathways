using System;
using System.Reflection;

namespace Inheritance
{

    public class Employees
    {
        static void Main(string[] args)
        {
            Developers employees = new Developers("Dominic", "Software Developers", 101, 3360.0);
            Console.WriteLine("");
            Console.WriteLine(employees.DepartmentName);
            Console.WriteLine(employees);

            Managers managers = new Managers("Jason Hadson", "Managers", 101, 5360.0);
            Console.WriteLine("");
            Console.WriteLine(managers.DepartmentName); // display department first
            Console.WriteLine(managers); // output
        }
    }
}