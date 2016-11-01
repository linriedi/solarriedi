using System.Text;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System;
using Common;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class SqlCreator
    {
        public string CreteDeleteFrom(string tableName, DateTimeOffset date)
        {
            return string.Format("Delete from {0} where datum >= {1}", tableName, Time.ExtractDateTimeAsIntFromDateTime(date));
        }

        public string CreateDelete(string tableName)
        {
            return string.Format("Delete from {0}", tableName);
        }

        public string Create(string tableName, FiveMinutes fiveMinutes)
        {
            var builder = new StringBuilder();

            builder.Append(string.Format("INSERT INTO {0} VALUES", tableName));

            AppendValues(fiveMinutes, builder);
            builder.Append(", ");

            builder.Remove(builder.Length - 2, 2);
            return builder.ToString();
        }

        public string Create(string tableName, Day day)
        {
            var builder = new StringBuilder();

            builder.Append(string.Format("INSERT INTO {0} VALUES", tableName));

            builder.Append("(");
            AppendValues(day, builder);
            builder.Append(")");

            return builder.ToString();
        }

        public string Create(string tableName, Month month)
        {
            return null;
        }

        private void AppendValues(Day day, StringBuilder builder)
        {
            builder.Append(day.Datum);
            builder.Append(", ");

            builder.Append(day.Psum_0);
            builder.Append(", ");
            builder.Append(day.Pmax_0);
            builder.Append(", ");
            builder.Append(day.Psum_1);
            builder.Append(", ");
            builder.Append(day.Pmax_1);
            builder.Append(", ");
            builder.Append(day.Psum_2);
            builder.Append(", ");
            builder.Append(day.Pmax_2);
            builder.Append(", ");
            builder.Append(day.Psum_3);
            builder.Append(", ");
            builder.Append(day.Pmax_3);
            builder.Append(", ");
            builder.Append(day.Psum_4);
            builder.Append(", ");
            builder.Append(day.Pmax_4);
            builder.Append(", ");
            builder.Append(day.Psum_5);
            builder.Append(", ");
            builder.Append(day.Pmax_5);
            builder.Append(", ");
            builder.Append(day.Psum_6);
            builder.Append(", ");
            builder.Append(day.Pmax_6);
        }
              
        private void AppendValues(FiveMinutes fiveMinutes, StringBuilder builder)
        {
            builder.Append("(");
            builder.Append(fiveMinutes.Datum);
            builder.Append(", ");

            this.appendConsum(builder, fiveMinutes.Consum);
            this.appendProduct(builder, fiveMinutes.Production1);
            builder.Append(", ");
            this.appendProduct(builder, fiveMinutes.Production2);
            builder.Append(", ");
            this.appendProduct(builder, fiveMinutes.Production3);
            builder.Append(", ");
            this.appendProduct(builder, fiveMinutes.Production4);
            builder.Append(", ");
            this.appendProduct(builder, fiveMinutes.Production5);
            builder.Append(", ");
            this.appendProduct(builder, fiveMinutes.Production6);

            builder.Append(")");
        }

        private void appendConsum(StringBuilder builder, Consum consum)
        {
            builder.Append(consum.Pac);
            builder.Append(", ");
            builder.Append(consum.DaySum);
            builder.Append(", ");
            builder.Append(consum.Status);
            builder.Append(", ");
        }

        private void appendProduct(StringBuilder builder, Production production)
        {
            builder.Append(production.Pac);
            builder.Append(", ");
            builder.Append(production.DaySum);
            builder.Append(", ");
            builder.Append(production.Status);
            builder.Append(", ");
            builder.Append(production.Error);
            builder.Append(", ");
            builder.Append(production.Pdc1);
            builder.Append(", ");
            builder.Append(production.Pdc2);
            builder.Append(", ");
            builder.Append(production.Pdc3);
            builder.Append(", ");
            builder.Append(production.Udc1);
            builder.Append(", ");
            builder.Append(production.Udc2);
            builder.Append(", ");
            builder.Append(production.Udc3);
            builder.Append(", ");
            builder.Append(production.Uac);
        }
    }
}