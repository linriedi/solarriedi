using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Common;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class DataTableCreator : IDataTableCreator
    {
        public string Crete(string text)
        {
            var consum = CreateTableEntry(text, 3, 5);

            var prod1 = CreateTableEntry(text, 7, 17);
            var prod2 = CreateTableEntry(text, 19, 29);
            var prod3 = CreateTableEntry(text, 31, 41);
            var prod4 = CreateTableEntry(text, 43, 53);
            var prod5 = CreateTableEntry(text, 55, 65);
            var prod6 = CreateTableEntry(text, 67, 77);

            var builder = new StringBuilder();
            builder.Append(this.CreateInsertString("consum", consum));

            builder.Append(Environment.NewLine);
            builder.Append(this.CreateInsertString("producziunIn", prod1));
            builder.Append(Environment.NewLine);
            builder.Append(this.CreateInsertString("producziunDus", prod2));
            builder.Append(Environment.NewLine);
            builder.Append(this.CreateInsertString("producziunTreis", prod3));
            builder.Append(Environment.NewLine);
            builder.Append(this.CreateInsertString("producziunQuater", prod4));
            builder.Append(Environment.NewLine);
            builder.Append(this.CreateInsertString("producziunTschun", prod5));
            builder.Append(Environment.NewLine);
            builder.Append(this.CreateInsertString("producziunSis", prod6));

            return builder.ToString();
        }

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

        private string CreateInsertString(string tableName, List<List<string>> table)
        {
            var builder = new StringBuilder();
            builder.Append(string.Format("INSERT INTO {0} VALUES ", tableName));

            var rowBuilder = new StringBuilder();
            foreach (var row in table)
            {
                rowBuilder.Append("(");
                rowBuilder.Append(string.Format("'{0} {1}'", row[0], row[1]));
                rowBuilder.Append(", ");
                for (int i = 2; i < row.Count(); i++)
                {
                    rowBuilder.Append(string.Format("{0}, ", row[i]));
                }
                rowBuilder.Remove(rowBuilder.Length - 2, 2);
                rowBuilder.Append("), ");
                
            }

            builder.Append(rowBuilder.ToString());
            builder.Remove(builder.Length - 2, 2);
            return builder.ToString();
        }

        public string CreteDeleteFrom(string tableName, DateTimeOffset date)
        {
            return string.Format("Delete from {0} where datum >= {1}", tableName, Time.ExtractDateTimeAsIntFromDateTime(date));
        }
    }
}
