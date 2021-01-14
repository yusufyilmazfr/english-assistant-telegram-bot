using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace EnglishAssistantTelegramBot.Console.Commands.Abstract
{
    public interface ICommand
    {
        public Task ExecuteAsync(Message message);
    }
}
