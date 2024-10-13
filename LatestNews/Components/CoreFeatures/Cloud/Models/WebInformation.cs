namespace LatestNews.Components.CoreFeatures.Cloud.AccessManagement.Models
{
    using Newtonsoft.Json;

    /// <summary>
    ///     A model wrapping all information about the link.
    /// </summary>
    public class WebInformation
    {
        /// <summary>
        /// Gets or sets the title of the web resource.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the description of the web resource.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of an image representing the web resource.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the URL of the web resource.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

    }
}
