using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MierzepUI.Client.Services.GPT3.Models
{
    public class GTP3Response
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text_completion")]
        public string TextCompletion { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }
    }
}
