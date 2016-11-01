using System;
using System.Text;

namespace Common
{
    public static class Time
    {
        public static DateTimeOffset CreateDateTimeFromFileName(string fileName)
        {
            var builder = new StringBuilder(fileName);
            var dateTimeString = builder.ToString(3, 6);
            builder = new StringBuilder(dateTimeString);

            var year = int.Parse(builder.ToString(0, 2)) + 2000;
            var month = int.Parse(builder.ToString(2, 2));
            var day = int.Parse(builder.ToString(4, 2));

            return new DateTimeOffset(year, month, day, 00, 00, 00, TimeSpan.Zero);
        }

        public static int ExtractDateTimeAsIntFromDateTime(DateTimeOffset date)
        {
            int dateAsInt = 0;
            dateAsInt += date.Day;
            dateAsInt += date.Month * 100;
            dateAsInt += (date.Year - 2000) * 10000;
            return dateAsInt * 10000;
        }

        public static int CreateDateTimeAsIntFromString(string date, string time)
        {
            int dateAsInt = 0;
 
            var splitted = date.Split('.');
            dateAsInt += int.Parse(splitted[2]) * 100000000;
            dateAsInt += int.Parse(splitted[1]) * 1000000;
            dateAsInt += int.Parse(splitted[0]) * 10000;

            splitted = time.Split(':');
            dateAsInt += int.Parse(splitted[0]) * 100;
            dateAsInt += int.Parse(splitted[1]);
                
            return dateAsInt;
        }

        public static int CreateDateTimeAsIntFromString(string date)
        {
            int dateAsInt = 0;

            var splitted = date.Split('.');
            dateAsInt += int.Parse(splitted[2]) * 10000;
            dateAsInt += int.Parse(splitted[1]) * 100;
            dateAsInt += int.Parse(splitted[0]);

            return dateAsInt;
        }
    }
}
