using System.Collections.Generic;

namespace Linus.SolarRiedi.BackEnd.Contracts
{
    public interface IMonthService
    {
        IEnumerable<MonthDto> GetAll();
    }
}
