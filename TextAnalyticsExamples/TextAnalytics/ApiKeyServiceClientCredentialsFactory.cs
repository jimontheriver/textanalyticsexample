using Microsoft.Rest;

namespace TextAnalyticsExamples.TextAnalytics
{
    public class ApiKeyServiceClientCredentialsFactory : IApiKeyServiceClientCredentialsFactory
    {
        private readonly IAnalyticsConfiguration _configuration;

        public ApiKeyServiceClientCredentialsFactory(IAnalyticsConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ServiceClientCredentials GetServiceClientCredentials()
        {
            return new ApiKeyServiceClientCredentials(_configuration);
        }
    }
}