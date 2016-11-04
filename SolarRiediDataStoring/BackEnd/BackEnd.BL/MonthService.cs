using System.Collections.Generic;
using Linus.SolarRiedi.BackEnd.Contracts;

namespace Linus.SolarRiedi.BackEnd.BL
{
    public class MonthService : IMonthService
    {
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
