namespace LatestNews.Components.CoreFeatures.News.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using LatestNews.Components.UiFunctionality.Navigation.ViewModels;
    
    /// <summary>
    ///     The view model of the root view screen.
    /// </summary>
    public partial class PreviewWebViewModel : BaseViewModel<string>
    {
    
        /// <summary>
        ///     Initializes a new instance of the <see cref="PreviewWebViewModel" />.
        /// </summary>
        public PreviewWebViewModel()
        {
            IsBackNavigationEnabled = true;
        }

        [ObservableProperty]
        private string _webUrl;

        /// <summary>
        ///     Prepares the viewmode with an web url.
        /// </summary>
        /// <param name="webUrl">The string of web url.</param>
        public override void Prepare(string webUrl)
        {
            WebUrl = webUrl;
        }
    }
}