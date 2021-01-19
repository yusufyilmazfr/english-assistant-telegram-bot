using System.Threading.Tasks;

namespace EnglishAssistantTelegramBot.Console.Services.Reminder
{
    public interface IQuestionReminder
    {
        public Task SendNewQuestion();
    }
}
