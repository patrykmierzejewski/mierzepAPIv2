using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MierzepAPIv2.ExternalAPI.ExternalAPI.OMDB
{
    public partial class OmdbClient : IOmdbClient
    {
        private string _baseUrl = "http://www.omdbapi.com";

        private readonly HttpClient _httpClient;

        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public OmdbClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OmdbClient");

            _baseUrl = _httpClient.BaseAddress.ToString();

            _settings = new Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
        public async Task<string> GetMovieAsync(string searchFilter, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("?apikey=88541cdd");
            urlBuilder.Append("&t=").Append(searchFilter);

            var client = _httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    var url = urlBuilder.ToString();

                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                    
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(true);
                        return responseData;
                    }
                    else
                        return "Something bad Happened";
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception message", ex);
            }
        }
        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
    }
}
