using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Commands.Abstract;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace EnglishAssistantTelegramBot.Console.Commands.Concrete
{
    class SendStoryCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public SendStoryCommand(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public async Task ExecuteAsync(Message message)
        {
            System.Console.WriteLine($"It receied new message: {JsonConvert.SerializeObject(message.Chat)} in this room: {message.Chat.Id}");

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Owv! {message.Chat.FirstName} came back! :) 💖");

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"I am going to send new story for you! 💖🎉");

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Firstly, I am sharing story. 🤗");

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Gladiators About two and a half thousand years ago, a tribe in Italy started to grow into an empire across Europe, North Africa and the Middle East. Their capital city was Rome and they were called the Romans. The Roman Empire was almost always at war and this brought large numbers of slaves for mines, construction and farming. When an important farmer died, some of his male slaves were made to fight to the death with the short Roman sword called the 'gladus'. The two fighters were called gladiators. More people came to watch the most dangerous fights and so the farmer had a crowd at his funeral. Over time, the Roman Empire and its cities grew and grew: Rome had a population of one million. The rich saw poor people as a danger and so the emperor would give them bread when they were hungry. In times of difficulty in war or politics, he paid for a show, often continuing many days and held in a stadium where thousands could sit, watch and forget their problems. The shows also kept the poor off the streets. The shows were often cruel. Sometimes men and women were fed to lions as the crowd laughed. But, the most popular event was the gladiator fight. These gladiators were mostly criminals, prisoners of war and slaves but some were volunteers. The reason that some men volunteered was that the best gladiators became rich and famous with thousands of fans, like the movie stars of later times. However, most died without ever getting rich or famous. There were a lot of different ways of fighting. In the beginning, there was only the sword, but some later fought with spears, axes and even nets. Most fights were on foot but, sometimes, on horseback or even in ships in stadiums specially filled with water. If a gladiator won a fight, he would look at the emperor in the stadium. If the emperor put his thumb up, it meant the loser should live; but if he put his thumb down, the winner killed the loser. He usually put it down. We can still see the 'thumbs up' icon nowadays on the internet but the nearest thing to gladiators today is, probably, the bull fight in Spain and parts of Latin America.");

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"On the other hand I am sharing listening. 🎊");
            await _telegramBotClient.SendAudioAsync(message.Chat.Id, new InputOnlineFile("https://cdn.readlistenlearn.net/audio/legacy/e22c8e10f6d920b91a08a47cb295a998.mp3"));

            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Don't be a stranger! 💖");
        }
    }
}
