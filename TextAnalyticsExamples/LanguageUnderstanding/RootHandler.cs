using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace TextAnalyticsExamples.LanguageUnderstanding
{
    public class RootHandler
    {
        private readonly IDictionary<string, ILuisConfiguration> _configurations;

        public RootHandler(IDictionary<string, ILuisConfiguration> configurations)
        {
            _configurations = configurations;
        }
        public async Task<string> HandleTextAsync(string text, string language)
        {

            if (_configurations.TryGetValue(language, out var config))
            {
                var result = await MakeCall2(text, config);
                
                return result.TopScoringIntent.Name;
            }

            return null;
        }

        protected async Task<LuisResponse> MakeCall2(string text, ILuisConfiguration configuration)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", configuration.ApiKey);

            queryString["q"] = text;


            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "true";
            queryString["spellCheck"] = "false";
            queryString["staging"] = "false";

            var uri = "https://" + configuration.Domain + ".api.cognitive.microsoft.com/luis/v2.0/apps/" + configuration.ApiId + "?" + queryString;

            var response = await client.GetAsync(uri);

            var strResponseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<LuisResponse>(strResponseContent);

            return result;

        }

    }
}
