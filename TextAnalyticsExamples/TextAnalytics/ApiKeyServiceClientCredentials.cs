using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace TextAnalyticsExamples.TextAnalytics
{
    public class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {
        private readonly IAnalyticsConfiguration _configuration;

        public ApiKeyServiceClientCredentials(IAnalyticsConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", _configuration.ApiKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}