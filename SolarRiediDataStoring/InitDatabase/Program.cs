using Linus.SolarRiedi.DbConnectionService;
using Linus.SolarRiedi.Settings;
using Linus.SolarRiedi.SolarRiediDBUpdater;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new DatabankService(
                    new SettingsProvider(),
                    null,
                    new ConnectionService(),
                    DatabankServiceModule.DataTableCreator);


            service.Insert(new List<FiveMinutes>
            {
                FiveMinutes.Create(),
                FiveMinutes.Create(),
            });
            //service.Insert(0, 1, "text");
            //service.Select(500, 1000);
            //service.Delete(200, 100000);

            Console.ReadLine();
        }
    }
}
