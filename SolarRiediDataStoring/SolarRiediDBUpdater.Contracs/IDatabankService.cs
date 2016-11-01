﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public interface IDatabankService
    {
        void UpdateDatabank();

        void Insert(int date, int production, string messageText);

        void UpdateDatabankOfLastFourDays(string tableName, string filePrefix);
    }
}
