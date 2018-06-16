using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace TextAnalyticsExamples.TextAnalytics
{
    public interface IKeyPhraseSensor
    {
        Task<IList<string>> AnalyzeTextAsync(string text, string isoLanguage);
    }
}