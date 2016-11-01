using System.Text;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class SqlCreator
    {
        public string Create(string tableName, FiveMinutes fiveMinutes)
        {
            var builder = new StringBuilder();

            builder.Append(string.Format("INSERT INTO {0} VALUES", tableName));

            AppendValues(fiveMinutes, builder);
            builder.Append(", ");

            builder.Remove(builder.Length - 2, 2);
            return builder.ToString();
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