using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace EnglishAssistantTelegramBot.Console.Entities
{
    public class BaseEntity
    {
        [ExplicitKey]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
