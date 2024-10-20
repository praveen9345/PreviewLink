namespace LatestNews.Components.UiFunctionality.Navigation.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using LatestNews.Components.PlatformUtils;
    using Localization;
    using System.Threading.Tasks;
   
    /// <summary>
    ///     The implementation of a base view model that provides general logic and information needed on all screens.
    /// </summary>
    public abstract partial class BaseViewModel : ObservableObject
    {
        private bool _isBackNavigationEnabled = true;

        /// <summary>
        ///     Gets the navigation service to handle navigation throughout the app.
        /// </summary>
        public INavigationService NavigationService { get; }

        /// <summary>
        ///     Initializes an instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        protected BaseViewModel()
        {
            NavigationService = ServiceHelper.GetService<INavigationService>();
            BackNavigationCommand = new AsyncRelayCommand(OnBackButtonPressed, () => _isBackNavigationEnabled);
        }

        /// <summary>
        ///     Performs initialization tasks for the view model. This method is called when the view model is initialized.
        /// </summary>
        public virtual async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        ///     Sets the viewmodel as the current viewmodel. This method is called when the view appears.
        /// </summary>
        public virtual void ViewAppearing()
        {
            
        }

        /// <summary>
        ///     This method is called when the view disappears.
        /// </summary>
        public virtual void ViewDisappearing()
        {

        }

        /// <summary>
        ///     A property enabling the binding of localized resources by resource key.
        ///     The provided resource key does only need to specify the part behind the underscore
        ///     as the part before the underscore is automatically set according to the current view model.
        /// </summary>
        /// <param name="resourceKey">The resource key to get the value for.</param>
        public string this[string resourceKey] => AppResources.ResourceManager.GetString(GetType().Name + "_" + resourceKey);

        /// <summary>
        ///     Gets or sets a value determining whether back navigation is enabled.
        /// </summary>
        public bool IsBackNavigationEnabled
        {
            get => _isBackNavigationEnabled;
            set
            {
                if (SetProperty(ref _isBackNavigationEnabled, value))
                {
                    BackNavigationCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <summary>
        ///     Handles the back button tap.
        /// </summary>
        /// <returns>A task handling the back navigation.</returns>
        protected virtual async Task OnBackButtonPressed()
        {
            await NavigationService.Close();
        }

        /// <summary>
        ///     Command for the back button.
        /// </summary>
        public AsyncRelayCommand BackNavigationCommand { get; }

    }
}