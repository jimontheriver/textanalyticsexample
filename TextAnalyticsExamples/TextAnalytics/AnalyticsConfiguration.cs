using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace TextAnalyticsExamples.TextAnalytics
{
    public class AnalyticsConfiguration : IAnalyticsConfiguration
    {
        private readonly IConfiguration _configuration;

        public AnalyticsConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ApiKey => _configuration["textApp:apiKey"];
    }
}
