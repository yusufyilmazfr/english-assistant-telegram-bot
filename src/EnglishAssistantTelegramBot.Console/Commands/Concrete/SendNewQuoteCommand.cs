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
            var quote = await _quoteRepository.GetAnyQuoteAsync();

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Owv! {message.Chat.FirstName} came back! :) I will take a new word to you. 🎉");

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"🇬🇧: {quote.En}.\n🇹🇷: {quote.Tr}");

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Don't be a stranger! 💖");
        }
    }
}
