using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LifeManager
{
    internal class ChatIntegration
    {
        private static readonly string apiKey = "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"; // Zde vlož svůj skutečný API klíč
        private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions";

        public static async Task<string> SendMessageAsync(string userMessage)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo", // Zkus model "gpt-3.5-turbo", pokud máš problém s GPT-4
                    messages = new[]
                    {
                        new { role = "user", content = userMessage }
                    }
                };



                var jsonRequest = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic parsedResponse = JsonConvert.DeserializeObject(jsonResponse);
                    return parsedResponse.choices[0].message.content;
                }
                else
                {
                    throw new Exception($"API request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
                }
            }
        }
    }
}
