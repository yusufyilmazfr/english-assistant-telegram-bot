using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.CommandFactory;
using EnglishAssistantTelegramBot.Console.Commands.Concrete;
using EnglishAssistantTelegramBot.Console.Configuration.Context;
using EnglishAssistantTelegramBot.Console.Configuration.Environment;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper;
using EnglishAssistantTelegramBot.Console.Services.Reminder;
using EnglishAssistantTelegramBot.Console.Services.Translation;
using EnglishAssistantTelegramBot.Console.Services.Translation.Google;
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

        public static IRequestHistoryRepository RequestHistoryRepository { get; set; }

        static void Main(string[] args)
        {
            RegisterDependencies();

            TelegramClient = Services.GetRequiredService<ITelegramClient>();
            TelegramCommandFactory = Services.GetRequiredService<ITelegramCommandFactory>();
            RequestHistoryRepository = Services.GetRequiredService<IRequestHistoryRepository>();

            TelegramBotClient = TelegramClient.GetInstance();

            TelegramBotClient.OnMessage += TelegramBotClientOnOnMessage;

            TelegramBotClient.StartReceiving();

            System.Console.WriteLine($"EnglishAssistantTelegramBot.Console.Program started!");

            while (true)
            {
                Thread.Sleep(4000);
            }
        }

        private static async void TelegramBotClientOnOnMessage(object sender, MessageEventArgs e)
        {
            if (e?.Message == null)
            {
                return;
            }

            RequestHistoryRepository.InsertAsync(new RequestHistory(e.Message));

            try
            {
                await TelegramCommandFactory.CreateCommand(e?.Message).ExecuteAsync(e.Message);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                await TelegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Ops! something went wrong. 😢🤦‍♀️ Can you try again?");
            }
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
                .AddSingleton<ContactCommand>()
                .AddSingleton<SendNewDailyPhraseCommand>()
                .AddSingleton<TranslateCommand>()
                .AddSingleton<SendNewQuestionCommand>()
                .AddSingleton<IQuoteRepository, DapperQuoteRepository>()
                .AddSingleton<IStoryRepository, DapperStoryRepository>()
                .AddSingleton<IVolunteerPageRepository, DapperVolunteerPageRepository>()
                .AddSingleton<IWordRepository, DapperWordRepository>()
                .AddSingleton<IRequestHistoryRepository, DapperRequestHistoryRepository>()
                .AddSingleton<IDailyPhraseRepository, DapperDailyPhraseRepository>()
                .AddSingleton<ITranslateService, GoogleTranslateService>()
                .AddSingleton<IQuestionReminder, QuestionReminder>()
                .AddHttpClient()
                .BuildServiceProvider();
        }
    }
}
