using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace TweeterBotv4
{
    public class UngrouppedCommands
    {
        public static string TweetText = "";

        
        


        [Command("ping")] // let's define this method as a command
        [Description("Ping command")] // this will be displayed to tell users what this command does when they invoke help
        [Aliases("pong")] // alternative names for the command
        public async Task Ping(CommandContext ctx) 
        {
            // Delete Command Msg
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();

            // let's make the message a bit more colourful
            var emoji = DiscordEmoji.FromName(ctx.Client, ":ping_pong:");

            // respond with ping
            await ctx.RespondAsync($"{emoji} Pong! Ping: {ctx.Client.Ping}ms");
        }

        [Command("tweet"), Hidden, Description("Send a fucking tweety")]
        public async Task tweet(CommandContext ctx) // Send tweet Fucking hell stupid twitter
        {

            var json = "";
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            // next, let's load the values from that file
            // to our client's configuration
            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);



            TweetText = ctx.Message.Content.Replace($"{cfgjson.CommandPrefix}tweet", "");
            if (TweetText.Length <= 140)
            {
                await ctx.RespondAsync($"I tweeted,{TweetText}");
                var twitter = new TwitterApi(cfgjson.ConsumerKey, cfgjson.ConsumerKeySecret, cfgjson.AccessToken, cfgjson.AccessTokenSecret);
                var response = await twitter.Tweet(TweetText);
                await ctx.Message.DeleteAsync();
                
            }
            else
            {
                await ctx.RespondAsync($"I could not tweet due to its size bieng over 140 characters");
            }
            
            
        }



        [Command("smack"), Description("Smacks specified user.")]
        public async Task Greet(CommandContext ctx, [Description("Smacks specified user")] DiscordMember member) // this command takes a member as an argument; you can pass one by username, nickname, id, or mention
        {
            // let's trigger a typing indicator to let
            // users know we're working
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();

            // let's make the message a bit more colourful
            var emoji = DiscordEmoji.FromName(ctx.Client, ":wave::skin-tone-1:");

            // and finally, let's respond and greet the user.
            await ctx.RespondAsync($"{emoji} Smacks {member.Mention} for bad behaviour");
        }

        [Command("spank"), Description("spanks specified user.")]
        public async Task spank(CommandContext ctx, [Description("spank specified user")] DiscordMember member) // this command takes a member as an argument; you can pass one by username, nickname, id, or mention
        {
            // note the [Description] attribute on the argument.
            // this will appear when people invoke help for the
            // command.

            // let's trigger a typing indicator to let
            // users know we're working
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();



            // let's make the message a bit more colourful
            var emoji = DiscordEmoji.FromName(ctx.Client, ":wave::skin-tone-1:");

            // and finally, let's respond and greet the user.
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

        [Command("ban"), Aliases("feelsbadman"), Description("Feels bad, man.")]
        public async Task ban(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            

            // wrap it into an embed
            var embed = new DiscordEmbed
            {
                
                Image = new DiscordEmbedImage
                {
                    Url = "http://i.imgur.com/O3DHIA5.gif"
                }
            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("trig"), Aliases("Triggered"), Description("Ive just got triggered")]
        public async Task trig(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            
            var embed = new DiscordEmbed
            {

                Image = new DiscordEmbedImage
                {
                    Url = "http://i.imgur.com/yarc3QG.gif"
                }
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

        [Command("ip"), Description("ip")]
        public async Task ip(CommandContext ctx) 
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"The IP's are in #TPG-Info you dork");
            await ctx.RespondAsync($"(ﾉಥ益ಥ）ﾉ﻿ ┻━┻");
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
    }
}
