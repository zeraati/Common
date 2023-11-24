using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extension;
public static partial class ServiceCollection
{
    public static void AddScopedClass<T>(this IServiceCollection services, AssemblyName assemblyName)
    {
		var assembly = AppDomain.CurrentDomain.GetAssemblies().Single(x => x.FullName == assemblyName.FullName);
		var scopedClasses = assembly.GetTypes().Where(x => x.IsInterface == false && typeof(T).IsAssignableFrom(x)).ToList();

		foreach (var scopedClasse in scopedClasses) services.AddScoped(scopedClasse);
	}

	public static void AddScopedClass<T>(this IServiceCollection services)
	{
		var assemblyName = Assembly.GetEntryAssembly()!.GetName();
		AddScopedClass<T>(services, assemblyName);
	}
}
