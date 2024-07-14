using System.Runtime.CompilerServices;

namespace TonyNguyen.Net8.KeyNotes;

public static class GeneratedCode
{
    [InterceptsLocation("""/Users/tony.nguyen/Documents/1-dev/github/TonyNguyen.Net8.KeyNotes/TonyNguyen.Net8.KeyNotes/TonyLogger.cs""", line:7, character:9)]
    public static void LogMethod(this TonyLogger tonyLogger, string level, string  message)
    {
        Console.WriteLine($"[*Interceptor*] [{level}] {message}");
    }
}