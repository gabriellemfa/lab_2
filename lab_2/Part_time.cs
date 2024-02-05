using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    // class for part time employees
    public class PartTime : Employee
    {
        //additional properties
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }


        // constructr
        public PartTime(string employeeID, string name, string sin, double hourlyRate, int hoursWorked)
            : base(employeeID, name, sin)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

       
        //override the method to calculate weekly pay
        public override double CalculateWeeklyPay()
        {
            return HourlyRate * HoursWorked;
        }
    }
}
