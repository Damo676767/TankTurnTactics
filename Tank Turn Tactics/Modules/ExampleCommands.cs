using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Tank_Turn_Tactics.Modules
{
    public class ExampleCommands : ModuleBase
    {
        [Command("hi")]
        public async Task HelloCommand()
        {
            // initialize empty string builder for reply
            var sb = new StringBuilder();

            // get user info from the Context
            var user = Context.User;

            // build out the reply
            sb.AppendLine("Gday " + user.Username);

            // send simple string reply
            await ReplyAsync(sb.ToString());
        }



    

    }
}
