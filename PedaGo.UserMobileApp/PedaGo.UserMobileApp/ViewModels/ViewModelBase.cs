//-----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using Prism.Mvvm;
    using Prism.Navigation;

    /// <summary>
    /// Base View Model, auto generated
    /// </summary>
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        /// <summary>
        /// Title string
        /// </summary>
        private string title;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase" /> class
        /// </summary>
        /// <param name="navigationService">Navigation service interface</param>
        public ViewModelBase(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        /// <summary>
        /// Gets or sets Title of the ViewModel
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }

        /// <summary>
        /// Gets Navigation service interface
        /// </summary>
        protected INavigationService NavigationService
        {
            get;
            private set;
        }

        /// <summary>
        /// Initialize the view Model
        /// </summary>
        /// <param name="parameters">Navigation Parameters</param>
        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Called when coming from <c>particuliar</c> view
        /// </summary>
        /// <param name="parameters">Navigation Parameters</param>
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Called when going to <c>particuliar</c> view
        /// </summary>
        /// <param name="parameters">Navigation Parameters</param>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Destroys the View Model
        /// </summary>
        public virtual void Destroy()
        {
        }
    }
}
