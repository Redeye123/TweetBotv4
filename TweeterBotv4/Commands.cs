using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using static TweeterBotv4.Program;

namespace TweeterBotv4
{


    public class UngrouppedCommands
    {

        public static string TweetText = "";
        public static string Cprefix = "";




        [Command("ping")] // let's define this method as a command
        [Description("Ping command")] // this will be displayed to tell users what this command does when they invoke help
        [Aliases("pong")] // alternative names for the command
        public async Task Ping(CommandContext ctx)
        {
            // Delete Command Msg
            await ctx.Message.DeleteAsync();
            // Tell them bot is writing a msg
            await ctx.TriggerTypingAsync();

            // Add a Emoji
            var emoji = DiscordEmoji.FromName(ctx.Client, ":ping_pong:");

            // respond with ping
            await ctx.RespondAsync($"{emoji} Pong!: {ctx.Client.Ping}ms");

        }

        [Command("testy")] // let's define this method as a command
        [Description("test command")] // this will be displayed to tell users what this command does when they invoke help
        [Aliases("t")] // alternative names for the command
        public async Task test(CommandContext ctx)
        {
            // Delete Command Msg
            await ctx.Message.DeleteAsync();
            // Tell them bot is writing a msg
            await ctx.TriggerTypingAsync();

            // Add a Emoji
            var emoji = DiscordEmoji.FromName(ctx.Client, ":thumbsup:");

            // respond with ping
            await ctx.RespondAsync($"{emoji}");

        }


        [Command("smack"), Description("Smacks specified user.")]
        public async Task Greet(CommandContext ctx, [Description("Smacks specified user")] DiscordMember member) // this command takes a member as an argument; you can pass one by username, nickname, id, or mention
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();

            var emoji = DiscordEmoji.FromName(ctx.Client, ":wave::skin-tone-1:");


            await ctx.RespondAsync($"{emoji} Smacks {member.Mention} for bad behaviour");
        }

