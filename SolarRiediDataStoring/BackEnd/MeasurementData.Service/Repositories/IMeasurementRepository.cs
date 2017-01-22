using System.Collections.Generic;
using Linus.SolarRiedi.BackEnd.Service.Models;

namespace Linus.SolarRiedi.BackEnd.Service.Repositories
{
    public interface IMeasurementRepository
    {
        IEnumerable<IEnumerable<string>> GetMeasurements(ReportDate date);
        IEnumerable<IEnumerable<string>> GetYearMeasurements();
    }
}
