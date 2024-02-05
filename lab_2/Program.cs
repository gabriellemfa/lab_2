using System;
using System.Collections.Generic;
using System.IO; // added namspace enable to use SteamReader
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    

    class Program
    {
        static void Main(string[] args)
        {
            // load employee data from employee.txt file
            List<Employee> employees = FillEmployeeList("employees.txt");


            // im testing to see how many employees on list
            Console.WriteLine($"There are currently {employees.Count} employees in the file.\n");

            //calculate and show average weekly pay
            double averageWeeklyPay = CalculateAverageWeeklyPay(employees);
            Console.WriteLine($"Average Weekly Pay: {averageWeeklyPay}");


            //calculate and show highest weekly pay for a waged employee
            (double maxWeeklyPay, string employeeName) = CalculateHighestWeeklyPayForWages(employees);
            Console.WriteLine($"Highest Weekly Pay for Wage Employee is: {maxWeeklyPay} for employee: {employeeName}");


            //calculate and show lowest weekly pay for a salaried employee
            (double minSalary, string salariedEmployeeName) = CalculateLowestSalaryForSalaried(employees);
            Console.WriteLine($"Lowest Salary for Salaried Employee is: {minSalary} for employee: {salariedEmployeeName}\n");

            CalculatePercentageOfEmployeesByCategory(employees);
            Console.ReadLine();

        }

        // private static method to fill the list of emplotees from file
        private static List<Employee> FillEmployeeList(string filePath)
        {
            List<Employee> employees = new List<Employee>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }


                    string[] data = line.Split(':');

                    //all lines in the txt file are > 9

                    string employeeID = data[0];
                    string name = data[1];
                    string sin = data[4];

                    //creates appropriate employee object based on the beginning of employee ID numbers

                    if (employeeID.StartsWith("0") || employeeID.StartsWith("1") || employeeID.StartsWith("2") || employeeID.StartsWith("3") || employeeID.StartsWith("4"))
                    {
                        double weeklySalary = double.Parse(data[7]);
                        employees.Add(new Salaried(employeeID, name, sin, weeklySalary));
                    }
                    else if (employeeID.StartsWith("5") || employeeID.StartsWith("6") || employeeID.StartsWith("7"))
                    {
                        double hourlyRate = double.Parse(data[7]);
                        int hoursWorked = int.Parse(data[8]);
                        employees.Add(new Wage(employeeID, name, sin, hourlyRate, hoursWorked));
                    }
                    else if (employeeID.StartsWith("8") || employeeID.StartsWith("9"))
                    {
                        double hourlyRate = double.Parse(data[7]);
                        int hoursWorked = int.Parse(data[8]);
                        employees.Add(new PartTime(employeeID, name, sin, hourlyRate, hoursWorked));
                    }
                }
            }

            return employees;
        }


        // method to calculate average weekly pay for all employees
        private static double CalculateAverageWeeklyPay(List<Employee> employees)
        {
            double totalWeeklyPay = 0;

            foreach (Employee employee in employees)
            {
                totalWeeklyPay += employee.CalculateWeeklyPay();
            }

            return totalWeeklyPay / employees.Count;
        }

        // method to calculate the highest weekly pay for wage employees
        private static (double, string) CalculateHighestWeeklyPayForWages(List<Employee> employees)
        {
            double maxWeeklyPay = 0;
            string employeeName = "";

            foreach (Employee employee in employees)
            {
                if (employee is Wage wageEmployee)
                {
                    double weeklyPay = wageEmployee.CalculateWeeklyPay();
                    if (weeklyPay > maxWeeklyPay)
                    {
                        maxWeeklyPay = weeklyPay;
                        employeeName = employee.Name;
                    }
                }
            }

            return (maxWeeklyPay, employeeName);
        }


        // method to calculate the lowest salary for salaried employees
        private static (double, string) CalculateLowestSalaryForSalaried(List<Employee> employees)
        {
            double minSalary = double.MaxValue;
            string employeeName = "";

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salariedEmployee)
                {
                    double weeklySalary = salariedEmployee.CalculateWeeklyPay();
                    if (weeklySalary < minSalary)
                    {
                        minSalary = weeklySalary;
                        employeeName = employee.Name;
                    }
                }
            }

            return (minSalary, employeeName);
        }


        // method to calculate the percentage amount of salaried, waged, and part time employees in the list
        private static void CalculatePercentageOfEmployeesByCategory(List<Employee> employees)
        {
            int totalSalaried = 0;
            int totalWages = 0;
            int totalPartTime = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    totalSalaried++;
                }
                else if (employee is Wage)
                {
                    totalWages++;
                }
                else if (employee is PartTime)
                {
                    totalPartTime++;
                }
            }

            int totalEmployees = totalSalaried + totalWages + totalPartTime;

            double percentageSalaried = (double)totalSalaried / totalEmployees * 100;
            double percentageWages = (double)totalWages / totalEmployees * 100;
            double percentagePartTime = (double)totalPartTime / totalEmployees * 100;

            Console.WriteLine($"Percentage of Salaried Employees: {percentageSalaried}%");
            Console.WriteLine($"Percentage of Wage Employees: {percentageWages}%");
            Console.WriteLine($"Percentage of Part-Time Employees: {percentagePartTime}%");
        }

    }
    
}
