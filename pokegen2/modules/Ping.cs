using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace pokegen2.modules
{
    public class ping : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task PingAsync()
        {
            //try to change prefix while spambot is active
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("pong")
                .WithDescription("we love henry ho")
                .WithColor(Color.Orange);

            await ReplyAsync("",false,builder.Build());
        }
    }
}
