namespace Common;
public static partial class Utility
{
	public static bool IsValidBankCardNumber(string? cardNumber)
	{
		if (IsNumeric(cardNumber) == false || cardNumber.Length != 16) return false;
		return true;
	}
}