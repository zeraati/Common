using Common.Enum;

namespace Common
{
    public static partial class Utility
    {
		public static string RandomString(int length = 6, RandomStringTypeEnum type = RandomStringTypeEnum.Number)
		{
			var random = new Random();

			var chars = "0123456789";
			if (type == RandomStringTypeEnum.NumberAndAlphabet) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			else if (type == RandomStringTypeEnum.Alphabet) chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var resutl = new string(Enumerable.Repeat(chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
			return resutl;
		}
	}
}