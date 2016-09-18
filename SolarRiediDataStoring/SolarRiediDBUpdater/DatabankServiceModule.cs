using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public static class DatabankServiceModule
    {
        public static IDataTableCreator DataTableCreator = new DataTableCreator();
    }
}
