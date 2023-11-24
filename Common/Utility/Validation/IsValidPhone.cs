using System.Text.RegularExpressions;

namespace Common
{
    public static partial class Utility
    {
		public static bool IsValidPhone(string? phone)//شماره ثابت
		{
			if (IsNumeric(phone) == false || phone.Length != 11) return false;

			var match = Regex.Match(phone, @"^0[0-9]{2,}[0-9]{7,}$").Success;
			return match;
		}
	}
}