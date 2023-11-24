using Common.Extension;
using System.Globalization;

namespace Common
{
    public static partial class Utility
    {
        public static DateTime ToMiladi(string value)
        {
            if (value.IsEmpty() == true) throw new NullReferenceException();

            string[] splitValue;
            if (value.Contains("-")) splitValue = value.Split('-');
            else if (value.Contains("/")) splitValue = value.Split("/");
            else throw new NullReferenceException();

            var year = int.Parse(splitValue[0]);
            var month = int.Parse(splitValue[1]);
            var day = int.Parse(splitValue[2]);
            var result = new DateTime(year, month, day, new PersianCalendar());
            return result;
        }
    }
}
