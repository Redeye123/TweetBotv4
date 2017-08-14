using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.IO;
using DSharpPlus.CommandsNext.Exceptions;
using Newtonsoft.Json;

namespace TweeterBotv4
{
    public class Program
    {
        public DiscordClient Client { get; set; }
        public CommandsNextModule Commands { get; set; }

        public static void Main(string[] args)
        {
            var prog = new Program();
            prog.RunBotAsync().GetAwaiter().GetResult();
        }

        public async Task RunBotAsync()
        {
            // first, let's load our configuration file
            var json = "";
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            // next, let's load the values from that file
            // to our client's configuration
            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);
            var cfg = new DiscordConfig
            {
                Token = cfgjson.Token,
                TokenType = TokenType.Bot,

                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            
            this.Client = new DiscordClient(cfg);
            this.Client.Ready += this.Client_Ready;
            this.Client.GuildAvailable += this.Client_GuildAvailable;
            this.Client.ClientError += this.Client_ClientError;

            //let's set up our commands
            var ccfg = new CommandsNextConfiguration
            {
                StringPrefix = cfgjson.CommandPrefix,
                EnableDms = true,
                EnableMentionPrefix = true
            };
            this.Commands = this.Client.UseCommandsNext(ccfg);
            this.Commands.CommandExecuted += this.Commands_CommandExecuted;
            this.Commands.CommandErrored += this.Commands_CommandErrored;

            
            var mathopcvt = new MathOperationConverter();
            CommandsNextUtilities.RegisterConverter(mathopcvt);
            CommandsNextUtilities.RegisterUserFriendlyTypeName<MathOperation>("operation");

            // up next, let's register our commands
            this.Commands.RegisterCommands<UngrouppedCommands>();
            //this.Commands.RegisterCommands<GrouppedCommands>();

            // finnaly, let's connect and log in
            await this.Client.ConnectAsync();

            // prevent premature quitting
            await Task.Delay(-1);
        }

        private Task Client_Ready(ReadyEventArgs e)
        {
            // let's log the fact that this event occured
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "TweeterBot", "Client is ready to process events.", DateTime.Now);

          
            return Task.CompletedTask;
        }

        private Task Client_GuildAvailable(GuildCreateEventArgs e)
        {
            
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "TweeterBot", $"Guild available: {e.Guild.Name}", DateTime.Now);
            
            return Task.CompletedTask;
        }

        private Task Client_ClientError(ClientErrorEventArgs e)
        {
            
            e.Client.DebugLogger.LogMessage(LogLevel.Error, "TweeterBot", $"Exception occured: {e.Exception.GetType()}: {e.Exception.Message}", DateTime.Now);

            
            return Task.CompletedTask;
        }

        private Task Commands_CommandExecuted(CommandExecutedEventArgs e)
        {
            
            e.Context.Client.DebugLogger.LogMessage(LogLevel.Info, "TweeterBot", $"{e.Context.User.Username} successfully executed '{e.Command.QualifiedName}'", DateTime.Now);

            
            return Task.CompletedTask;
        }

        private async Task Commands_CommandErrored(CommandErrorEventArgs e)
        {
            
            e.Context.Client.DebugLogger.LogMessage(LogLevel.Error, "TweeterBot", $"{e.Context.User.Username} tried executing '{e.Command?.QualifiedName ?? "<unknown command>"}' but it errored: {e.Exception.GetType()}: {e.Exception.Message ?? "<no message>"}", DateTime.Now);

            
            
        }
    }

    // Data from config.json
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string CommandPrefix { get; private set; }

        [JsonProperty("ConsumerKey")]
        public string ConsumerKey { get; private set; }

        [JsonProperty("ConsumerKeySecret")]
        public string ConsumerKeySecret { get; private set; }

        [JsonProperty("AccessToken")]
        public string AccessToken { get; private set; }

        [JsonProperty("AccessTokenSecret")]
        public string AccessTokenSecret { get; private set; }
    }
}