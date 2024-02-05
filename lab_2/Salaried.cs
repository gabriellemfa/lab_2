using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    // Class representing a salaried employee
    public class Salaried : Employee
    {

        // additional property
        public double WeeklySalary { get; set; }


        // constructor
        public Salaried(string employeeID, string name, string sin, double weeklySalary)
            : base(employeeID, name, sin)
        {
            WeeklySalary = weeklySalary;
        
        }

        //override the method to calculate weekly pay
        public override double CalculateWeeklyPay()
        {
            return WeeklySalary;
        }
    }

}
