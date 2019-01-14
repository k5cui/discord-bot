using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace pokegen
{
    public class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        public CommandService _commands;
        private IServiceProvider _services;
        public bool pokemon = false;

        public string[] mingpics = new string[]{
            "mingpics/ming1.jpg",
            "mingpics/ming2.png",
            "mingpics/ming3.png"
        };
        

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            string botToken = "NDE2NDUxNzgxMjY3MDMwMDM4.DXPFKA.rTgOC2iu33_HRGUh_0OD-XN2Ae0";

            _client.Log += Log;

            await RegisterCommandAsync();

            await _client.LoginAsync(TokenType.Bot, botToken);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null)
            {
                return;
            }
            int argPos = 0;

            /*if(message.HasStringPrefix("**A wild**", ref argPos)){
                pokemon = true;
            };*/

            if (message.HasStringPrefix("//", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos) || message.HasStringPrefix("**A wild**", ref argPos))
            {
                var context = new SocketCommandContext(_client, message);
                var result  = await _commands.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }

        }

    }
}


