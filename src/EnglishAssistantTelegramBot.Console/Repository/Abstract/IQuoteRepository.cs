using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract.BaseRepository;

namespace EnglishAssistantTelegramBot.Console.Repository.Abstract
{
    public interface IQuoteRepository : IBaseRepository<Quote>
    {
        /// <summary>
        /// It returns any quote.
        /// </summary>
        /// <returns></returns>
        Task<Quote> GetAnyQuoteAsync();
    }
}
