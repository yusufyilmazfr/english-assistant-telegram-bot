using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnglishAssistantTelegramBot.Console.Services.Translation
{
    public interface ITranslateService
    {
        public Task Translate(Translation translation);
    }
}
