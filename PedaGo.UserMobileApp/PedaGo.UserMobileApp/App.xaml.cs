//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace PedaGo.UserMobileApp
{
    using PedaGo.UserMobileApp.Contracts;
    using PedaGo.UserMobileApp.Services;
    using PedaGo.UserMobileApp.ViewModels;
    using PedaGo.UserMobileApp.Views;
    using Prism;
    using Prism.Ioc;
    using Xamarin.Forms;

    /// <summary>
    /// Main app class
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        /// <param name="initializer">Platform initializer interface</param>
        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        /// <summary>
        /// When the app is initialized
        /// </summary>
        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        /// <summary>
        /// Main App registry (navigation + dependency injection)
        /// </summary>
        /// <param name="containerRegistry">Container registry interface</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<HistoryPage, HistoryPageViewModel>();
            containerRegistry.RegisterSingleton<IAuthRepository, APIAuthRepository>();
            containerRegistry.RegisterSingleton<IMissionRepository, APIMissionRepository>();
            containerRegistry.RegisterSingleton<IPlayerRepository, APIPlayerRepository>();
            containerRegistry.RegisterSingleton<IStepRepository, APIStepRepository>();
            containerRegistry.RegisterSingleton<IGameRepository, APIGameRepository>();
            containerRegistry.RegisterForNavigation<StatisticPage, StatisticPageViewModel>();
            containerRegistry.RegisterForNavigation<GamePage, GamePageViewModel>();
            containerRegistry.RegisterForNavigation<TeamPage, TeamPageViewModel>();
            containerRegistry.RegisterForNavigation<ValidationPage, ValidationPageViewModel>();
        }
    }
}
