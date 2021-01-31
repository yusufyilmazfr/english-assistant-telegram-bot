using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    public class ContactCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public ContactCommand(ITelegramClient telegramClient)
        {
            _telegramBotClient = telegramClient.GetInstance();
        }

        public async Task ExecuteAsync(Message message)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            string messageContent = $"🇬🇧: Hi {message.From.FirstName ?? message.From.Username} 👋\n" +
                                    $"I am Yusuf. I created this bot to make your work easier while you are studying English. I am here if you want to request a new feature, support or say hi. @yusufyilmazfr 🤗🌺\n\n" +

                                    $"🇹🇷: Merhaba {message.From.FirstName ?? message.From.Username} 👋\n" +
                                    $"Ben Yusuf. Bu botu, sizler İngilizce çalışırken işlerinizi kolaylaştırması için oluşturdum. Yeni özellik isteği, destek olmak veya bi' merhaba demek isterseniz buradayım ben. @yusufyilmazfr 🤗🌺";

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, messageContent);
        }
    }
}
