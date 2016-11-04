using System;
using System.Collections.Generic;
using Linus.SolarRiedi.BackEnd.Contracts;
using Linus.SolarRiedi.BackEnd.DataAccess.Contracts;

namespace Linus.SolarRiedi.BackEnd.BL
{
    public class MonthService : IMonthService
    {
        private readonly IDataAccess dataAccess;

        public MonthService(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public IEnumerable<MonthDto> GetAll()
        {
            return this.dataAccess.GetAllMonthMeasurements();
        }
    }
}
