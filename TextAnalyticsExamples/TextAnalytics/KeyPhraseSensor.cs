using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAnalyticsExamples.TextAnalytics
{
    public class KeyPhraseSensor : IKeyPhraseSensor
    {
        private readonly IApiKeyServiceClientCredentialsFactory _apiKeyServiceClientCredentialsFactory;

        public KeyPhraseSensor(IApiKeyServiceClientCredentialsFactory apiKeyServiceClientCredentialsFactory)
        {
            _apiKeyServiceClientCredentialsFactory = apiKeyServiceClientCredentialsFactory;
        }


        public async Task<IList<string>> AnalyzeTextAsync(string text, string isoLanguage)
        {
            ITextAnalyticsAPI client = new TextAnalyticsAPI(_apiKeyServiceClientCredentialsFactory.GetServiceClientCredentials());
            client.AzureRegion = AzureRegions.Eastus;
           
            var result = await client.KeyPhrasesAsync(new MultiLanguageBatchInput
            {
                Documents = new List<MultiLanguageInput>
                {
                    new MultiLanguageInput(id: Guid.NewGuid().ToString(), text: text, language:isoLanguage) // Id is nullable, but it's required!
                }
            });
            return result.Documents?.FirstOrDefault()?.KeyPhrases;
        }
    }
}
