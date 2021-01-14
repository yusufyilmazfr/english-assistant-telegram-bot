using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace EnglishAssistantTelegramBot.Console.Client
{
    public interface ITelegramClient
    {
        ITelegramBotClient GetInstance();
    }
}
