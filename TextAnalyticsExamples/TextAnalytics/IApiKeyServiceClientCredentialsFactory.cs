using Microsoft.Rest;

namespace TextAnalyticsExamples.TextAnalytics
{
    public interface IApiKeyServiceClientCredentialsFactory
    {
        ServiceClientCredentials GetServiceClientCredentials();
    }
}