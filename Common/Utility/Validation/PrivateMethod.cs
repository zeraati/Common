using Common.Extension;
using System.Text.RegularExpressions;

namespace Common
{
    public static partial class Utility
    {
		private static bool IsNumeric(string? value)
		{
			if(value.IsEmpty()==true)return false;

			var match = Regex.Match(value, @"^\d*$");
			return match.Success;
		}

		private static bool LenIs(string? value,int len)
		{
			if (value.IsEmpty() == true) return false;

			var match = Regex.Match(value, @"^$");
			return match.Success;
		}
	}
}