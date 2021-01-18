using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Entities
{
    public class DailyPhrase : BaseEntity
    {
        public string Tr { get; set; }
        public string En { get; set; }
    }
}
