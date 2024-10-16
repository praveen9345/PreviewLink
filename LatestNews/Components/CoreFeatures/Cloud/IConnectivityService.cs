namespace LatestNews.Components.CoreFeatures.Cloud
{
    
    /// <summary>
    ///     A service handling internet connectivity changes and information.
    /// </summary>
    public interface IConnectivityService
    {
        /// <summary>
        ///     Indicates whether an internet connection is currently available.
        /// </summary>
        /// <returns>True, if internet connection is available; otherwise false.</returns>
        bool IsInternetConnectionAvailable();

    }
}