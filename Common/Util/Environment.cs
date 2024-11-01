namespace Common;
public static class Environment
{
    public static bool IsProduction()
        => System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production";

    public static bool IsDevelopment()
        => System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

    public static string GetAspNetCoreVariable()
        => System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "";
}