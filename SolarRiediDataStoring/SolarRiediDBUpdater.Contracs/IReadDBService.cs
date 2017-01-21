using Linus.SolarRiedi.Common;
using System.Collections.Generic;

namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public interface IReadDBService
    {
        IEnumerable<IEnumerable<string>> GetMeasurements(ReportDate date);
    }
}
