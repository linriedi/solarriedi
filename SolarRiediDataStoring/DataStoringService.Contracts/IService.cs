﻿namespace Linus.SolarRiedi.DataStoringService.Contracts
{
    public interface IService
    {
        void StoreDataOfLastFourDays(string tableName, string filePrefix);
    }
}
