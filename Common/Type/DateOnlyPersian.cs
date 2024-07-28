namespace Common;
public partial class CommonType
{
    public class DateOnlyPersian
    {
        public DateOnlyPersian(string persianDate)
        {
            var split = persianDate.Split(['/', '-']).Select(int.Parse).ToArray();
            Year = split[0];
            Month = split[1];
            Day = split[2];
        }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}

