using System;
using System.Collections.Generic;
using System.Text;
using EnglishAssistantTelegramBot.Console.Configuration.Context;
using Telegram.Bot;

namespace EnglishAssistantTelegramBot.Console.Client
{
    public class TelegramClient : ITelegramClient
    {
        private static ITelegramBotClient _telegramBotClient;

        private static readonly object _lockObject = new object();

        private readonly string _telegramBotKey;

        public TelegramClient(IConfigurationContext configurationContext)
        {
            _telegramBotKey = configurationContext.TelegramBotKey;
        }

        public ITelegramBotClient GetInstance()
        {
            if (_telegramBotClient == null)
            {
                lock (_lockObject)
                {
                    if (_telegramBotClient == null)
                    {
                        _telegramBotClient = new TelegramBotClient(_telegramBotKey);
                    }
                }
            }

            return _telegramBotClient;
        }
    }
}
