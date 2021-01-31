using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract.BaseRepository;

namespace EnglishAssistantTelegramBot.Console.Repository.Abstract
{
    public interface IStoryRepository : IBaseRepository<Story>
    {
        /// <summary>
        /// It returns any story
        /// </summary>
        /// <returns></returns>
        Task<Story> GetAnyStoryAsync();
        /// <summary>
        /// It returns any story
        /// </summary>
        /// <param name="level">Story level</param>
        /// <returns></returns>
        Task<Story> GetAnyStoryAsync(int level);
    }
}
