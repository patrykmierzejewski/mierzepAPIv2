using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MierzepUI.Client.Services.GPT3.Models
{
    public class Choice
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("logprobs")]
        public string Logprobs { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }
    }
}
