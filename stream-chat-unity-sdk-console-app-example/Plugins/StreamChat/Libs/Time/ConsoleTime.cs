using System;
using StreamChat.Libs.Time;

namespace StreamChat.Libs.Time
{
    public class ConsoleTime : ITimeService
    {
        public float Time => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        public float DeltaTime => throw new NotImplementedException();
    }
}