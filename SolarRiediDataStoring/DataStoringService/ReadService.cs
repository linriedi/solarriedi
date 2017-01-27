using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Linus.SolarRiedi.Common;
using Linus.SolarRiedi.ExcelAdapter.Contracts;
using Linus.SolarRiedi.DataStoringService.Contracts;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Linus.SolarRiedi.DataStoringService
{
    public class ReadService : IReadService
    {
        private readonly WebApiClient client;
        private readonly IExcelWriter excelWriter;
        
        public ReadService(IReadDBService readService, IExcelWriter excelWriter)
        {
            this.excelWriter = excelWriter;
            this.client = new WebApiClient();
        }

        public async Task CreateFullReport(string path)
        {
            var measurements = await this.client.GetYearMeasurements();
            var matrix = CreateMatrix(measurements);
            this.excelWriter.WriteFullReport(matrix, path);
        }

        public async Task CreateReport(string date, string path)
        {
            var mesurements = await this.client.GetMeasurements(date);
            var reportDate = CreateReportDate(date);
            this.excelWriter.WriteDayReport(mesurements, path, reportDate);
        }

        public async Task CreateMonthReport(string date, string path)
        {
            var mesurements = await this.client.GetMonthMeasurements(date);
            var reportDate = CreateReportDate(date);
            this.excelWriter.WriteMonthReport(mesurements, path, reportDate);
        }

        private static ReportDate CreateReportDate(string date)
        {
            var split = date.Split('.');
            int day = int.Parse(split[0]);
            int month = int.Parse(split[1]);
            int year = int.Parse(split[2]);

            var reportDate = new ReportDate(year, month, day);
            return reportDate;
        }

        private static IEnumerable<MeasurementsYear> CreateMatrix(IEnumerable<IEnumerable<string>> measurementsInput)
        {
            var measurements = new List<MeasurementsYear>();
            foreach(var row in measurementsInput)
            {
                AddTo(measurements, row.ToList());
            }
            return measurements;
        }

        private static void AddTo(List<MeasurementsYear> measurements, IList<string> measurement)
        {
            var year = GetYear(measurement.First());
            var month = GetMonth(measurement.First());

            var actualYear = measurements.SingleOrDefault(y => y.Match(year));
            if (actualYear == null)
            {
                actualYear = new MeasurementsYear(year, new List<double>());
                measurements.Add(actualYear);
            }

            actualYear.AddMonth(month, GetTotalProduction(measurement));
        }

        private static double GetTotalProduction(IList<string> measurement)
        {
            var value =
                double.Parse(measurement[2])
                + double.Parse(measurement[3])
                + double.Parse(measurement[4])
                + double.Parse(measurement[5])
                + double.Parse(measurement[6])
                + double.Parse(measurement[7]);
            return value / 1000;
        }

        private static string GetYear(string value)
        {
            return (int.Parse(value) / 100).ToString();
        }

        private static int GetMonth(string value)
        {
            return int.Parse(value) % 100;
        }
    }
}
