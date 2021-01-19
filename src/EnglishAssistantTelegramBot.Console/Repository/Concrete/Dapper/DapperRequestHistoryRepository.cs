using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using EnglishAssistantTelegramBot.Console.Configuration.Context;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper.BaseRepository;
using MySql.Data.MySqlClient;

namespace EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper
{
    public class DapperRequestHistoryRepository : DapperBaseRepository<RequestHistory>, IRequestHistoryRepository
    {
        private readonly string _connectionString;

        public DapperRequestHistoryRepository(IConfigurationContext configurationContext) : base(configurationContext)
        {
            _connectionString = configurationContext.MySQLConnectionString;
        }

        public async Task<IEnumerable<long>> GetChatIdListAsync()
        {
            string sql = "SELECT ChatId FROM requesthistory GROUP BY ChatId HAVING ChatId > 0";

            await using var connection = new MySqlConnection(_connectionString);

            return await connection.QueryAsync<long>(new CommandDefinition(sql));
        }
    }
}
