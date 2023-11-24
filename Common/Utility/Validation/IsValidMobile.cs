using System.Text.RegularExpressions;

namespace Common
{
    public static partial class Utility
    {
		public static bool IsValidMobile(string? mobile)
		{
			if (IsNumeric(mobile) == false || mobile.Length != 11) return false;
			var match = Regex.Match(mobile, @"09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}").Success;
			return match;
		}
	}
}