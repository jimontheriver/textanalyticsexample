using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TextAnalyticsExamples.LanguageUnderstanding
{

    public class LuisResponse
    {
        public string Query { get; set; }
        public IntentResult TopScoringIntent { get; set; }
        public IntentResult[] Intents { get; set; }
        public object[] Entities { get; set; }
        public SentimentAnalysis SentimentAnalysis { get; set; }
    }

    

    public class SentimentAnalysis
    {
        public float Score { get; set; }
    }

    public class IntentResult
    {
        [JsonProperty("intent")]
        public string Name { get; set; }
        public float Score { get; set; }
    }

}
