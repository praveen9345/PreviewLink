namespace LatestNews.Components.CoreFeatures.Cloud
{
    using LatestNews.Components.ErrorManagement;

    /// <summary>
    ///     The implementation of the <see cref="IConnectivityService"/>, which
    ///     provide the connectivity information of the device.
    /// </summary>
    public class ConnectivityService : IConnectivityService
    {
        private readonly IErrorLogger _errorLogger;
       
        /// <summary>
        /// Initializes a new instance of the ConnectivityService class, 
        /// providing error logging functionality.
        /// </summary>
        /// <param name="errorLogger">Logs errors and displays them in the console.</param>
        public ConnectivityService( IErrorLogger errorLogger)
        {
            _errorLogger = errorLogger;
        }

        /// <summary>
        ///     Indicates whether an internet connection is currently available.
        /// </summary>
        /// <returns>True, if internet connection is available; otherwise false.</returns>
        public bool IsInternetConnectionAvailable()
        {
            try
            {
                return Connectivity.NetworkAccess == NetworkAccess.Internet;
            }
            catch (PermissionException exception)
            {
                _errorLogger.LogError("ConnectivityService.cs: IsInternetConnectionAvailableAsync: ",
                    "Missing Network State Permission to check Internet accessibility.");
                 _errorLogger.LogError("ConnectivityService.cs: IsInternetConnectionAvailableAsync: ",exception.Message);
                return false;
            }
        }

    }
}