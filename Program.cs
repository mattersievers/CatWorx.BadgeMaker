using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
{
      List<Employee> employees = GetEmployees();
      PrintEmployees(employees);
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

    static void PrintEmployees(List<Employee> employees)
    {
      for( int i = 0; i < employees.Count; i++)
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
      }
    }
  }
}