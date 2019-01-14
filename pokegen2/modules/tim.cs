using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace pokegen2.modules
{
    public class tim : ModuleBase<SocketCommandContext>
    {
        [Command("tim")]
        public async Task PingAsync()
        {
            string[] insults = new string[] {
                "ugly", "stupid", "gay", "a faggot", "lonely", "smelly", "bekfast", "autism", "a bitch" 
            };
            Random rand = new Random();
            int num = rand.Next(0, insults.Length-1);
            await ReplyAsync("is " + insults[num]);
        }
    }
}
