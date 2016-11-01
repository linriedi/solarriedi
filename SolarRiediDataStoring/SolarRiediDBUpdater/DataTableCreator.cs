using System;
using System.Collections.Generic;
using System.Linq;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class DataTableCreator : IDataTableCreator
    {
        public IEnumerable<FiveMinutes> CreateMinutesEntry(string text)
        {
            var matrix = CreateTableEntry(text, 2, 77);
            return new DtoCreator().Create(matrix);
        }

        private static List<List<string>> CreateTableEntry(string text, int startIndexConsum, int endIndexConsum)
        {
            var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var table = new List<List<string>>();
            var names = lines.First().Split(';');
            var isFirstLine = true;
            foreach (var line in lines)
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                }
                else
                {
                    if (line.Length > 0)
                    {
                        var column = line.Split(';');
                        var row = new List<string>();

                        row.Add(column[0]);
                        row.Add(column[1]);
                        for (int i = startIndexConsum; i <= endIndexConsum; i++)
                        {
                            row.Add(column[i]);
                        }
                        table.Add(row);
                    }
                }
            };
            return table;
        }
    }
}
