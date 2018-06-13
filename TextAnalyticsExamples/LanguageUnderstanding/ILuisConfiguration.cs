namespace TextAnalyticsExamples.LanguageUnderstanding
{
    public interface ILuisConfiguration
    {
        string ApiKey { get; }
        string ApiId { get; }
        string Domain { get; }
    }
}