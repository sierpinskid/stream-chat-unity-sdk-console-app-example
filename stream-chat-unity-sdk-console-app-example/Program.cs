using System;
using StreamChat.Libs.Auth;

namespace ToDeleteTestStreamSDKInConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

            try
            {
                var authCredentials = new AuthCredentials(
                    apiKey: "",
                    userId: "",
                    userToken: "");

                if (authCredentials.IsAnyEmpty())
                {
                    Console.WriteLine("Please provide valid credentials: API_KEY, USER_ID, USER_TOKEN");
                    Console.ReadKey();
                    return;
                }

                _streamChatService = new StreamChatService(authCredentials);
                _isRunning = true;

                while (_isRunning)
                {
                    var currentTimestampMs = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

                    if (currentTimestampMs < _nextFrameTimestampMs)
                    {
                        continue;
                    }

                    var deltaTime = (currentTimestampMs - _lastFrameTimestampMs) / 1000;
                    _streamChatService.Update((float)deltaTime);

                    _lastFrameTimestampMs = currentTimestampMs;
                    _nextFrameTimestampMs = _lastFrameTimestampMs + MsPerFrame;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private const float FrameRate = 30;
        private const float MsPerFrame = 1000 / 30f;

        private static StreamChatService _streamChatService;

        private static bool _isRunning;
        private static double _lastFrameTimestampMs;
        private static double _nextFrameTimestampMs;

        private static void OnProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("On Exit");
            _isRunning = false;

            _streamChatService.Dispose();
        }
    }
}