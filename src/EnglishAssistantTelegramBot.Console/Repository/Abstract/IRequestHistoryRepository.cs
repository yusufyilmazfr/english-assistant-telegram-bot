using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract.BaseRepository;

namespace EnglishAssistantTelegramBot.Console.Repository.Abstract
{
    public interface IRequestHistoryRepository : IBaseRepository<RequestHistory>
    {
        /// <summary>
        /// Get unique chat id list from request histories.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<long>> GetChatIdListAsync();
    }
}
