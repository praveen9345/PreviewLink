namespace LatestNews.Components.CoreFeatures.Cloud.Wrappers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using ErrorManagement;

    /// <summary>
    ///     Implementation of the <see cref="HttpClient"/> wrapper.
    /// </summary>
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly IErrorLogger _errorLogger;
        private HttpClient _client;

        /// <summary>
        ///     Initializes an instance of the <see cref="HttpClientWrapper"/> class.
        /// </summary>
        /// <param name="errorLogger">The error logger to log error information.</param>
        public HttpClientWrapper(IErrorLogger errorLogger)
        {
            _errorLogger = errorLogger;
        }

        /// <summary>
        ///     Sends a request with the given preview link.
        /// </summary>
        /// <param name="previewLink">The link which need to be previewed.</param>
        /// <returns>The response message or null if an error occurred.</returns>
        public async Task<HttpResponseMessage> SendRequestAsync(string previewLink)
        {
            try
            {
                _errorLogger.LogError("HttpClientWrapper.cs:SendRequestAsync:", $"Making call to base address {Client.BaseAddress}");
                string apiUrl = Client.BaseAddress + "?q=" + previewLink;

                var response =  await Client.GetAsync(apiUrl);
                if (response == null)
                {
                    _errorLogger.LogError("HttpClientWrapper.cs:SendRequestAsync:","Response to sent request was null.");
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent("Response to sent request was null.")
                    };
                }
                return response;
            }
            catch (Exception exception)
            {
                _errorLogger.LogError("HttpClientWrapper.cs:SendRequestAsync:", exception.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Exception caught when sending a request.")
                };
            }
        }

        private HttpClient Client => _client ??= SetupClientAsync();

        /// <summary>
        ///     Sets the base address of the client.
        /// </summary>
        /// <param name="address">The address string.</param>
        public void SetBaseAddress(string address)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(address);
                Client.DefaultRequestHeaders.Add("X-Linkpreview-Api-Key", Configuration.Models.Constants.API_KEY);
            }
        }

        private HttpClient SetupClientAsync()
        {
            return new HttpClient();
        }
    }
}