using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using EnglishAssistantTelegramBot.Console.Services.Translation;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    class TranslateCommand : ICommand
    {
        private readonly ITranslateService _translateService;
        private readonly ITelegramBotClient _telegramBotClient;

        public TranslateCommand(ITranslateService translateService, ITelegramClient telegramClient)
        {
            _translateService = translateService;
            _telegramBotClient = telegramClient.GetInstance();
        }

        public async Task ExecuteAsync(Message message)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            var text = message.Text.Replace("/translate ", "");
            var result = await _translateService.Translate(new Translation("en", "tr", text));

            var firstSentence = result.Sentences.FirstOrDefault();

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"🇬🇧: {firstSentence.Orig}\n🇹🇷: {firstSentence.Trans}");
        }
    }
}
