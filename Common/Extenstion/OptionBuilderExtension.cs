using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;
public static class OptionBuilderExtension
{
    public static WebApplicationBuilder AddOption<TOption>(this WebApplicationBuilder builder,string section) where TOption : class
    {
        builder.Services.Configure<TOption>(builder.Configuration.GetSection(section));
        return builder;
    }
}
