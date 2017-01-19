using Linus.SolarRiedi.BackEnd.Service.Models;
using System.Collections.Generic;

namespace Linus.SolarRiedi.BackEnd.Service.Repositories
{
    public interface IMeasurementRepository
    {
        IEnumerable<IEnumerable<string>> GetMeasurements(ReportDate date)
    }
}
