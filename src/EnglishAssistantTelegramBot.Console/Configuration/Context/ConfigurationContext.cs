using System;
using System.Collections.Generic;
using System.Text;
using EnglishAssistantTelegramBot.Console.Configuration.Environment;

namespace EnglishAssistantTelegramBot.Console.Configuration.Context
{
    public class ConfigurationContext : IConfigurationContext
    {
        public string MySQLConnectionString { get; set; }
        public string TelegramBotKey { get; set; }

        public ConfigurationContext(IEnvironmentService environmentService)
        {
            MySQLConnectionString = environmentService.Configuration["MySQLConnectionString"];
            TelegramBotKey = environmentService.Configuration["TelegramBotKey"];
        }
    }
}
