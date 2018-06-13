
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