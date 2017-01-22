using System.Collections.Generic;
using System.Linq;

namespace Linus.SolarRiedi.ExcelAdapter.Contracts
{
    public class MeasurementsYear
    {
        public string Year { get; private set; }
        public double[] Production = new double[12];
        public int Count { get; }

        public MeasurementsYear(string year, IEnumerable<double> production)
        {
            this.Count = 12;
            this.Year = year;

            var productionList = production.ToList();
            var providedValueCount = productionList.Count;

            for(int i = 0; i < this.Production.Length; i++)
            {
                if(i < providedValueCount)
                {
                    this.Production[i] = productionList[i];
                }
                else
                {
                    this.Production[i] = -1;
                }
            }
        }

        public bool Match(string year)
        {
            return year == this.Year;
        }

        public void AddMonth(int month, double value)
        {
            this.Production[month - 1] = value;
        }
    }
}
