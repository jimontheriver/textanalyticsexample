using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace TextAnalyticsExamples.TextAnalytics
{
    /// <summary>
    /// See <seealso cref="https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics.V2.0/operations/56f30ceeeda5650db055a3c9"/>
    /// </summary>
    public class SentimentSensor : ISentimentSensor
    {
        private readonly IApiKeyServiceClientCredentialsFactory _apiKeyServiceClientCredentialsFactory;

        public SentimentSensor(IApiKeyServiceClientCredentialsFactory apiKeyServiceClientCredentialsFactory)
        {
            _apiKeyServiceClientCredentialsFactory = apiKeyServiceClientCredentialsFactory;
        }

        public async Task<double?> AnalyzeTextAsync(string text, string isoLanguage)
        {
            ITextAnalyticsAPI client = new TextAnalyticsAPI(_apiKeyServiceClientCredentialsFactory.GetServiceClientCredentials());
            client.AzureRegion = AzureRegions.Eastus;

            var result = await client.SentimentAsync(new MultiLanguageBatchInput
            {
                Documents = new List<MultiLanguageInput>
                {
                    new MultiLanguageInput(id: Guid.NewGuid().ToString(), text: text, language:isoLanguage) // Id is nullable, but it's required!
                }
            });

            return result.Documents.First().Score;
        }
    }
}
