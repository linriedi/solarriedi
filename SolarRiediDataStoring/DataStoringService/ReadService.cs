using System.Collections.Generic;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Common;
using ExcelAdapter.Contracts;

namespace Linus.SolarRiedi.DataStoringService
{
    public class ReadService
    {
        private readonly IExcelWriter excelWriter;
        private readonly IReadDBService readService;

        public ReadService(IReadDBService readService, IExcelWriter excelWriter)
        {
            this.readService = readService;
            this.excelWriter = excelWriter;
        }

        public void CreateReport(ReportDate date, string path)
        {
            var mesurements = this.GetMeasurements(date);
            this.excelWriter.Write(mesurements);
        }

        private IEnumerable<IEnumerable<string>> GetMeasurements(ReportDate date)
        {
            return this.readService.GetMeasurements(date);
        }
    }
}
