using System;
using System.Collections.Generic;


namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Employee> employees = GetEmployees();
      Util.PrintEmployees(employees);
      Util.MakeCSV(employees);
      Util.MakeBadges(employees);
    }

    static List<Employee> GetEmployees()
    {
      List<Employee> employees = new List<Employee>();
      while(true)
      {
        Console.WriteLine("Please Enter A First Name: (leave empty to exit): ");
        string  firstName = Console.ReadLine();
        if( firstName == "")
        {
          break;
        }

        Console.WriteLine("Please Enter Last Name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Please Enter Employee ID: ");
        int id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please Enter Photo URL: ");
        string photoUrl = Console.ReadLine();
        //create a new Employee instance with inputs
        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        employees.Add(currentEmployee);
      }
      return employees;
    }

  }
}