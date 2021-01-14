using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using static System.String;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    class SendStoryCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IStoryRepository _storyRepository;

        private const int _telegramMessageMaxLength = 4090;

        public SendStoryCommand(ITelegramBotClient telegramBotClient, IStoryRepository storyRepository)
        {
            _telegramBotClient = telegramBotClient;
            _storyRepository = storyRepository;
        }

        public async Task ExecuteAsync(Message message)
        {
            await SendStartingMessage(message);

            var story = await _storyRepository.GetAnyStoryAsync();

            await SendImageWhenExists(message, story);

            await SendStoryInformation(message, story);

            await SendStoryContent(message, story);

            await SendSoundWhenExists(message, story);

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Don't be a stranger! 💖");
        }

        private async Task SendStoryInformation(Message message, Story story)
        {
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

                    section = story.Content.Substring(startIndex, endIndex) + "...";

                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, section);

                    startIndex = endIndex;
                    endIndex *= 2;
                }
            }
        }

        private async Task SendStartingMessage(Message message)
        {
            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Owv! {message.Chat.FirstName} came back! :) 💖");

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"I am going to send new story for you! 💖🎉");
        }

        private async Task SendSoundWhenExists(Message message, Story story)
        {
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
    }
}
