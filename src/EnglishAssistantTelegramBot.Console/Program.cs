using System;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.CommandFactory;
using EnglishAssistantTelegramBot.Console.Commands.Concrete;
using EnglishAssistantTelegramBot.Console.Configuration.Context;
using EnglishAssistantTelegramBot.Console.Configuration.Environment;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace EnglishAssistantTelegramBot.Console
{
    class Program
    {
        public static IServiceProvider Services { get; set; }

        public static ITelegramClient TelegramClient { get; set; }
        public static ITelegramBotClient TelegramBotClient { get; set; }
        public static ITelegramCommandFactory TelegramCommandFactory { get; set; }

        static void Main(string[] args)
        {
            RegisterDependencies();

            TelegramCommandFactory = Services.GetRequiredService<ITelegramCommandFactory>();
            TelegramClient = Services.GetRequiredService<ITelegramClient>();

            TelegramBotClient = TelegramClient.GetInstance();

            TelegramBotClient.OnMessage += TelegramBotClientOnOnMessage;

            TelegramBotClient.StartReceiving();

            System.Console.WriteLine("Please press key to exit");

            System.Console.Read();

            TelegramBotClient.StopReceiving();
        }

        private static async void TelegramBotClientOnOnMessage(object sender, MessageEventArgs e)
        {
            if (e?.Message == null)
            {
                return;
            }

            System.Console.WriteLine($"It received new message: {JsonConvert.SerializeObject(e.Message)}");

            await TelegramCommandFactory.CreateCommand(e?.Message).ExecuteAsync(e.Message);
        }

        private static void RegisterDependencies()
        {
            Services = new ServiceCollection()
                .AddSingleton<IEnvironmentService, EnvironmentService>()
                .AddSingleton<IConfigurationContext, ConfigurationContext>()
                .AddSingleton<ITelegramClient, TelegramClient>()
                .AddSingleton<ITelegramCommandFactory, TelegramCommandFactory>()
                .AddSingleton<ShowCommand>()
                .AddSingleton<SendStoryCommand>()
                .AddSingleton<SendNewQuoteCommand>()
                .AddSingleton<SendNewWordCommand>()
                .AddSingleton<SendVolunteerPageCommand>()
                .AddSingleton<IQuoteRepository, DapperQuoteRepository>()
                .AddSingleton<IStoryRepository, DapperStoryRepository>()
                .AddSingleton<IVolunteerPageRepository, DapperVolunteerPageRepository>()
                .AddSingleton<IWordRepository, DapperWordRepository>()
                .BuildServiceProvider();
        }
    }
}
