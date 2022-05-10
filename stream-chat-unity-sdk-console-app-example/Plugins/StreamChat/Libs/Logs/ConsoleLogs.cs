using System;

namespace StreamChat.Libs.Logs
{
    public class ConsoleLogs : ILogs
    {
        public string Prefix { get => $"{GetTimestamp()} {_prefix}"; set => _prefix = value; }

        public void Info(string message) => Console.WriteLine(Prefix + message);

        public void Warning(string message) => Console.WriteLine(Prefix + message);

        public void Error(string message) => Console.WriteLine(Prefix + message);

        public void Exception(Exception exception) => Console.WriteLine(exception);

        private static string GetTimestamp() => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();

        private string _prefix;
    }
}