using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract.BaseRepository;

namespace EnglishAssistantTelegramBot.Console.Repository.Abstract
{
    public interface IDailyPhraseRepository : IBaseRepository<DailyPhrase>
    {
        /// <summary>
        /// It returns any story
        /// </summary>
        /// <returns></returns>
        Task<DailyPhrase> GetAnyDailyPhraseAsync();
    }
}
