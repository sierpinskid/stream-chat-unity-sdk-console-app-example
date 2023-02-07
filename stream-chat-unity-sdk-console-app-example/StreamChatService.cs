using System;
using System.Threading.Tasks;
using StreamChat.Core;
using StreamChat.Core.StatefulModels;
using StreamChat.Libs.Auth;
using StreamChat.Libs.Utils;

namespace StreamSDKInConsole
{
    public class StreamChatService : IDisposable
    {
        public StreamChatService(AuthCredentials authCredentials)
        {
            _client = StreamChatClient.CreateDefaultClient();
            _client.Connected += OnClientConnected;
            _client.ConnectUserAsync(authCredentials).LogIfFailed();

            Console.WriteLine("Client created. Attempt to connect.");
        }

        public void Update()
        {
            _client.Update();
        }

        public void Dispose()
        {
            _client.Connected -= OnClientConnected;
            _client.Dispose();
        }

        // Channel can be referenced by ID or by a unique combination of members
        // e.g. private msg between 2 members will always point to the same channel
        private const string ChannelId = "main-chat-id";
        
        private readonly IStreamChatClient _client;

        private IStreamChannel _activeChannel;

        private void OnClientConnected(IStreamLocalUserData localUserData)
        {
            Console.WriteLine("Client Connected. Local user: " + localUserData.User.Id);

            TestServiceAsync()
                .ContinueWith(_ => Console.WriteLine(_.Exception), TaskContinuationOptions.OnlyOnFaulted);
        }

        /// <summary>
        /// Create 2 sample messages and print latest messages
        /// </summary>
        private async Task TestServiceAsync()
        {
            _activeChannel = await GetChannel();
            
            var rnd = new Random();

            var randomNumber = rnd.Next();
            Console.WriteLine("Send test message with a random number: " + randomNumber);
            await SendNewMessageAsync(randomNumber.ToString());

            randomNumber = rnd.Next();
            Console.WriteLine("Send test message with a random number: " + randomNumber);
            await SendNewMessageAsync(randomNumber.ToString());
            
            PrintMessages();
        }

        private async Task SendNewMessageAsync(string messageText)
        {
            try
            {
                var message = await _activeChannel.SendNewMessageAsync(messageText);

                Console.WriteLine($"Message: `{message.Text}` sent successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task<IStreamChannel> GetChannel()
        {
            try
            {
                return await _client.GetOrCreateChannelWithIdAsync(ChannelType.Messaging, ChannelId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void PrintMessages()
        {
            Console.WriteLine($"Channel: `{_activeChannel.Name}` last messages:");
            foreach (var msg in _activeChannel.Messages)
            {
                Console.WriteLine($"{msg.Text}");
                Console.WriteLine($"Author: {msg.User.Id}");
                Console.WriteLine("");
            }
        }
    }
}