using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Services.Translation
{
    public class Translation
    {
        public string SourceLanguage { get; set; }
        public string DestionationLanguage { get; set; }
        public string Text { get; set; }

        public Translation(string sourceLanguage, string destionationLanguage, string text)
        {
            SourceLanguage = sourceLanguage;
            DestionationLanguage = destionationLanguage;
            Text = text;
        }
    }
}
