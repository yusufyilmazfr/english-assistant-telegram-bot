using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using Telegram.Bot.Types;

namespace EnglishAssistantTelegramBot.Console.Entities
{
    [Table("requesthistory")]
    public class RequestHistory : BaseEntity
    {
        public long ChatId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Text { get; set; }

        public RequestHistory(Message telegramMessage)
        {
            ChatId = telegramMessage.Chat.Id;
            UserName = telegramMessage.Chat.Username;
            FirstName = telegramMessage.Chat.FirstName;
            LastName = telegramMessage.Chat.LastName;
            Text = telegramMessage.Text;
            CreatedDate = DateTime.Now;
            ModifiedDate = CreatedDate;
        }
    }
}
