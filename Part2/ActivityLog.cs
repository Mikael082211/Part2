using System;
using System.Collections.Generic;

namespace Part2
{
    public static class ActivityLog
    {
        public static List<string> Logs = new();

        public static void Add(string message)
        {
            Logs.Add($"{DateTime.Now:HH:mm:ss} - {message}");
        }
    }
}