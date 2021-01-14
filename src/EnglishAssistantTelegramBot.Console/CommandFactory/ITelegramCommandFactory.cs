using System;
using System.Collections.Generic;
using System.Text;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using Telegram.Bot.Types;

namespace EnglishAssistantTelegramBot.Console.CommandFactory
{
    public interface ITelegramCommandFactory
    {
        ICommand CreateCommand(Message command);
    }
}
