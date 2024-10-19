namespace LatestNews.Components.CoreFeatures.Cloud.Wrappers
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    ///     A wrapper class for the <see cref="HttpClient"/>.
    /// </summary>
    public interface IHttpClientWrapper
    {
        /// <summary>
        ///     Sets the base address of the client.
        /// </summary>
        /// <param name="address">The address string.</param>
        void SetBaseAddress(string address);

        /// <summary>
        ///     Sends a request with the given preview link.
        /// </summary>
        /// <param name="previewLink">The link which need to be previewed.</param>
        /// <returns>The response message or null if an error occurred.</returns>
        Task<HttpResponseMessage> SendRequestAsync(string previewLink);

    }
}