using Azure;
using Azure.AI.TextAnalytics;

namespace ServicesLayer.Services;

public class SentimentAnalysisService
{
	// This example requires environment variables named "LANGUAGE_KEY" and "LANGUAGE_ENDPOINT"
	static string languageKey = Environment.GetEnvironmentVariable("LANGUAGE_KEY");
	static string languageEndpoint = Environment.GetEnvironmentVariable("LANGUAGE_ENDPOINT");

	private static readonly AzureKeyCredential credentials = new AzureKeyCredential(languageKey);
	private static readonly Uri endpoint = new Uri(languageEndpoint);
	private readonly TextAnalyticsClient _client;

	public SentimentAnalysisService()
	{
		_client = new(endpoint, credentials);
	}

	public async Task<string> Analyze(string message)
	{
		Response<DocumentSentiment> response = await _client.AnalyzeSentimentAsync(message);
		DocumentSentiment docSentiment = response.Value;

		return docSentiment.Sentiment.ToString();
	}

}


