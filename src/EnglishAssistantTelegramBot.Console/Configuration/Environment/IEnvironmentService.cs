using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace EnglishAssistantTelegramBot.Console.Configuration.Environment
{
    // <summary>
    /// Environment service interface. This service provides IConfiguration instance.
    /// </summary>
    public interface IEnvironmentService
    {
        /// <summary>
        /// This method returns IConfiguration instance.
        /// </summary>
        /// <returns></returns>
        IConfiguration Configuration { get; }
        /// <summary>
        /// Check mode is development.
        /// </summary>
        bool IsDevelopment { get; }
        /// Check mode is production.
        bool IsProduction { get; }
    }
}
