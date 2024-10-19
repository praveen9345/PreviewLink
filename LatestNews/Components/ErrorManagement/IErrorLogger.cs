namespace LatestNews.Components.ErrorManagement
{
    /// <summary>
    ///     Provides support for error logging.
    /// </summary>
    public interface IErrorLogger
    {

       /// <summary>
       ///  Log an error.
       /// </summary>
       /// <param name="className">the class name from where it is called.</param>
       /// <param name="message">the message which is for display</param>
        void LogError(string className, string message);

        /// <summary>
        ///     Displays a notification or message to the user with the specified title and content.
        /// </summary>
        /// <param name="message">The content or body of the message to display to the user.</param>
        /// <param name="title">The title or heading of the message.</param>
        Task ErrorDisplay(string message, string title);
    }
}