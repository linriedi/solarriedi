using System.Collections.Generic;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Common;

namespace Linus.SolarRiedi.DataStoringService
{
    public class ReadService
    {
        private readonly IReadDBService readService;

        public ReadService(IReadDBService readService)
        {
            this.readService = readService;
        }

        public void CreateReport(ReportDate date, string path)
        {
            var mesurements = this.GetMeasurements(date);
        }

        private IEnumerable<IEnumerable<string>> GetMeasurements(ReportDate date)
        {
            return this.readService.GetMeasurements(date);
        }
    }
}
