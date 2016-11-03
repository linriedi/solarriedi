using Linus.SolarRiedi.BackEnd.Service.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Linus.SolarRiedi.BackEnd.Service.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private ConcurrentDictionary<int, MeasurementItem> storage = new ConcurrentDictionary<int, MeasurementItem>();

        public MeasurementItem GetSingle(int id)
        {
            MeasurementItem measurement;
            if (this.storage.TryGetValue(id, out measurement))
            {
                return measurement;
            }

            return null;
        }

        public MeasurementItem Add(MeasurementItem item)
        {
            item.Id = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;

            if (this.storage.TryAdd(item.Id, item))
            {
                return item;
            }

            throw new Exception("Adding item not possible.");
        }

        public void Delete(int id)
        {
            MeasurementItem measurement;
            if (this.storage.TryRemove(id, out measurement) == false)
            {
                throw new Exception("Removing item not possible");
            }
        }

        public MeasurementItem Update(int id, MeasurementItem item)
        {
            this.storage.TryUpdate(id, item, GetSingle(id));
            return GetSingle(id);
        }

        public ICollection<MeasurementItem> GetAll()
        {
            return this.storage.Values;
        }

        public int Count()
        {
            return this.storage.Count;
        }
    }
}