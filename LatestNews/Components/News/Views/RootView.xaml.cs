namespace LatestNews.Components.News.Views
{
    using LatestNews.Components.News.ViewModels;
    using LatestNews.Components.UiFunctionality.Navigation.Views;
    
    /// <summary>
    /// The code behind of the RootView view.
    /// </summary>
    public partial class RootView : BaseView
    {
        /// <summary>
        ///  Initializes a new instance of the RootView class with the specified view model.
        /// </summary>
        /// <param name="viewModel">The RootViewModel associated with this view.</param>
        public RootView(RootViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        /// <summary>
        ///  Overrides the behavior of the back button to quit the application.
        /// </summary>
        protected override bool OnBackButtonPressed()
        {
           Application.Current.Quit();
           return base.OnBackButtonPressed();       
        }
    }
}