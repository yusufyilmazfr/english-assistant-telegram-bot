using System;
using System.Collections.Generic;
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
    public class DapperVolunteerPageRepository : DapperBaseRepository<VolunteerPage>, IVolunteerPageRepository
    {
        // I will move base from here to app settings or in another file.
        private readonly string _connectionString;

        public DapperVolunteerPageRepository(IConfigurationContext configurationContext) : base(configurationContext)
        {
            _connectionString = configurationContext.MySQLConnectionString;
        }

        public async Task<VolunteerPage> GetAnyVolunteerPageAsync()
        {
            const string sql = "SELECT * FROM volunteerpage ORDER BY RAND() LIMIT 1;";

            await using var connection = new MySqlConnection(_connectionString);

            return await connection.QueryFirstOrDefaultAsync<VolunteerPage>(new CommandDefinition(sql));
        }
    }
}
