using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace pokegen2.modules
{
    public class ming : ModuleBase<SocketCommandContext>
    {
        public string[] mingpics = new string[]{
            "mingpics/ming1.jpg",
            "mingpics/ming2.png",
            "mingpics/ming3.png"
        };
        [Command("mingze")]
        public async Task PingAsync()
        {
            Random rand = new Random();
            int num = rand.Next(0, mingpics.Length);
            string finalming = mingpics[num];
            await Context.Channel.SendFileAsync(finalming);
        }
    }
}
