namespace LatestNews.Components.CoreFeatures.News.Views
{
    using LatestNews.Components.CoreFeatures.News.ViewModels;
    using LatestNews.Components.UiFunctionality.Navigation.Views;
    
    /// <summary>
    /// The code behind of the PreviewWev view.
    /// </summary>
    public partial class PreviewWebView : BaseView
    {
        /// <summary>
        ///  Initializes a new instance of the PreviewWebView class with the specified view model.
        /// </summary>
        /// <param name="viewModel">The PreviewWebViewModel associated with this view.</param>
        public PreviewWebView(PreviewWebViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

    }
}