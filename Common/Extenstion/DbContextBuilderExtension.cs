using Common;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;
public static class DbContextBuilderExtension
{
    public static WebApplicationBuilder AddDbContext<TContext>(this WebApplicationBuilder builder, bool locallyInReleaseMode = false) where TContext : DbContext
    {
        var connection = builder.Configuration.GetConnectionString("SqlServer")!;
        if (locallyInReleaseMode && !Debugger.IsAttached)
        {
            connection = Regex.Replace(connection, @"Server=\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3};", "Server=.;");

            if(Util.OsIsDocker)connection.Replace("Server=.;", "host.docker.internal");
        }

        builder.Services.AddDbContext<TContext>(options => options.UseSqlServer(connection));
        return builder;
    }
}