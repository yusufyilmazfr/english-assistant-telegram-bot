using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EnglishAssistantTelegramBot.Console.Configuration.Context;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper.BaseRepository;
using MySql.Data.MySqlClient;

namespace EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper
{
    public class DapperWordRepository : DapperBaseRepository<Word>, IWordRepository
    {
        private readonly string _connectionString;

        public DapperWordRepository(IConfigurationContext configurationContext) : base(configurationContext)
        {
            _connectionString = configurationContext.MySQLConnectionString;
        }

        public async Task<Word> GetAnyWordAsync()
        {
            const string sql = "SELECT * FROM word ORDER BY RAND() LIMIT 1;";

            await using var connection = new MySqlConnection(_connectionString);

            return await connection.QueryFirstOrDefaultAsync<Word>(new CommandDefinition(sql));
        }
    }
}
