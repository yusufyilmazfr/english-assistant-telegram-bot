using System;
using System.Collections.Generic;
using System.Linq;
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
    class SendNewQuestionCommand : ICommand
    {
        private readonly IWordRepository _wordRepository;
        private readonly ITelegramBotClient _telegramBotClient;

        public SendNewQuestionCommand(IWordRepository wordRepository, ITelegramClient telegramClient)
        {
            _wordRepository = wordRepository;
            _telegramBotClient = telegramClient.GetInstance();
        }


        public async Task ExecuteAsync(Message message)
        {
            var randomNumber = new Random().Next(0, 5);

            var words = await _wordRepository.GetAnyWordsAsync(count: 5);

            var questionWord = words.ToList()[randomNumber];

            var question = $"Which translation is correct? 🤔 *{questionWord.En}*";

            var options = words.Select(word => word.Tr);

            try
            {
                await _telegramBotClient.SendPollAsync(message.Chat.Id, question, options, type: PollType.Quiz, isAnonymous: false, correctOptionId: randomNumber);
            }
            catch
            {
                System.Console.WriteLine($"{message.Chat.Id} blocked me! :((");
            }
        }
    }
}
