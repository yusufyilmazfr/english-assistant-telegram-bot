using System;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.CommandFactory;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace EnglishAssistantTelegramBot.Console
{
    class Program
    {
        public static ITelegramCommandFactory TelegramCommandFactory;

        static void Main(string[] args)
        {
            ITelegramClient telegramClient = new TelegramClient();
            ITelegramBotClient telegramBotClient = telegramClient.GetInstance();
            IWordRepository wordRepository = new DapperWordRepository();
            IStoryRepository storyRepository = new DapperStoryRepository();

            TelegramCommandFactory = new TelegramCommandFactory(telegramClient, wordRepository, storyRepository);

            telegramBotClient.OnMessage += TelegramBotClientOnOnMessage;
            telegramBotClient.StartReceiving();

            System.Console.WriteLine("Please press key to exit");

            System.Console.Read();

            telegramBotClient.StopReceiving();
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
    }
}
