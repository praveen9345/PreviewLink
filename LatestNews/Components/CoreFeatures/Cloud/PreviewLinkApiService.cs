namespace LatestNews.Components.CoreFeatures.Cloud
{
    using System.Threading.Tasks;
    using LatestNews.Components.CoreFeatures.Cloud.AccessManagement.Models;
    using LatestNews.Components.CoreFeatures.Cloud.Wrappers;

    /// <summary>
    ///      Service responsible for fetching and processing preview link information from a web API.
    /// </summary>
    public class PreviewLinkApiService : IPreviewLinkApiService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly IJsonConvertWrapper _jsonConvertWrapper;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PreviewLinkApiService"/> class 
        ///     with the specified HTTP client wrapper and JSON converter wrapper.
        /// </summary>
        /// <param name="httpClientWrapper">The HTTP client wrapper to handle web requests.</param>
        /// <param name="jsonConvertWrapper">The JSON converter wrapper to handle JSON serialization/deserialization.</param>
        public PreviewLinkApiService(IHttpClientWrapper httpClientWrapper, IJsonConvertWrapper jsonConvertWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
            _jsonConvertWrapper = jsonConvertWrapper;

            _httpClientWrapper.SetBaseAddress(Configuration.Models.Constants.API_BASE_URL);
        }

        /// <summary>
        ///   Retrieves web information based on the provided preview link by sending an HTTP request 
        ///   and deserializing the JSON response into a <see cref="WebInformation"/> object.
        /// </summary>
        /// <param name="previewLink">The preview link to fetch web information for.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a 
        /// <see cref="WebInformation"/> object if successful; otherwise, null.</returns>
        public async Task<WebInformation> GetWebInformation(string previewLink)
        {
            var response = await _httpClientWrapper.SendRequestAsync(previewLink);

             if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                return _jsonConvertWrapper.DeserializeObjectAsync<WebInformation>(jsonContent);
            }

            return null;
        }
    }
}