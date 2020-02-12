//-----------------------------------------------------------------------
// <copyright file="HomePageViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using PedaGo.UserMobileApp.Services;
    using Prism.Commands;
    using Prism.Navigation;

    /// <summary>
    /// ViewModel Home Page (page to see the <c>differents</c> pages)
    /// </summary>
    public class HomePageViewModel : ViewModelBase
    {
        /// <summary>
        /// Navigation service interface
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// <c>Username, binded</c> in view
        /// </summary>
        private string username;

        /// <summary>
        /// <c>Profile picture, binded</c> in view
        /// </summary>
        private string profilePicture;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">Navigation service interface</param>
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navigationService = navigationService;

            this.NavigateStatistique = new DelegateCommand(this.GoToStatistic);
            this.NavigateHistorique = new DelegateCommand(this.GoToHistorique);
            this.NavigateGame = new DelegateCommand(this.GoToGame);
            this.NavigateRoutes = new DelegateCommand(this.GoToRoutes);

            this.Username = CurrentUser.Player.FirstName + " " + CurrentUser.Player.LastName;

            if (CurrentUser.Player.Picture == null || CurrentUser.Player.Picture == string.Empty)
            {
                this.profilePicture = PedaGoServers.DefaultProfilePic;
            }
            else
            {
                this.profilePicture = CurrentUser.Player.Picture;
            }
        }

        /// <summary>
        /// Gets or sets <c>Username</c>
        /// </summary>
        public string Username { get => this.username; set => this.username = value; }

        /// <summary>
        /// Gets or sets user profile picture
        /// </summary>
        public string ProfilePicture { get => this.profilePicture; set => this.profilePicture = value; }

        /// <summary>
        /// Gets <c>NavigateRoutes</c>
        /// </summary>
        public DelegateCommand NavigateRoutes { get; private set; }

        /// <summary>
        /// Gets <c>NavigateHistory</c>
        /// </summary>
        public DelegateCommand NavigateHistory { get; private set; }

        /// <summary>
        /// Gets <c>NavigateStatistique</c>
        /// </summary>
        public DelegateCommand NavigateStatistique { get; private set; }

        /// <summary>
        /// Gets <c>NavigateHistorique</c>
        /// </summary>
        public DelegateCommand NavigateHistorique { get; private set; }

        /// <summary>
        /// Gets <c>NavigateGame</c>
        /// </summary>
        public DelegateCommand NavigateGame { get; private set; }

        /// <summary>
        /// Go to Routes page
        /// </summary>
        public void GoToRoutes()
        {
            this.navigationService.NavigateAsync("RoutesPage");
        }

        /// <summary>
        /// Go to Game page
        /// </summary>
        private void GoToGame()
        {
            this.navigationService.NavigateAsync("GamePage");
        }

        /// <summary>
        /// Go to <c>Historique</c> page
        /// </summary>
        private void GoToHistorique()
        {
            this.navigationService.NavigateAsync("HistoryPage");
        }

        /// <summary>
        /// Go to Statistic page
        /// </summary>
        private void GoToStatistic()
        {
            this.navigationService.NavigateAsync("StatisticPage");
        }
    }
}
