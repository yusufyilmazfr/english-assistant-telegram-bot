using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using EnglishAssistantTelegramBot.Console.Services.Translation;
using Telegram.Bot.Types;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    class TranslateCommand : ICommand
    {
        private readonly ITranslateService _translateService;

        public TranslateCommand(ITranslateService translateService)
        {
            _translateService = translateService;
        }

        public async Task ExecuteAsync(Message message)
        {
            var text = message.Text.Replace("/translate ", "");
            await _translateService.Translate(new Translation("tr", "en", text));
        }
    }
}
