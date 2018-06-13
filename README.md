Examples for Azure Text Analytics API and Similar Cognitive Services
=

What are we trying to show?
--

- Do I have to build a chatbot to use Cognitive Services?
    - No. Microsoft is frequently marketing Cognitive Services with the bot builder framework, but they are independent of one another. If you need to understand user intent, language, or anything about some text, then Text Analytics and LUIS may be what you need.
- Why not just use a search engine to help my users find stuff?
    - Search Engines are very good at finding things, but they can't understand the intention of a user. If you user asks "show me your store nearest to Omaha." you need to *understand* what the user wants. You need to get "Omaha" and "store" out of that. Search Engines won't do that by themselves (although some packages may include some language understanding for you).
- When do you use LUIS, when do you use QnAMaker, and when do you Text Analytics? How do you combine all three?
    - Text Analytics: Understand a some basic information about the utterance.
    - LUIS: Build a specific set of rules that maps what the user says to a concept within your application and then extract key values from those statements.
    - QnA Maker: Simply FAQ-as-a-Service. These are search powered, not really a cognitive service per se, but you see this service used in chat-bot examples enough that you may be confused.
- How does LUIS rank a user's statement and what gotchas can you run into?
    - See Here: https://docs.microsoft.com/en-us/azure/cognitive-services/LUIS/luis-concept-prediction-score
    - Be aware the LUIS is fairly tolerant of typos as part of an utterance, but if the typo is within an entity, it will usually not recognize it (use spell check!)
- How do you improve LUIS's results based on user feedback?
    - Review [Utterances](https://docs.microsoft.com/en-us/azure/cognitive-services/LUIS/luis-concept-review-endpoint-utterances) to select addtional examples
    - Setup [Patterns](https://docs.microsoft.com/en-us/azure/cognitive-services/LUIS/luis-concept-patterns) to improve detection of similar utterances.
    - Use [Phrase Lists](https://docs.microsoft.com/en-us/azure/cognitive-services/LUIS/luis-concept-feature) to expand your app's vocabulary without expanding the number of utterances.
- How do you set up LUIS Intents and Entities via API?
    - There are some SDKs, but the latest/greatest continues to be the [REST API](https://westus.dev.cognitive.microsoft.com/docs/services/5890b47c39e2bb17b84a55ff/operations/5890b47c39e2bb052c5b9c2f) because the SDKs ultimately use that.




Running it
--

You will need an Azure Text Analytics API Key https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-access-key

You will need to create LUIS Apps for English and Spanish: https://docs.microsoft.com/en-us/azure/cognitive-services/luis/luis-get-started-cs-get-intent#create-luis-subscription-key




Set Secrets for your LUIS APIs
--

(see https://medium.com/@granthair5/how-to-add-and-use-user-secrets-to-a-net-core-console-app-a0f169a8713f for how user secrets are being managed.)

Add this secrets file `%APPDATA%\Microsoft\UserSecrets\81a3edd0-2092-40a2-a04d-dcb46d5ca9ff\secrets.json` with this content
~~~
{
        "luisApp": {
            "english": {
                "apiId": "YOUR_APP_ID_FOR_THE_ENGLISH_APP",
                "apiKey": "YOUR_API_KEY_FOR_THE_ENGLISH_APP",
                "domain": "YOUR_AZURE_REGION_FOR_THE_ENGLISH_API_KEY"
            },
            "spanish": {
                "apiId": "YOUR_APP_ID_FOR_THE_ENGLISH_APP",
                "apiKey": "YOUR_API_KEY_FOR_THE_ENGLISH_APP",
                "domain": "YOUR_AZURE_REGION_FOR_THE_SPANISH_API_KEY"
            }
        },
        "textApp": {
            "apiKey": "YOUR_API_KEY_FOR_THE_TEXT_ANALYTICS_APP"
        }
}
~~~

References 
-

- Azure Text Analytics API - https://azure.microsoft.com/en-us/services/cognitive-services/text-analytics/
- LUIS https://www.luis.ai/
- LUIS Endpoint API - https://westus.dev.cognitive.microsoft.com/docs/services/5819c76f40a6350ce09de1ac/operations/5819c77140a63516d81aee78
- LUIS Management API - https://westus.dev.cognitive.microsoft.com/docs/services/5890b47c39e2bb17b84a55ff/operations/5890b47c39e2bb052c5b9c2f
- QnA MAker - https://www.qnamaker.ai/
