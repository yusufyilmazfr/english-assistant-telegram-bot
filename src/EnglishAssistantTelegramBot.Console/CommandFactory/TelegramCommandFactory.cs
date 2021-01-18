using System;
using System.Collections.Generic;
using System.Text;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using EnglishAssistantTelegramBot.Console.Commands.Concrete;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishAssistantTelegramBot.Console.CommandFactory
{
    public class TelegramCommandFactory : ITelegramCommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TelegramCommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(Message command)
        {
            return command.Text switch
            {
                "/start" => _serviceProvider.GetRequiredService<ShowCommand>(),
                "/sendnewstory" => _serviceProvider.GetRequiredService<SendStoryCommand>(),
                "/sendnewword" => _serviceProvider.GetRequiredService<SendNewWordCommand>(),
                "/sendnewquote" => _serviceProvider.GetRequiredService<SendNewQuoteCommand>(),
                "/supportvolunteerpages" => _serviceProvider.GetRequiredService<SendVolunteerPageCommand>(),
                "/contact" => _serviceProvider.GetRequiredService<ContactCommand>(),
                _ => _serviceProvider.GetRequiredService<ShowCommand>()
            };
        }
    }
}
