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
    public class SendNewQuoteCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IQuoteRepository _quoteRepository;

        public SendNewQuoteCommand(ITelegramClient telegramClient, IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
            _telegramBotClient = telegramClient.GetInstance();
        }


        public async Task ExecuteAsync(Message message)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            var quote = await _quoteRepository.GetAnyQuoteAsync();

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"🇬🇧: {quote.En}.\n🇹🇷: {quote.Tr}");
        }
    }
}
