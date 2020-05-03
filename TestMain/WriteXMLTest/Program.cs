using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WriteXMLTest
{
    //@example: write class to xml
    public class Employee
    {
        int id;
        string firstName;
        string lastName;
        int salary;

        public Employee(int id, string firstName, string lastName, int salary)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }

    class Program
    {
        //@example: C# lib - write object to xml testing
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[4];
            employees[0] = new Employee(1, "David", "Smith", 10000);
            employees[1] = new Employee(3, "Mark", "Drinkwater", 30000);
            employees[2] = new Employee(4, "Norah", "Miller", 20000);
            employees[3] = new Employee(12, "Cecil", "Walker", 120000);

            using (XmlWriter writer = XmlWriter.Create("employees.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees");

                foreach (Employee employee in employees)
                {
                    writer.WriteStartElement("Employee");

                    writer.WriteElementString("ID", employee.Id.ToString());
                    writer.WriteElementString("FirstName", employee.FirstName);
                    writer.WriteElementString("LastName", employee.LastName);
                    writer.WriteElementString("Salary", employee.Salary.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
