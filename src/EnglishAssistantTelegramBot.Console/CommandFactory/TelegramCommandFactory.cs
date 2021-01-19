using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
                "/sendnewdailyphrase" => _serviceProvider.GetRequiredService<SendNewDailyPhraseCommand>(),
                "/sendnewquote" => _serviceProvider.GetRequiredService<SendNewQuoteCommand>(),
                "/sendnewquestion" => _serviceProvider.GetRequiredService<SendNewQuestionCommand>(),
                "/supportvolunteerpages" => _serviceProvider.GetRequiredService<SendVolunteerPageCommand>(),
                "/contact" => _serviceProvider.GetRequiredService<ContactCommand>(),
                var x when Regex.IsMatch(x, "/translate.*") => _serviceProvider.GetRequiredService<TranslateCommand>(),
                _ => _serviceProvider.GetRequiredService<ShowCommand>()
            };
        }
    }
}
