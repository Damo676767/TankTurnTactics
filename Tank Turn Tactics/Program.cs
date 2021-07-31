using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Tank_Turn_Tactics
{
	public class Program
	{
		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += OnMessageReceived;
            _client.Log += Log;

            var token = File.ReadAllText("token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task OnMessageReceived(SocketMessage message)
        {
            if (!message.Content.StartsWith('!'))
            {
                return Task.CompletedTask;
            }

            if (message.Author.IsBot)
            {
                return Task.CompletedTask;
            }

            var command = (message.Content.Contains(' ') ? message.Content.Substring(1, message.Content.IndexOf(' ') - 1) : message.Content.Substring(1)).ToLower();

            if (command == "hi")
            {
                message.Channel.SendMessageAsync("Gday");
            }
       
            return Task.CompletedTask;
        }

        private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}
	}
}
