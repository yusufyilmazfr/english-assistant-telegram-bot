using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public SendVolunteerPageCommand(ITelegramBotClient telegramBotClient, IVolunteerPageRepository volunteerPageRepository)
        {
            _telegramBotClient = telegramBotClient;
            _volunteerPageRepository = volunteerPageRepository;
        }


        public async Task ExecuteAsync(Message message)
        {
            var volunteer = await _volunteerPageRepository.GetAnyVolunteerPageAsync();

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Owv! {message.Chat.FirstName} came back! :) I will recommend a new account to you. 🎉");

            var messageContent = $"I recommended a beautiful account! 💝\n" +
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

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Don't be a stranger! 💖");
        }
    }
}
