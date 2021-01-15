using System;
using System.Collections.Generic;
using System.Text;
using EnglishAssistantTelegramBot.Console.Configuration.Context;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper.BaseRepository;

namespace EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper
{
    public class DapperRequestHistoryRepository : DapperBaseRepository<RequestHistory>, IRequestHistoryRepository
    {
        public DapperRequestHistoryRepository(IConfigurationContext configurationContext) : base(configurationContext)
        {

        }
    }
}
