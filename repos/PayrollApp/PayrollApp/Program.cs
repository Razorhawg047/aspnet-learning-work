using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PayrollApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            Filereader fr = new Filereader();
            int month = 0, year = 0;

            while (year == 0)
            {
                Console.Write("\nPlease enter the year:");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Please Try again");
                }
            }

            while (month == 0)
            {
                Console.Write("\nPlease enter the month:");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());

                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Month must be from 1 to 12. Please try again.");
                        month = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Please try again.");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i<myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine($"\nEnter hours worked for {0} ",myStaff[i].NameOfStaff);
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[1].CalculatePay();

                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            Payslip ps = new Payslip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.Read();
        }
    }
}