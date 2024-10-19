namespace LatestNews.Components.CoreFeatures.Cloud
{
    using System.Threading.Tasks;
    using LatestNews.Components.CoreFeatures.Cloud.AccessManagement.Models;

    /// <summary>
    ///     Provides an interface for fetching and retrieving web page preview information.
    /// </summary>
    public interface IPreviewLinkApiService
    {
        /// <summary>
        ///  Retrieves web information such as title, description, image, and URL from the specified preview link.
        /// </summary>
        /// <param name="previewLink">The URL of the web page to retrieve information from.</param>
        /// <returns>A <see cref="WebInformation"/> object containing the extracted details of the web page.</returns>
        Task<WebInformation> GetWebInformation(string previewLink);
    }
}