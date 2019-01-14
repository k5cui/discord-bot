using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace pokegen2.modules
{
    public class help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task PingAsync()
        {
            //try to change prefix while spambot is active
            await ReplyAsync("fuck you");
        }
    }
}
