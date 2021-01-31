using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    public class SendNewWordCommand : ICommand
    {
        private readonly IWordRepository _wordRepository;
        private readonly ITelegramBotClient _telegramBotClient;

        public SendNewWordCommand(ITelegramClient telegramClient, IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
            _telegramBotClient = telegramClient.GetInstance();
        }

        public async Task ExecuteAsync(Message message)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            var word = await _wordRepository.GetAnyWordAsync();

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"🇬🇧: {word.En}.\n🇹🇷: {word.Tr}");
        }
    }
}
