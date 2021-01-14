using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
