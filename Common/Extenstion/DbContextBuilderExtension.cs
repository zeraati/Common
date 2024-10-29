using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;
public static class DbContextBuilderExtension
{
    public static WebApplicationBuilder AddDbContext<TContext>(this WebApplicationBuilder builder, bool localForLinux=false) where TContext : DbContext
    {
        var connection = builder.Configuration.GetConnectionString("SqlServer")!;
        if (localForLinux && RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            connection = Regex.Replace(connection, @"Server=\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3};", "Server=.;");
        }

        builder.Services.AddDbContext<TContext>(options => options.UseSqlServer(connection));
        return builder;
    }
}