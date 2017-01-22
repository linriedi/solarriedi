using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Linus.SolarRiedi.Common;
using Linus.SolarRiedi.ExcelAdapter.Contracts;
using Linus.SolarRiedi.DataStoringService.Contracts;
using System.Threading.Tasks;
using System;

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
        }

        public async Task CreateReport(string date, string path)
        {
            var mesurements = await this.client.GetMeasurements(date);

            var split = date.Split('.');
            int day = int.Parse(split[0]);
            int month = int.Parse(split[1]);
            int year = int.Parse(split[2]);

            var reportDate = new ReportDate(year, month, day);
            this.excelWriter.WriteDayReport(mesurements, path, reportDate);
        }
    }
}
