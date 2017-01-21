using System.Collections.Generic;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Linus.SolarRiedi.Common;
using Linus.SolarRiedi.ExcelAdapter.Contracts;
using Linus.SolarRiedi.DataStoringService.Contracts;
using System.Threading.Tasks;

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

        public async Task CreateReport(string date, string path)
        {
            var mesurements = await this.GetMeasurements(date);

            var split = date.Split('.');
            int day = int.Parse(split[0]);
            int month = int.Parse(split[1]);
            int year = int.Parse(split[2]);

            var reportDate = new ReportDate(year, month, day);
            this.excelWriter.Write(mesurements, path, reportDate);
        }

        private async Task<IEnumerable<IEnumerable<string>>> GetMeasurements(string date)
        {
            return await this.client.GetMeasurements(date);
        }
    }
}
