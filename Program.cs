using System;
using System.Collections.Generic;


namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Would you like to retrieve data from the API list? (Type 'yes' to retrieve)");
      string type = Console.ReadLine().ToLower();

      if(type == "yes"){
        List<Employee> employees = PeopleFetcher.GetFromAPI();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        Util.MakeBadges(employees);
      } else {
        List<Employee> employees = PeopleFetcher.GetEmployees();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        Util.MakeBadges(employees);
      }
      
    }

    

  }
}