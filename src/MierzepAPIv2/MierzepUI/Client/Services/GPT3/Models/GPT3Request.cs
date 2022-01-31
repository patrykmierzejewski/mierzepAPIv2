using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MierzepUI.Client.Services.GPT3.Models
{
    public class GPT3Request
    {
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }

        [JsonProperty("top_p")]
        public int TopP { get; set; }

        [JsonProperty("frequency_penalty")]
        public double FrequencyPenalty { get; set; }

        [JsonProperty("presence_penalty")]
        public double PresencePenalty { get; set; }
    }
}
