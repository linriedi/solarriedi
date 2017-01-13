using Linus.SolarRiedi.DataStoringService;
using Linus.SolarRiedi.DataStoringService.Contracts;
using System;

namespace ReportingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Date:");

            var date = Console.ReadLine();

            var service = new ReadService();

            service.CreateReport(CreateDate(date), @"C:\Users\linri\Desktop");
        }

        private static ReportDate CreateDate(string input)
        {
            var split = input.Split('-');

            var year = int.Parse(split[2]);
            var month = int.Parse(split[1]);
            var day = int.Parse(split[0]);

            return new ReportDate(year, month, day);
        }
    }
}
