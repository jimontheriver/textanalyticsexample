using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace TextAnalyticsExamples.TextAnalytics
{

    /// <summary>
    /// See <seealso cref="https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics.V2.0/operations/56f30ceeeda5650db055a3c7"/>
    /// </summary>
    public class LanguageSensor : ILanguageSensor
    {
        private readonly IApiKeyServiceClientCredentialsFactory _apiKeyServiceClientCredentialsFactory;

        public LanguageSensor(IApiKeyServiceClientCredentialsFactory apiKeyServiceClientCredentialsFactory)
        {
            _apiKeyServiceClientCredentialsFactory = apiKeyServiceClientCredentialsFactory;
        }

        public async Task<IList<DetectedLanguage>> AnalyzeTextAsync(string text)
        {
            ITextAnalyticsAPI client = new TextAnalyticsAPI(_apiKeyServiceClientCredentialsFactory.GetServiceClientCredentials());
            client.AzureRegion = AzureRegions.Eastus;

            var result = await client.DetectLanguageAsync(new BatchInput
            {
                Documents = new List<Input>
                {
                    new Input(id: Guid.NewGuid().ToString(), text: text) // Id is nullable, but it's required!
                }
            });
            return result.Documents.First().DetectedLanguages;
        }
    }
}
