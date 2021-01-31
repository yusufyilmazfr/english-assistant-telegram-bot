using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Client;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Enums;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using static System.String;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    class SendStoryCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IStoryRepository _storyRepository;

        private static InlineKeyboardMarkup _inlineKeyboardMarkup;

        private const int _telegramMessageMaxLength = 4090;

        public SendStoryCommand(ITelegramClient telegramClient, IStoryRepository storyRepository)
        {
            _telegramBotClient = telegramClient.GetInstance();
            _storyRepository = storyRepository;

            _telegramBotClient.OnCallbackQuery += _telegramBotClient_OnCallbackQuery;
        }

        private async void _telegramBotClient_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            await _telegramBotClient.SendChatActionAsync(e.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

            var level = int.Parse(e.CallbackQuery.Data);

            await SendStartingMessage(e.CallbackQuery.Message);

            var story = await _storyRepository.GetAnyStoryAsync(level);

            if (story == null)
            {
                await _telegramBotClient.SendChatActionAsync(e.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                await _telegramBotClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, $"Ops! We are so sorry. 😿 We don't have A1 level story.");

                return;
            }

            await SendImageWhenExists(e.CallbackQuery.Message, story);

            await SendStoryInformation(e.CallbackQuery.Message, story);

            await SendStoryContent(e.CallbackQuery.Message, story);

            await SendSoundWhenExists(e.CallbackQuery.Message, story);

            await _telegramBotClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, $"Don't be a stranger! 💖");
        }

        public async Task ExecuteAsync(Message message)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            await _telegramBotClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Please choose story level. ✨",
                replyMarkup: GenerateInlineKeyboardMarkup()
            );
        }

        private async Task SendStoryInformation(Message message, Story story)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            string messageContent = $"Story: *{story.Title}*\n" +
                                    $"Author: *{story.Author ?? "😒 😞"}*\n" +
                                    $"Theme: *{story.Theme}*\n" +
                                    $"Level: *{story.Level.ToString()}*\n" +
                                    $"Total Words: *{story.TotalWords}*\n" +
                                    $"Total Unique Words: *{story.TotalUniqueWords}*";

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, messageContent, parseMode: ParseMode.Markdown);
        }

        private async Task SendStoryContent(Message message, Story story)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Firstly, I am sharing story. 🤗");

            if (story.Content.Length <= _telegramMessageMaxLength)
            {
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, story.Content);
            }
            else
            {
                var startIndex = 0;
                var section = "";
                var endIndex = _telegramMessageMaxLength;

                while (true)
                {
                    if (endIndex >= story.Content.Length)
                    {
                        section = story.Content.Substring(startIndex);
                        await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, section);

                        break;
                    }

                    section = story.Content.Substring(startIndex, _telegramMessageMaxLength) + "...";

                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, section);

                    startIndex = endIndex;
                    endIndex += _telegramMessageMaxLength;
                }
            }
        }

        private async Task SendStartingMessage(Message message)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"I am going to send new story for you! 💖🎉");
        }

        private async Task SendSoundWhenExists(Message message, Story story)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.RecordAudio);

            var soundPath = $"Assets/sounds/{ story.SoundFile}";

            if (IsNullOrEmpty(story.SoundFile) || System.IO.File.Exists(soundPath) == false)
            {
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, "Ops! This story does not have sound. 😥");
            }
            else
            {
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"On the other hand I am sharing listening. 🎊");

                await using var audioStream = System.IO.File.OpenRead($"Assets/sounds/{story.SoundFile}");

                await _telegramBotClient.SendAudioAsync(message.Chat.Id, new InputMedia(audioStream, story.Title));
            }
        }

        private async Task SendImageWhenExists(Message message, Story story)
        {
            await _telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

            var imagePath = $"Assets/preview-images/{ story.PreviewImage}";

            if (IsNullOrEmpty(story.PreviewImage) || System.IO.File.Exists(imagePath) == false)
            {
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, "Ops! This story does not have a image. 😥");
            }
            else
            {
                await using var imageStream = System.IO.File.OpenRead(imagePath);

                await _telegramBotClient.SendPhotoAsync(message.Chat.Id, new InputMedia(imageStream, story.Title));
            }
        }

        private InlineKeyboardMarkup GenerateInlineKeyboardMarkup()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("A1– Beginner", EnumEnglishLevel.A1.ToInt().ToString()),
                        InlineKeyboardButton.WithCallbackData("A2- Elementary", EnumEnglishLevel.A2.ToInt().ToString()),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("B1- Pre-Intermediate", EnumEnglishLevel.B1.ToInt().ToString()),
                        InlineKeyboardButton.WithCallbackData("B2- Intermediate", EnumEnglishLevel.B2.ToInt().ToString()),
                    },
                    // third row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("C1- Upper-Indermediate", EnumEnglishLevel.C1.ToInt().ToString()),
                        InlineKeyboardButton.WithCallbackData("C2- Advanced", EnumEnglishLevel.C2.ToInt().ToString()),
                    }
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
