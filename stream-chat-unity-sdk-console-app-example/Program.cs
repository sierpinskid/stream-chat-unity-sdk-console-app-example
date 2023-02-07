using System;
using StreamChat.Libs.Auth;

namespace StreamSDKInConsole
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
                    apiKey: "wtnrddkt5tt2",
                    userId: "songoku-admin",
                    userToken: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoic29uZ29rdS1hZG1pbiJ9.ce_hSKcRCcP6Wa1M_Nam2CJp5oqq4eDcFcSvnjpBcRQ");

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
                    _streamChatService.Update();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private static StreamChatService _streamChatService;

        private static bool _isRunning;

        private static void OnProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("On Exit");
            _isRunning = false;

            _streamChatService.Dispose();
        }
    }
}