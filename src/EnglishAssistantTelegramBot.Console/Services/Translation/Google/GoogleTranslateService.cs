using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EnglishAssistantTelegramBot.Console.Services.Translation.Google
{
    class GoogleTranslateService : ITranslateService
    {
        private readonly HttpClient _httpClient;

        public GoogleTranslateService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<TranslationResult> Translate(Translation translation)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={translation.SourceLanguage}&tl={translation.DestionationLanguage}&dt=t&dt=bd&q={translation.Text}&dj=1";

            var httpResponseMessage = await _httpClient.GetAsync(url);

            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TranslationResult>(content);
        }
    }
}
