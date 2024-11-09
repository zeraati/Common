using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Microsoft.EntityFrameworkCore.Infrastructure;
public static class DatabaseFacadeExtension
{
    public static Task<TResult[]> Procedure<TResult>(this DatabaseFacade database, string procedureName, object? parameter,CancellationToken cancellation)
        where TResult : class
    {
        var query = ProcedureQueryBuilder(procedureName, parameter);
        var result = database.SqlQuery<TResult>(query).ToArrayAsync(cancellation);
        return result;
    }

    public static async Task<TResult?> ProcedureScalar<TResult>(this DatabaseFacade database, string procedureName, object? parameter,CancellationToken cancellation)
        where TResult : class
    {
        var result = (await database.Procedure<TResult>(procedureName, parameter,cancellation)).SingleOrDefault();
        return result;
    }

    private static FormattableString ProcedureQueryBuilder(string procedureName, object? parameter)
    {
        if (parameter == null)
        {
            var query = FormattableStringFactory.Create($"EXEC {procedureName}");
            return query;
        }
        else
        {
            var param = new List<SqlParameter>();
            var properties = parameter.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(parameter, null);
                if (value == null) continue;
                param.Add(new SqlParameter("@" + property.Name, value));
            }

            var paramNames = string.Join(',', param.Select(prm => prm.ParameterName + "=" + prm.ParameterName));
            var query = FormattableStringFactory.Create($"EXEC {procedureName} {paramNames}", param.ToArray());
            return query;
        }
    }
}


