using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Common;
public static class SqlExceptionExtension
{
    public static object? SqlExceptionInfo(this SqlException exception)
    {
        var match = Regex.Match(exception.Message, "constraint \"(.*?)\".*?table \"(.*?)\".*?column '(.*?)'");
        if (!match.Success) return null;

        var result = new
        {
            Type = ((SqlExceptionNumberEnum)exception.Number).ToString(),
            ConstraintName = match.Groups[1].Value,
            TableName = match.Groups[2].Value,
            ColumnName = match.Groups[3].Value,
        };

        return result;
    }
}

public enum SqlExceptionNumberEnum
{
    PrimaryKeyViolation = 2627,
    UniqueConstraint = 2601,
    ForeignKeyConstraintViolation = 547,
}
