using System;
using System.Collections.Generic;
using System.Linq;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Linus.SolarRiedi.Common;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class DataTableCreator : IDataTableCreator
    {
        public IEnumerable<FiveMinutes> CreateMinutesEntry(string text)
        {
            var matrix = CreateTableEntry(text, 2, 77);
            return new DtoCreator().Create(matrix);
        }

        public IEnumerable<Day> CreateDaysEntry(string text)
        {
            var blocks = CreateTableEntry(text);
            return new DtoCreator().CreateForDays(blocks);
        }

        public IEnumerable<Month> CreateMonthsEntry(string text)
        {
            var blocks = CreateTableEntry(text);
            return new DtoCreator().CreateForMonth(blocks);
        }

        public IEnumerable<Year> CreateYearsEntry(string text)
        {
            var blocks = CreateTableEntry(text);
            return new DtoCreator().CreateForYear(blocks);
        }

        private static List<Block> CreateTableEntry(string text)
        {
            var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            return CreateBlocks(lines.RemoveLast().TakeFrom(1));
        }

        private static List<Block> CreateBlocks(IEnumerable<string> lines)
        {
            var linesList = lines.ToList();
            var blocks = new List<Block>();
            Block block = null;
            for(var i = 0; i < linesList.Count(); i++)
            {
                if (i % 7 == 0)
                {
                    block = new Block();
                    blocks.Add(block);
                }
                block.Add(linesList[i].Split(';').ToList());
            }
            return blocks;
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