        [Command("spank"), Description("spanks specified user.")]
        public async Task spank(CommandContext ctx, [Description("spank specified user")] DiscordMember member)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            var emoji = DiscordEmoji.FromName(ctx.Client, ":wave::skin-tone-1:");
            await ctx.RespondAsync($"{emoji} Spanks {member.Mention} {emoji}");
        }

        [Command("cookies"), Description("Gives a cookie to nessa")]
        public async Task cookie(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            var emoji = DiscordEmoji.FromName(ctx.Client, ":cookie:");
            await ctx.RespondAsync($"{emoji} {emoji} {emoji} for Nessa");
        }

        [Command("setup"), Hidden, Description("Sets the prefix to a string")]
        public async Task setup(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.Message.DeleteAsync();

            var json = "";
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            // next, let's load the values from that file
            // to our client's configuration
            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);

            Cprefix = cfgjson.CommandPrefix;

            await ctx.RespondAsync($"My prefix is now {Cprefix}");

        }

        [Command("kfc"), Description("KFC for Cerizzle")]
        public async Task kfc(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            var emoji = DiscordEmoji.FromName(ctx.Client, ":kfcbucket:");
            await ctx.RespondAsync($"{emoji} {emoji} {emoji} for Cerizzle {emoji} {emoji} {emoji}");
        }



        [Command("ban"), Aliases("BanHammer"), Description("You have been Banned.")]
        public async Task ban(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();


            // wrap it into an embed
            var embed = new DiscordEmbedBuilder
            {

                Title = "Banned",
                ImageUrl = "http://i.imgur.com/O3DHIA5.gif"

            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("triggered"), Aliases("trig"), Description("Ive just got triggered")]
        public async Task trig(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();

            var embed = new DiscordEmbedBuilder
            {

                Title = "Triggered",
                ImageUrl = "http://i.imgur.com/yarc3QG.gif"

            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("hype"), Description("Hype It UP !!!")]
        public async Task hype(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();

            var embed = new DiscordEmbedBuilder
            {

                Title = "Hype",
                ImageUrl = "http://s2.quickmeme.com/img/09/09a3e3c6040ad3cdbef74f06280883a4a0b8a0a4a27d0f536ad57d2490748420.jpg"

            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("fetish"), Description("Krinkles Fetish")]
        public async Task fetish(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();

            var embed = new DiscordEmbedBuilder
            {

                Title = "FetishKD",
                ImageUrl = "http://i.imgur.com/VAvnHz0.gif"

            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("party"), Description("Party Like its 1999 !!!")]
        public async Task party(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();

            var embed = new DiscordEmbedBuilder
            {

                Title = "Party !!!",
                ImageUrl = "http://i.imgur.com/eEdUeFm.gif"

            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("desk"), Description("flips desk")]
        public async Task desk(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"┬─┬ノ( º _ ºノ)  (ﾉಥ益ಥ）ﾉ﻿ ┻━┻");
        }

        [Command("deskback"), Aliases("db"), Description("flips desk")]
        public async Task deskback(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"┻━┻ノ( ಥ益ಥノ)  (ﾉº _ º）ﾉ﻿ ┬─┬");
        }

        [Command("strip"), Description("Strips a member")]
        public async Task strip(CommandContext ctx, [Description("Strips a member")] DiscordMember member)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Strips {member.Mention} . Awesome !!!");
        }

        [Command("marry"), Description("Marry a member")]
        public async Task marry(CommandContext ctx, [Description("Strips a member")] DiscordMember member)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Forces {member.Mention} to marry {ctx.User.Username} My Condolences");
        }

        [Command("m"), Description("Maddie"), RequirePermissions(Permissions.BanMembers)]
        public async Task m(CommandContext ctx, [Description("Strips a member")] DiscordMember member)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Forces {member.Mention} to marry {ctx.User.Username} My Condolences");
        }

        [Command("molest"), Description("Molest a good Member of our Community")]
        public async Task molest(CommandContext ctx, [Description("Molest a good Member of our Community")] DiscordMember member)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"What ! What did you just said you want to molest {member.Mention} ! Thats Weird but i kinda got Horny too. Can i watch ?");
        }

        [Command("violate"), Description("Violate someones privacy")]
        public async Task violate(CommandContext ctx, [Description("Violate someones privacy")] DiscordMember member)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{ctx.User.Username} Is gonna sit very close to {member.Mention} then while {member.Mention} looks away {ctx.User.Username} puts there hands under the pants to touch {member.Mention} Genitals. You crazy Can you send my master a picture of that");
        }

        [Command("rape"), Description("Rapes a member")]
        public async Task rape(CommandContext ctx, [Description("Rapes a member")] DiscordMember member)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{ctx.User.Username} rapes {member.Mention} . Call the Special Victims Unit !!!");
        }

        [Command("red"), Description("reds info")]
        public async Task red(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Redeye123 is my master");
            await ctx.RespondAsync($"Ill do anything for him");
            await ctx.RespondAsync($"Even sucking his dick");
            await ctx.RespondAsync($"So dont mess with him or ill come after you");
        }

        [Command("ellie"), Description("Ellies info")]
        public async Task Ellie(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Ellie is The High Priestess");
            await ctx.RespondAsync($"Ill do anything for her");
            await ctx.RespondAsync($"She is the greatest person alive And Asian Too That counts for something right?");
            await ctx.RespondAsync($"So dont mess with her or ill send Gimzi after you");
        }

        [Command("info"), Description("ip")]
        public async Task ip(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            await ctx.RespondAsync($"The IP's are in <#346786841799688193> you do have to be a full member to be able to see that channel");
            await ctx.RespondAsync($"Not a member ? Please check <#219834093892927488> to become one !");
        }

        [Command("count"), Hidden, Description("Will count all the Members on this server")]
        public async Task count(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            int memb = ctx.Guild.MemberCount;
            await ctx.RespondAsync($"Our total Membercount is : {memb} !!!");

        }



        [Command("elliefacts"), Description("Will send a random Ellie fact")]
        public async Task ElliebotFacts(CommandContext ctx)
        {
            string[] EllieFacts =
            {
                "Did you know that Twin Peaks has been hacked twice successfully, and has since upgraded its security.",
                "Did you know the only reason Ellie hasn't created an Economy on Minecraft is the inevitable desire from members to create a cash shop, killing me slowly inside.",
                "Did you know that Sarah used to steal male members into another room and make them so blueballed they would leave the server out of frustration.",
                "Did you know that in University, Ellie originally wanted to do Computer Science but decided on Medicine because she fell in love with it.",
                "Did you know that Ellie gets messages on Discord, sees them but can't click on them for fear someone will complain, even if she likes that person, but just doesn't want to waste time.",
                "Did you know that Ellie consumes 3 mugs of tea every evening she is online, and her favorite relaxation tea is a Japanese blend.",
                "Did you know that Ellie's pet peeve is when people say : oh I was going to ask you medical advice but you're just a pediatrician so you won't know adults",
                "Did you know that Ellie pretended it was hard to do a Minecraft server so Kristen wouldn't want to learn because Ellie wanted to keep her as far away as possible?",
                "Did you know that Sarah has made the most requests for Minecraft Mods and has had her player profile deleted more than 100 times since joining TPG",
                "Did you know that when we first launched our Original Modpack, we went through 28 versions before changing",
                "Did you know that on average Devin spends 10 mins/month longer connected to the remote servers than other SysAdmins",
                "Did you know the community was originally going to be setup by Kristen but I hijacked it from her because I knew she was a fucking moron"
            };
            Random rand = new Random();
            string result = EllieFacts[rand.Next(EllieFacts.Length)];
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(result);
        }

        [Command("quotes"), Description("Will send a random Quote")]
        public async Task quotes(CommandContext ctx)
        {
            string[] quotes =
            {
                "Got a load to deliver - Sarah 2017",
                "I love Vanilla Minecraft - Redeye 2017",
                "I still don't like asians - Sarah 2017",
                "We rape you back - TPG 2017",
                "I've never masturbated before - Sarah 2017",
                "I facepalm at Sarah so much that my forehead is constantly red! - Das Cookie 2017",
                "Well smack my ass and call me easy..... - Das Cookie 2017",
                "To Minecraft or not to Minecraft? This is the question! Ahhh fuck it...I will just go play WoW! - Das Cookie 2017"
            };
            Random rand = new Random();
            string result = quotes[rand.Next(quotes.Length)];
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(result);
        }

        [Command("towel"), Description("Gives a cookie to nessa")]
        public async Task towel(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();


            var emoji = DiscordEmoji.FromName(ctx.Client, ":sweat_drops:");



            await ctx.RespondAsync($"{emoji} Gives a towel to Sarah {emoji}");
        }

        [Command("sum"), Description("Sums all given numbers and returns said sum.")]
        public async Task SumOfNumbers(CommandContext ctx, [Description("Integers to sum.")] params int[] args)
        {
            // We are working 
            await ctx.TriggerTypingAsync();

            // calculate the sum
            var sum = args.Sum();

            // and send it to the user
            await ctx.RespondAsync($"The sum of these numbers is {sum.ToString("#,##0")}");
        }

        [Command("nicks"), Hidden, Description("Gives someone a new nickname."), RequirePermissions(Permissions.Administrator)]
        public async Task ChangeNickname(CommandContext ctx, [Description("Member to change the nickname for.")] DiscordMember member, DiscordRole role, [RemainingText, Description("The nickname to give to that user.")] string new_nickname)
        {
            // let's trigger a typing indicator to let
            // users know we're working
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();


            try
            {
                // let's change the nickname, and tell the 
                // audit logs who did it.
                await member.ModifyAsync(new_nickname, reason: $"Changed by {ctx.User.Username} ({ctx.User.Id}).");

                // let's make a simple response.
                var emoji = DiscordEmoji.FromName(ctx.Client, ":+1:");

                // and respond with it.
                await ctx.RespondAsync(emoji.ToString());
            }
            catch (Exception)
            {
                // oh no, something failed, let the invoker now
                var emoji = DiscordEmoji.FromName(ctx.Client, ":-1:");
                await ctx.RespondAsync(emoji.ToString());
            }
        }


        [Command("math"), Description("Does basic math.")]
        public async Task Math(CommandContext ctx, [Description("Operation to perform on the operands.")] MathOperation operation, [Description("First operand.")] double num1, [Description("Second operand.")] double num2)
        {
            var result = 0.0;
            switch (operation)
            {
                case MathOperation.Add:
                    result = num1 + num2;
                    break;

                case MathOperation.Subtract:
                    result = num1 - num2;
                    break;

                case MathOperation.Multiply:
                    result = num1 * num2;
                    break;

                case MathOperation.Divide:
                    result = num1 / num2;
                    break;

                case MathOperation.Modulo:
                    result = num1 % num2;
                    break;
            }

            var emoji = DiscordEmoji.FromName(ctx.Client, ":1234:");
            await ctx.RespondAsync($"{emoji} The result is {result.ToString("#,##0.00")}");
        }

        [Command("waitforcode"), Description("Waits for a response containing a generated code.")]
        public async Task WaitForCode(CommandContext ctx)
        {
            // first retrieve the interactivity module from the client
            var interactivity = ctx.Client.GetInteractivityModule();

            // wait for anyone who types it
            var msg = await interactivity.WaitForMessageAsync(xm => xm.Content.Contains("[Hh][Ii]?"), TimeSpan.FromSeconds(60));
            if (msg != null)
            {
                // announce the winner
                await ctx.RespondAsync($"And the winner is: {msg.Message.Author.Mention}");
            }
            else
            {
                await ctx.RespondAsync("Nobody? Really?");
            }
        }

        [Command("penis"), Aliases("p"), Description("Shows your Penis length")]
        public async Task penis(CommandContext ctx)
        {
            string[] awnsers =
            {
                "My tweezers could not get a hold on it for measuring",
                "Sorry for saying this but its way to smelly to get near it Clean yourself dammit",
                "Its like baby size but then 10x smaller",
                "Sorry can't even see the damn thing with this magnifying glass"
            };

            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync("getting my magnifying glass");
            await ctx.RespondAsync("...");
            await ctx.RespondAsync("...");

            ulong Redeye123 = 165581435225374721;
            ulong Devin = 233859547595407360;
            ulong Gimzi = 89181323570221056;
            ulong Vanish = 126196095482068992;
            ulong Rufio = 78672572874498048;
            ulong KD = 145348764809428992;
            ulong Husband = 226050525731356672;

            if (ctx.Member.Id == Redeye123)
            {
                await ctx.RespondAsync("Magnifying glass was not needed Damn son i can see that one from a mile away");
                await ctx.RespondAsync($"{ctx.Member.Mention} penis is this long 8======================================================D");
            }
            else if (ctx.Member.Id == Devin)
            {
                await ctx.RespondAsync("This seems to be a ... Bratwurst");
                await ctx.RespondAsync($"{ctx.Member.Mention} Bratwurst is this long 8================================================D");
            }
            else if (ctx.Member.Id == Gimzi)
            {
                await ctx.RespondAsync("Your Girlfriend must be proud");
                await ctx.RespondAsync($"{ctx.Member.Mention} penis is this long 8=============================================D");
            }
            else if (ctx.Member.Id == Vanish)
            {
                await ctx.RespondAsync("Oh my this one is like pure muscle you've trained it well");
                await ctx.RespondAsync($"{ctx.Member.Mention} penis is this long 8============================================D");
            }
            else if (ctx.Member.Id == Rufio)
            {
                await ctx.RespondAsync("Tinkerbell would die to this so please dont use it on her");
                await ctx.RespondAsync($"{ctx.Member.Mention} penis is this long 8===========================================D");
            }
            else if (ctx.Member.Id == KD)
            {
                await ctx.RespondAsync("What the hell are you using to jerk off its so freaking salty !");
                await ctx.RespondAsync($"{ctx.Member.Mention} penis is this long 8==========================================D");
            }
            else if (ctx.Member.Id == Husband)
            {
                await ctx.RespondAsync("Now i understand why ellie loves you so much");
                await ctx.RespondAsync($"{ctx.Member.Mention} penis is this long 8==========================================================D");
            }
            else
            {
                Random rand = new Random();
                string result = awnsers[rand.Next(awnsers.Length)];
                await ctx.RespondAsync(result);
            }

        }

        
    }

    [Group("tpg")] // let's mark this class as a command group
    [Description("Administrative commands.")] // give it a description for help purposes
    //[Hidden] // let's hide this from the eyes of curious users
    [RequirePermissions(Permissions.BanMembers)]
    public class GrouppedCommands
    {

        public static string TweetText = "";
        // all the commands will need to be executed as <prefix>admin <command> <arguments>

        // this command will be only executable by the bot's owner
        [Command("sudo"), Description("Executes a command as another user."), Hidden, RequireNsfw]
        public async Task Sudo(CommandContext ctx, [Description("Member to execute as.")] DiscordMember member, [RemainingText, Description("Command text to execute.")] string command)
        {
            await ctx.Message.DeleteAsync();
            // note the [RemainingText] attribute on the argument.
            // it will capture all the text passed to the command

            // let's trigger a typing indicator to let
            // users know we're working
            await ctx.TriggerTypingAsync();

            // get the command service, we need this for
            // sudo purposes
            var cmds = ctx.Client.GetCommandsNext();

            

            // and perform the sudo
            await cmds.SudoAsync(member, ctx.Channel, command);
        }

        [Command("say"), Hidden, Description("Let the bot say your msg")]
        public async Task say(CommandContext ctx)
        {
            var json = "";
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            // next, let's load the values from that file
            // to our client's configuration
            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);

            string Cprefix = cfgjson.CommandPrefix;


            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            string saytext = ctx.Message.Content.Replace($"{Cprefix}tpg say", "");
            await ctx.RespondAsync(saytext);
        }

        [Command("tweet"),Hidden, Description("Send a fucking tweety")]
        public async Task tweet(CommandContext ctx) // Send tweet Fucking hell stupid twitter
        {

            var json = "";
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();
            
            // next, let's load the values from that file
            // to our client's configuration
            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);

            string Cprefix = cfgjson.CommandPrefix;

            TweetText = ctx.Message.Content.Replace($"{cfgjson.CommandPrefix}tpg tweet", "");
            if (TweetText.Length <= 140)
            {
                await ctx.RespondAsync($"I tweeted,{TweetText}");
                var twitter = new TwitterApi(cfgjson.ConsumerKey, cfgjson.ConsumerKeySecret, cfgjson.AccessToken, cfgjson.AccessTokenSecret);
                var response = await twitter.Tweet(TweetText);
                await ctx.Message.DeleteAsync();

            }
            else
            {
                await ctx.RespondAsync($"I could not tweet due to its size being over 140 characters");
            }


        }


    }
}
