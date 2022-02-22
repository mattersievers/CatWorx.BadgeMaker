using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker {
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
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

        public static List<Employee> GetFromAPI()
        {
            List<Employee> employees = new List<Employee>();
            using(WebClient client = new WebClient())
            {
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                foreach(JToken person in json.SelectToken("results"))
                {
                    Employee employee = new Employee(
                        person.SelectToken("name.first").ToString(),
                        person.SelectToken("name.last").ToString(),
                        Int32.Parse(person.SelectToken("id.value").ToString().Replace("-", "")),
                        person.SelectToken("picture.large").ToString()
                    );
                    employees.Add(employee);
                }
                
            }
            return employees;
        }
    
    }

}