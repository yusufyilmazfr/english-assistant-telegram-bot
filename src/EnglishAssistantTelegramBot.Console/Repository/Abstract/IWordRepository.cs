using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract.BaseRepository;

namespace EnglishAssistantTelegramBot.Console.Repository.Abstract
{
    public interface IWordRepository : IBaseRepository<Word>
    {
        /// <summary>
        /// It returns any word.
        /// </summary>
        /// <returns></returns>
        Task<Word> GetAnyWordAsync();
    }
}
