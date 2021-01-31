using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishAssistantTelegramBot.Console.Enums
{
    public enum EnumEnglishLevel
    {
        None,
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }

    public static class EnumExtensions
    {
        public static int ToInt(this Enum @enum)
        {
            return (int) (object) @enum;
        }
    }
}
