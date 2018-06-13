using System.Threading.Tasks;

namespace TextAnalyticsExamples.TextAnalytics
{
    public interface ISentimentSensor
    {
        Task<double?> AnalyzeTextAsync(string text, string isoLanguage);
    }
}