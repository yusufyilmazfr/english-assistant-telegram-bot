using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace EnglishAssistantTelegramBot.Console.Services.Reminder
{
    class QuestionReminder : IQuestionReminder
    {
        private readonly IWordRepository _wordRepository;
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IRequestHistoryRepository _requestHistoryRepository;

        public QuestionReminder(IWordRepository wordRepository, ITelegramClient telegramClient, IRequestHistoryRepository requestHistoryRepository)
        {
            _wordRepository = wordRepository;
            _requestHistoryRepository = requestHistoryRepository;
            _telegramBotClient = telegramClient.GetInstance();
        }

        public async Task SendNewQuestion()
        {
            var randomNumber = new Random().Next(0, 5);
            var chatIdList = await _requestHistoryRepository.GetChatIdListAsync();
            var words = await _wordRepository.GetAnyWordsAsync(count: 5);

            var questionWord = words.ToList()[randomNumber];

            var question = $"Which translation is correct? 🤔 *{questionWord.En}*";

            var options = words.Select(word => word.Tr);

            foreach (var chatId in chatIdList)
            {
                try
                {
                    await _telegramBotClient.SendPollAsync(chatId, question, options, type: PollType.Quiz, isAnonymous: false, correctOptionId: randomNumber);
                }
                catch
                {
                    System.Console.WriteLine($"{chatId} blocked me! :((");
                }
            }
        }
    }
}
