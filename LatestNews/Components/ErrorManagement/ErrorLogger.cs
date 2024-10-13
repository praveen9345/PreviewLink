namespace LatestNews.Components.ErrorManagement
{
    /// <summary>
    ///     Implementation of the IErrorLogger interface. Provides support for error logging.
    /// </summary>
    public class ErrorLogger : IErrorLogger
    {
       /// <summary>
       ///  Log an error.
       /// </summary>
       /// <param name="className">the class name from where it is called.</param>
       /// <param name="message">the message which is for display in console.</param>
        public void LogError(string className, string message)
        {
            Console.WriteLine("Error:" +className +": "+ message);
        }
    }
}