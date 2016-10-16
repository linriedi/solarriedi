using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System;
using System.Collections.Generic;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public interface IDataTableCreator
    {
        string Crete(string text);
        IEnumerable<FiveMinutes> CreateMinutesEntry(string text);
        string CreteDeleteFrom(DateTimeOffset date);
    }
}
