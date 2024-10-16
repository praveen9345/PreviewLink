using LatestNews.Components.UiFunctionality.Localization;

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

        /// <summary>
        ///     Displays a notification or message to the user with the specified title and content.
        /// </summary>
        /// <param name="message">The content or body of the message to display to the user.</param>
        /// <param name="title">The title or heading of the message.</param>
        public async Task ErrorDisplay(string message, string title = "")
        {
            await Application.Current.MainPage.DisplayAlert(title, 
                message, AppResources.Dialog_OK_Text);
        }
    }
}