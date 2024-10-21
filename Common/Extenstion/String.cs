using System.Text;

namespace Common;
public static class StringExtension
{
    public static string Bold(this string input) => $"* {input} *";
    public static string NewLineBefore(this string input, int count = 1)
    {
        for (int i = 0; i < count; i++) input = "\n" + input;
        return input;
    }
    public static string NewLineAfter(this string input, int count = 1)
    {
        for (int i = 0; i < count; i++) input += "\n";
        return input;
    }

    public static string CamelCaseToKebabCase(this string input)
    {
        var builder = new StringBuilder();
        bool caseFlag = false;

        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];
            if (c == '-') caseFlag = true;
            else if (caseFlag)
            {
                builder.Append(char.ToUpper(c));
                caseFlag = false;
            }
            else builder.Append(char.ToLower(c));
        }
        return builder.ToString();
    }
}
