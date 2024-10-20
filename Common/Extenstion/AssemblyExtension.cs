using Microsoft.EntityFrameworkCore;

namespace System.Reflection;
public static class AssemblyExtension
{
    public static IEnumerable<Type> GetDerivedClasses(this Assembly assembly, Type baseType)
    {
        var result = assembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(baseType));
        return result;
    }

    public static IEnumerable<Type> GetImplementingClasses(this Assembly assembly, Type interfaceType)
    {
        var result = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(interfaceType) && t.IsClass);
        return result;
    }
}