using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Services.Translation
{
    public class TranslationResult
    {
        public List<Sentence> Sentences { get; set; }

        public class Sentence
        {
            public string Trans { get; set; }
            public string Orig { get; set; }
        }
    }
}
