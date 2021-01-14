using System;
using System.Collections.Generic;
using System.Text;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using EnglishAssistantTelegramBot.Console.Commands.Concrete;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishAssistantTelegramBot.Console.CommandFactory
{
    public class TelegramCommandFactory : ITelegramCommandFactory
    {
        private ITelegramBotClient TelegramBotClient { get; }
        private readonly IWordRepository _wordRepository;

        public TelegramCommandFactory(ITelegramClient telegramClient, IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
            TelegramBotClient = telegramClient.GetInstance();
        }

        public ICommand CreateCommand(Message command)
        {
            switch (command.Text)
            {
                case "/start":
                    return new ShowCommand(TelegramBotClient);
                case "/sendnewstory":
                    return new SendStoryCommand(TelegramBotClient);
                case "/sendnewword":
                    return new SendNewWordCommand(_wordRepository, TelegramBotClient);
                default:
                    return new ShowCommand(TelegramBotClient);
            }
        }
    }
}
