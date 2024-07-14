namespace TonyNguyen.Net8.KeyNotes;

public class TonyLogger
{
    public void LogInfo(string message)
    {
        InternalLog("Info", message);
    }

    private void InternalLog(string info, string message)
    {
        throw new NotImplementedException();
    }
}
//
// public static class LoggingInterceptor
// {
//     [InterceptsLocation("*/Controllers/*.cs")]
//     public static T LogMethod<T>(Func<T> original, string methodName)
//     {
//         Console.WriteLine($"Entering {methodName}");
//         T result = original();
//         Console.WriteLine($"Exiting {methodName}");
//         return result;
//     }
// }