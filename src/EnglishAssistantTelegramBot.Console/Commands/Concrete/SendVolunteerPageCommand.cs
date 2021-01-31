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
using Telegram.Bot.Types.ReplyMarkups;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    class SendVolunteerPageCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IVolunteerPageRepository _volunteerPageRepository;

        public SendVolunteerPageCommand(ITelegramClient telegramClient, IVolunteerPageRepository volunteerPageRepository)
        {
            _telegramBotClient = telegramClient.GetInstance();
            _volunteerPageRepository = volunteerPageRepository;
        }


        public async Task ExecuteAsync(Message message)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            var volunteer = await _volunteerPageRepository.GetAnyVolunteerPageAsync();

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"I will recommend a new beautiful account to you. 🎉");

            var messageContent = $"I recommended a beautiful account! 💝\n\n" +
                                       $"Account: *{volunteer.Name}*\n" +
                                       $"🇬🇧: {volunteer.En}.\n" +
                                       $"🇹🇷: {volunteer.Tr}";

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id,
                                                            text: messageContent,
                                                            parseMode: ParseMode.Markdown,
                                                            disableWebPagePreview: true,
                                                            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                                                                    "Visit beautiful account!", volunteer.Link
                                                                    )
                                                            ));
        }
    }
}
