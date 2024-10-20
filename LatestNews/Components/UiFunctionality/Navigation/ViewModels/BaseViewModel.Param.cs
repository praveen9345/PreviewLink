namespace LatestNews.Components.UiFunctionality.Navigation.ViewModels
{
    /// <summary>
    ///     The implementation of a base view model enabling the transfer of a parameter.
    /// </summary>
    public abstract partial class BaseViewModel<TParameter> : BaseViewModel, IQueryAttributable
        where TParameter : notnull
    {
        protected IDictionary<string, object> NavigationParameters;

        /// <summary>
        ///     Initializes an instance of <see cref="BaseViewModel"/> class.
        /// </summary>
        
        protected BaseViewModel(){}

        /// <summary>
        ///     Enabled to prepare the current view model with the passed parameter.
        /// </summary>
        /// <param name="parameter">The parameter object.</param>
        public abstract void Prepare(TParameter parameter);

        /// <summary>
        ///     Sets the parameters that were passed on navigation.
        /// </summary>
        /// <param name="query">The parameters that were passed as a dictionary.</param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            NavigationParameters = query;

            if (query.ContainsKey("parameter") && (query["parameter"] is TParameter param))
            {
                Prepare(param);
                query.Clear();
            }
        }
    }
}
