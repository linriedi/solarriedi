using Linus.SolarRiedi.BackEnd.DataAccess.Contracts;
using Linus.SolarRiedi.DBConnection.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.BackEnd.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IRunSqlCommand runSqlCommand;

        public DataAccess(IRunSqlCommand runSqlCommand)
        {
            this.runSqlCommand = runSqlCommand;
        }
    }
}
