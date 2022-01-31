using MierzepUI.Client.Services.GPT3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MierzepUI.Client.Services.GPT3
{
    public class GPT3Service : IDisposable
    {
        private string _url = "https://api.openai.com/v1/engines/text-davinci-001/completions";
        private HttpClient _httpClient = null;
        
        public GPT3Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");
        }

        public async Task<string> ConnectGPT3(string text)
        {
            if (text.Equals("") 
                || String.IsNullOrWhiteSpace(text) 
                || String.IsNullOrEmpty(text) 
                || text.Split(' ').Count() < 5)
                return "Powtórz. Wypowiedź nie jest dokładna";
            
            string result = string.Empty;
            GTP3Response gpt = null;
            try
            {
                GPT3Request gPT3Request = new GPT3Request()
                {
                    Prompt = text, //text this
                    Temperature = 0,
                    MaxTokens = 64,
                    TopP = 1,
                    FrequencyPenalty = 0,
                    PresencePenalty = 0
                };

                var json = JsonConvert.SerializeObject(gPT3Request);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var post = await _httpClient.PostAsync(_url, content);

                result = await post.Content.ReadAsStringAsync();

                Console.WriteLine(result);

                gpt = JsonConvert.DeserializeObject<GTP3Response>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return gpt.Choices.FirstOrDefault().Text; 
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
