using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Configuration.Context
{
    /// <summary>
    /// This interface provides value of configuration properties.
    /// </summary>
    public interface IConfigurationContext
    {
        public string MySQLConnectionString { get; set; }
        public string TelegramBotKey { get; set; }
    }
}
