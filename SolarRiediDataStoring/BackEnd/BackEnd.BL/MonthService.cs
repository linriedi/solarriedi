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
            return new List<MonthDto>
            {
                new MonthDto { Year = 2016, Month = 1, Producziun = 1000, },
                new MonthDto { Year = 2016, Month = 2, Producziun = 500, }
            };
        }
    }
}
