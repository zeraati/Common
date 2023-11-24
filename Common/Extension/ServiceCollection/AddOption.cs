using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extension;
public static partial class ServiceCollection
{
    public static void AddOption<T>(this IServiceCollection services,IConfiguration configuration ,string configurationSection) where T : class
    {
		services.AddOptions<T>().Bind(configuration.GetSection(configurationSection));
		services.AddSingleton(x=>x.GetRequiredService<IOptions<T>>().Value);
	}
}