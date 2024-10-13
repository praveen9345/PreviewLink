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
    }
}