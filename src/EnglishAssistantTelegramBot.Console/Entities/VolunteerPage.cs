using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Entities
{
    public class VolunteerPage : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Tr { get; set; }
        public string En { get; set; }
    }
}
