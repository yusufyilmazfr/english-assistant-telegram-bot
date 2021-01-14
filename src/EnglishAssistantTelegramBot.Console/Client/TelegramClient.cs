using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace EnglishAssistantTelegramBot.Console.Client
{
    public class TelegramClient : ITelegramClient
    {
        private static ITelegramBotClient _telegramBotClient;
        private static readonly object _lockObject = new object();

        public ITelegramBotClient GetInstance()
        {
            if (_telegramBotClient == null)
            {
                lock (_lockObject)
                {
                    if (_telegramBotClient == null)
                    {
                        _telegramBotClient = new TelegramBotClient("KEY");
                    }
                }
            }

            return _telegramBotClient;
        }
    }
}
