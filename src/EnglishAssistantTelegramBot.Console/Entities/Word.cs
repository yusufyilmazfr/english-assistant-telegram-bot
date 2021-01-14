using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Entities
{
    public class Word : BaseEntity
    {
        public string Tr { get; set; }
        public string En { get; set; }
    }
}
