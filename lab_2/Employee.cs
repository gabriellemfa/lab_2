using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    // Base class representing an employee
    public class Employee
    {
        // fields
        private string employeeID;
        private string name;
        private string sin;


        // properties
        public string EmployeeID
        {
            get { return employeeID; }
            private set { employeeID = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string SIN
        {
            get { return sin; }
            private set { sin = value; }
        }

        // constructor
        public Employee(string employeeID, string name, string sin)
        {
            EmployeeID = employeeID;
            Name = name;
            SIN = sin;
        }


        // method to calculate defult weekly pay to be overriden by sublasses 
        public virtual double CalculateWeeklyPay()
        {
            return 0.0;
        }
    }
}
