using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract.BaseRepository;

namespace EnglishAssistantTelegramBot.Console.Repository.Abstract
{
    public interface IVolunteerPageRepository : IBaseRepository<VolunteerPage>
    {
        /// <summary>
        /// It returns any story
        /// </summary>
        /// <returns></returns>
        Task<VolunteerPage> GetAnyVolunteerPageAsync();
    }
}
