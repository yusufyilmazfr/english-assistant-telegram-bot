using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Entities
{
    public class Story : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int TotalWords { get; set; }
        public int TotalUniqueWords { get; set; }
        public string PreviewImage { get; set; }
        public string SoundFile { get; set; }
    }
}
