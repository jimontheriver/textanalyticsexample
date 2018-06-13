using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using TextAnalyticsExamples.LanguageUnderstanding;
using TextAnalyticsExamples.TextAnalytics;

namespace TextAnalyticsExamples
{
    public class LiteBot
    {
        
        private readonly ApiKeyServiceClientCredentialsFactory _apiKeyServiceClientCredentialsFactory;
        private readonly Dictionary<string, ILuisConfiguration> _luisConfigurations;

        public LiteBot(IConfiguration configuration)
        {
            _luisConfigurations = new Dictionary<string, ILuisConfiguration>
            {
                {"en", new EnLuisConfiguration(configuration) },
                {"es", new SpLuisConfiguration(configuration)}
            };
            _apiKeyServiceClientCredentialsFactory =
                new ApiKeyServiceClientCredentialsFactory(new AnalyticsConfiguration(configuration));
        }
        public async Task ProcessCommandAsync(string command)
        {
            var language = await DetectLanguage(command);
            if (null == language)
            {
                Console.WriteLine("No lanugage detected.");
                return;
            }
            var sentiment = await DetectSentiment(command, language);

            var luis = await HandleLuisRoot(command, language.Split('-')[0]);
        }

        private async Task<string> DetectLanguage(string command)
        {
            var languageSensor = new LanguageSensor(_apiKeyServiceClientCredentialsFactory);
            var detectedLanguage = await languageSensor.AnalyzeTextAsync(command);
            DetectedLanguage firstRankedLanguage = null;
            foreach (var language in detectedLanguage.OrderByDescending(x => x.Score))
            {
                firstRankedLanguage = firstRankedLanguage ?? language;
                Console.WriteLine();
                Console.WriteLine($"Detected {language.Name}: {language.Score}");
                Console.WriteLine();
            }

            return firstRankedLanguage?.Iso6391Name;
        }

        private async Task<double?> DetectSentiment(string command, string language)
        {
            var sentimentSensor = new SentimentSensor(_apiKeyServiceClientCredentialsFactory);

            var sentimentScore = await sentimentSensor.AnalyzeTextAsync(command, language);
            var sentiment = sentimentScore > .75 ? "Good" : "Bad";
            Console.WriteLine($"It was a {sentiment} thought. ({sentimentScore})");
            return sentimentScore;
        }

        private async Task<string> HandleLuisRoot(string command, string language)
        {
            var handler = new RootHandler(_luisConfigurations);
            var result = await handler.HandleTextAsync(command, language);

            Console.WriteLine($"It was a {result} thought.");
            return result;
        }
    }
}
