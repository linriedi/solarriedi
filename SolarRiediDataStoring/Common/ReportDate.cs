namespace Common
{
    public class ReportDate
    {
        public ReportDate(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public string DayAsString
        {
            get
            {
                return this.Format(this.Day);
            }
        }

        public string MonthAsString
        {
            get
            {
                return this.Format(this.Month);
            }
        }

        public string YearAsString
        {
            get
            {
                return this.FormatYear(this.Year);
            }
        }

        public string DayPlusOneAsString
        {
            get
            {
                return this.Format(this.Day + 1);
            }
        }

        private string Format(int value)
        {
            if (value < 10)
            {
                return string.Format("0{0}", value);
            }

            return value.ToString();
        }

        private string FormatYear(int value)
        {
            if (value > 99)
            {
                int reduces = value % 100;
                return reduces.ToString();
            }

            return value.ToString();
        }
    }
}
