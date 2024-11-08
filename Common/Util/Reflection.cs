using System.Diagnostics;

namespace Common;
public static class Reflection
{
    public static string CallerThisMethod()
    {
        var stackTrace = new StackTrace();
        var frame = stackTrace.GetFrame(2);
        var method = frame!.GetMethod()!;

        return method.Name;
    }
}

