using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System;
using System.Collections.Generic;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public interface IDataTableCreator
    {
        IEnumerable<FiveMinutes> CreateMinutesEntry(string text);
        string CreteDeleteFrom(string tableName, DateTimeOffset date);
    }
}
