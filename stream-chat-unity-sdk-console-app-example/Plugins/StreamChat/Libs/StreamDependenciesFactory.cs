using StreamChat.Libs.AppInfo;
using StreamChat.Libs.Auth;
using StreamChat.Libs.Http;
using StreamChat.Libs.Logs;
using StreamChat.Libs.Serialization;
using StreamChat.Libs.Time;
using StreamChat.Libs.Websockets;

namespace StreamChat.Libs
{
    /// <summary>
    /// Factory that provides external dependencies for the Stream Chat Client.
    /// Stream chat client depends only on the interfaces therefore you can provide your own implementation for any of the dependencies
    /// </summary>
    public static class StreamDependenciesFactory
    {
        public static ILogs CreateLogger(ConsoleLogs.LogLevel logLevel = ConsoleLogs.LogLevel.All)
            => new ConsoleLogs(logLevel);

        public static IWebsocketClient CreateWebsocketClient(ILogs logs, bool isDebugMode = false)
        {

#if UNITY_WEBGL
            //StreamTodo: handle debug mode
            return new NativeWebSocketWrapper(logs, isDebugMode: isDebugMode);
#else
            return new WebsocketClient(logs, isDebugMode: isDebugMode);
#endif
        }

        public static IHttpClient CreateHttpClient()
        {
#if UNITY_WEBGL
            return new UnityWebRequestHttpClient();
#else
            return new HttpClientAdapter();
#endif
        }

        public static ISerializer CreateSerializer() => new NewtonsoftJsonSerializer();

        public static ITimeService CreateTimeService() => new ConsoleTime();

        public static IApplicationInfo CreateApplicationInfo() => new ConsoleApplicationInfo();
        
        public static ITokenProvider CreateTokenProvider(TokenProvider.TokenUriHandler urlFactory) => new TokenProvider(CreateHttpClient(), urlFactory);
    }
}