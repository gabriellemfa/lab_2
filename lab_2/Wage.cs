using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    // class for wage employees
    public class Wage : Employee
    {
        //additional properties
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        //constructor
        public Wage(string employeeID, string name, string sin, double hourlyRate, int hoursWorked)
            : base(employeeID, name, sin)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }


        //override the method to calculate weekly pay
        public override double CalculateWeeklyPay()
        {
            double regularPay = HourlyRate * HoursWorked;
            double overtimePay = HoursWorked > 40 ? (HoursWorked - 40) * (HourlyRate * 1.5) : 0;
            return regularPay + overtimePay;
        }
    }
}
