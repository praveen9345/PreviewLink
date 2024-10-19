namespace LatestNews.Components.CoreFeatures.News.ViewModels
{
    using System.Text.RegularExpressions;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using LatestNews.Components.CoreFeatures.Cloud;
    using LatestNews.Components.CoreFeatures.Cloud.AccessManagement.Models;
    using LatestNews.Components.CoreFeatures.News.Views;
    using LatestNews.Components.ErrorManagement;
    using LatestNews.Components.UiFunctionality.Localization;
    using LatestNews.Components.UiFunctionality.Navigation.ViewModels;
    
    /// <summary>
    ///     The view model of the PreviewWebViewModel screen.
    /// </summary>
    public partial class RootViewModel : BaseViewModel
    {
        private readonly IPreviewLinkApiService _previewLinkApiService;
        private readonly IErrorLogger _errorLogger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RootViewModel" /> class.
        /// </summary>
        /// <param name="previewLinkApiService">The service used to retrieve web information from a URL.</param>
        /// <param name="errorLogger">The logger used to capture and display error messages.</param>
        public RootViewModel(IPreviewLinkApiService previewLinkApiService, IErrorLogger errorLogger)
        {
            _previewLinkApiService = previewLinkApiService;
            _errorLogger = errorLogger;
            IsBackNavigationEnabled = true;
        }

        /// <summary>
        ///     Gets or sets the preview link input provided by the user.
        /// </summary>
        [ObservableProperty]
        private string _previewLink;

        /// <summary>
        ///     Gets or sets the title retrieved from the web page.
        /// </summary>
        [ObservableProperty]
        private string _titleLink;

        /// <summary>
        ///     Gets or sets the description retrieved from the web page.
        /// </summary>
        [ObservableProperty]
        private string _descriptionLink;

        /// <summary>
        ///     Gets or sets the image URL retrieved from the web page.
        /// </summary>
        [ObservableProperty]
        private string _imageUrlLink;

        /// <summary>
        ///     Gets or sets the URL retrieved from the web page.
        /// </summary>
        [ObservableProperty]
        private string _urlLink;

        /// <summary>
        ///     Command that submits the provided preview link and retrieves web information.
        /// </summary>
        public AsyncRelayCommand SubmitCommand => new AsyncRelayCommand(async()=>
        {
            if (PreviewLink == null) return;

            var previewLink = PreviewLink.Trim();
            if( previewLink == string.Empty || !IsValidUrl(previewLink)) 
            {
                await _errorLogger.ErrorDisplay("", AppResources.RootViewModel_UrlNotValidText);
                return;

            }

            WebInformation webInfo = await _previewLinkApiService.GetWebInformation(previewLink);
            if (webInfo == null) return;
            
            TitleLink = webInfo.Title;
            DescriptionLink = webInfo.Description;
            ImageUrlLink = webInfo.Image;
            UrlLink = webInfo.Url;
        
        });

        /// <summary>
        ///     Command that handles navigation to the provided URL link.
        /// </summary>
        public AsyncRelayCommand TapCommand => new AsyncRelayCommand(async()=>
        {
            if (UrlLink == null || UrlLink == string.Empty)
            {
                await _errorLogger.ErrorDisplay("", AppResources.RootViewModel_EmptyEntryText);
                return;
            } 

            await NavigationService.Navigate<PreviewWebView>(UrlLink, false);
        });

      private bool IsValidUrl(string url)
      {
        // Regex pattern for validating a URL with optional http(s):// or www.
        var pattern = @"^(http|https):\/\/(www\.)?[^\s$.?#].[^\s]*|^www\.[^\s$.?#].[^\s]*$";
        return Regex.IsMatch(url, pattern);
      }
    }
}