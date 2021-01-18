using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    public class SendNewDailyPhraseCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IDailyPhraseRepository _dailyPhraseRepository;

        public SendNewDailyPhraseCommand(ITelegramClient telegramClient, IDailyPhraseRepository dailyPhraseRepository)
        {
            _dailyPhraseRepository = dailyPhraseRepository;
            _telegramBotClient = telegramClient.GetInstance();
        }

        public async Task ExecuteAsync(Message message)
        {
            var phrase = await _dailyPhraseRepository.GetAnyDailyPhraseAsync();

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"🇬🇧: {phrase.En}.\n🇹🇷: {phrase.Tr}");
        }
    }
}
