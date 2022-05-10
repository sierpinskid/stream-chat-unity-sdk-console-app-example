using System;
using System.Threading.Tasks;
using StreamChat.Core;
using StreamChat.Core.Models;
using StreamChat.Core.Requests;
using StreamChat.Libs.Auth;

namespace ToDeleteTestStreamSDKInConsole
{
    public class StreamChatService : IDisposable
    {
        public StreamChatService(AuthCredentials authCredentials)
        {
            _client = StreamChatClient.CreateDefaultClient(authCredentials);
            _client.Connected += OnClientConnected;
            _client.Connect();

            Console.WriteLine("Client created. Attempt to connect.");
        }

        public void Update(float deltaTime)
        {
            _client.Update(deltaTime);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        private const string ChannelType = "messaging";
        private const string ChannelId = "main-chat-id";

        private readonly IStreamChatClient _client;

        private void OnClientConnected()
        {
            Console.WriteLine("Client Connected.");

            TestServiceAsync()
                .ContinueWith(_ => Console.WriteLine(_.Exception), TaskContinuationOptions.OnlyOnFaulted);
        }

        /// <summary>
        /// Create 2 sample messages and print latest messages
        /// </summary>
        private async Task TestServiceAsync()
        {
            var rnd = new Random();

            var randomNumber = rnd.Next();
            Console.WriteLine("Send test message with a random number: " + randomNumber);
            await SendNewMessageAsync(randomNumber.ToString());

            randomNumber = rnd.Next();
            Console.WriteLine("Send test message with a random number: " + randomNumber);
            await SendNewMessageAsync(randomNumber.ToString());

            var channelState = await FetchLatestMessagesAsync();

            PrintMessages(channelState);
        }

        private async Task SendNewMessageAsync(string message)
        {
            try
            {
                var response = await _client.MessageApi.SendNewMessageAsync(ChannelType, ChannelId, new SendMessageRequest
                {
                    Message = new MessageRequest
                    {
                        Text = message
                    }
                });

                Console.WriteLine($"Message: `{response.Message.Text}` sent successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task<ChannelState> FetchLatestMessagesAsync()
        {
            try
            {
                return await _client.ChannelApi.GetOrCreateChannelAsync(ChannelType, ChannelId,
                    new ChannelGetOrCreateRequest
                    {
                        State = true,
                        Watch = true,
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void PrintMessages(ChannelState channelState)
        {
            Console.WriteLine($"Channel: `{channelState.Channel.Name}` last messages:");
            foreach (var msg in channelState.Messages)
            {
                Console.WriteLine($"{msg.Text}");
                Console.WriteLine($"Author: {msg.User.Id}");
                Console.WriteLine("");
            }
        }
    }
}