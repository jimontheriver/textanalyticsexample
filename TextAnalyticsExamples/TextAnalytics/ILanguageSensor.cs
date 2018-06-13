using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace TextAnalyticsExamples.TextAnalytics
{
    public interface ILanguageSensor
    {
        Task<IList<DetectedLanguage>> AnalyzeTextAsync(string text);
    }
}