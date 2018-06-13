using Microsoft.Extensions.Configuration;

namespace TextAnalyticsExamples.LanguageUnderstanding
{
    public class EnLuisConfiguration : ILuisConfiguration
    {
        private readonly IConfiguration _configuration;

        public EnLuisConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ApiKey => _configuration["luisApp:english:apiKey"]; // from your azure service
        public string ApiId => _configuration["luisApp:english:apiId"]; // from your luis.ai settings page
        public string Domain => _configuration["luisApp:english:domain"]; // from your azure service
    }

    public class SpLuisConfiguration : ILuisConfiguration
    {
        private readonly IConfiguration _configuration;

        public SpLuisConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ApiKey => _configuration["luisApp:spanish:apiKey"]; // from your azure service
        public string ApiId => _configuration["luisApp:spanish:apiId"]; // from your luis.ai settings page
        public string Domain => _configuration["luisApp:spanish:domain"]; // from your azure service
    }
}