using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;
public static class DbContextBuilderExtension
{
    public static WebApplicationBuilder AddDbContext<TContext>(this WebApplicationBuilder builder)where TContext : DbContext
    {
        var connection = builder.Configuration.GetConnectionString("SqlServer");
        builder.Services.AddDbContext<TContext>(options => options.UseSqlServer(connection));
        return builder;
    }
}