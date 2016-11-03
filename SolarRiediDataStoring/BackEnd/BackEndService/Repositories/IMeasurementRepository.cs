using System.Collections.Generic;
using Linus.SolarRiedi.BackEnd.Service.Models;

namespace Linus.SolarRiedi.BackEnd.Service.Repositories
{
    public interface IMeasurementRepository
    {
        MeasurementItem GetSingle(int id);
        MeasurementItem Add(MeasurementItem item);
        void Delete(int id);
        MeasurementItem Update(int id, MeasurementItem item);
        ICollection<MeasurementItem> GetAll();
        int Count();
    }
}
