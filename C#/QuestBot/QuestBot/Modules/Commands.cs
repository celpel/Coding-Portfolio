using Discord.Commands;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Discord.WebSocket;
using Discord;
using System.Linq;
using System;
using System.IO;

namespace QuestBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

        // GM ONLY COMMANDS
        [Command("help")]
        public async Task GMHelp()
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = "```" + "addp IGuildUser - add player" + "\n"
                    + "remp IGuildUser -remove player" + "\n" +
                    "addxp xp-- ad xp" + "\n" +
                    "ptize IGuildUser attack / magic-- prioritize attack/ magic as a skill" + "\n" +
                    "ahp IGuildUser health --add helath to a specific user" + "\n" +
                    "aahp health - add health to all users" + "\n" +
                    "aamp magic - add mp to all users" + "\n" +
                    "aadmg - add 10-30 attack points to all users" + "\n" +
                    "rhp IGuildUser health-- remove health from specific char" + "\n" +
                    "rahp health -remove health from all users" + "\n" +
                    "amp, rmp - same as ahp and rhp but for MP" + "\n" +
                    "loada --load all players" + "\n" +
                    "loadp-- load players from previous session" + "\n" +
                    "save-- save file" + "```";

                await ReplyAsync($"{str}");
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("addp")]
        public async Task AddPlayer(IGuildUser u)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = u.ToString();
                Game.AddPlayer(str);
                await ReplyAsync($"{str} has been added.");
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("remp")]
        public async Task RemovePlayer(IGuildUser u)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = u.ToString();
                str = Game.RemovePlayer(str);
                await ReplyAsync(str);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("addxp")]
        public async Task AddXP(long amount)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string xp = Game.AddXP(amount);
                await ReplyAsync(xp);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("ptize")]
        public async Task PtiseAttkOrMgk(IGuildUser u, string select)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string s = "";
                if (select.Equals("attack"))
                {
                    s = Game.PrioritizeAttk(u.ToString());
                }
                else if (select.Equals("magic"))
                {
                    s = Game.PrioritizeMgck(u.ToString());
                }

                await ReplyAsync(s);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("ahp")]
        public async Task AddHP(IGuildUser u, long health)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = Game.HealPlayerHP(u.ToString(), health);
                await ReplyAsync(str);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("aahp")]
        public async Task AddAllHP(long health)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = Game.HealAllPlayerHP(health);
                await ReplyAsync(str);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("rhp")]
        public async Task DeductHP(IGuildUser u, long health)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = Game.DeductPlayerHP(u.ToString(), health);
                await ReplyAsync(str);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("rahp")]
        public async Task DeductAllHP(long health)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = Game.DeductAllPlayerHP(health);
                await ReplyAsync(str);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("amp")]
        public async Task AddMP(IGuildUser u, long magic)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = Game.HealPlayerMP(u.ToString(), magic);
                await ReplyAsync(str);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("aamp")]
        public async Task AddAllMP(long magic)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = Game.HealAllPlayerMP(magic);
                await ReplyAsync(str);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("aadmg")]
        public async Task AddAllDmg()
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                Game.IncreaseDmgAll();
                await ReplyAsync("Damage increased for all party members.");
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("rmp")]
        public async Task DeductMP(IGuildUser u, long magic)
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string str = Game.DeductPlayerMP(u.ToString(), magic);
                await ReplyAsync(str);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("loadp")]
        public async Task LoadPrevious()
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string s = Game.Load("CURRENTPLAYERS");
                await ReplyAsync(s);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("loada")]
        public async Task LoadAll()
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string s = Game.Load("PLAYERS");
                await ReplyAsync(s);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }

        [Command("save")]
        public async Task Save()
        {
            var su = Context.Message.Author;
            if (VerifyMessage(su) && Context.Channel.Name.Equals("gm"))
            {
                string s = Game.SaveGame();
                await ReplyAsync(s);
            }
            else
            {
                await ReplyAsync("You need to be the GM to use this command.");
            }

        }


        // PLAYER COMMANDS
        [Command("mystats")]
        public async Task CheckStats()
        {
            var username = Context.Message.Author as IGuildUser;
            string v = Game.ViewStats(username.ToString());
            await Context.Channel.SendMessageAsync(v);
        }

        [Command("allstats")]
        public async Task CheckAllStats()
        {
            string v = Game.ViewAllStats();

            try
            {
                await Context.Channel.SendMessageAsync(v);
            }
            catch(ArgumentException)
            {
                string path = @"C:\Temp\xp.txt";
                File.WriteAllText(path, v);
                await Context.Channel.SendFileAsync(path);
            }
            
        }

        [Command("bosshp")]
        public async Task CheckBossHP()
        {
            try
            {
                await Context.Channel.SendFileAsync(@"C:\Temp\crop_image.png");
            }
            catch(Exception)
            {
                await Context.Channel.SendMessageAsync("Error: Could not retrieve HP. Boss may not have been initialized.");
            }
            
        }


        // OTHER
        private bool VerifyMessage(SocketUser su)
        {
            var user = su as SocketGuildUser;
            var username = Context.User as SocketGuildUser;
            var role = (username as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "GM");
            if (user.Roles.Contains(role))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
