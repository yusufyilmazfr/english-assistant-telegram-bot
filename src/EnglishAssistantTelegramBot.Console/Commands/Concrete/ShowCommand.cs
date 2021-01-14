using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    public class ShowCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public ShowCommand(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public async Task ExecuteAsync(Message message)
        {
            var myCommands = await _telegramBotClient.GetMyCommandsAsync();

            var messageContent = "";

            foreach (var botCommand in myCommands)
            {
                messageContent += $"/{botCommand.Command} - {botCommand.Description} \n";
            }


            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, messageContent);
        }
    }
}
