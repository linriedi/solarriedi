﻿using Linus.SolarRiedi.BackEnd.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.BackEnd.DataAccess.Contracts
{
    public interface IDataAccess
    {
        IEnumerable<MonthDto> GetAllMonthMeasurements();
    }
}
