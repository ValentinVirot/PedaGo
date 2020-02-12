//-----------------------------------------------------------------------
// <copyright file="LoginPageViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using PedaGo.UserMobileApp.Contracts;
    using PedaGo.UserMobileApp.Services;
    using Prism.Commands;
    using Prism.Navigation;
    using Xamarin.Forms;

    /// <summary>
    /// ViewModel of the Login Page (connection page of the app)
    /// </summary>
    public class LoginPageViewModel
    {
        /// <summary>
        /// Navigation service interface
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// Authentication repository interface
        /// </summary>
        private IAuthRepository authRepo;

        /// <summary>
        /// Player repository interface
        /// </summary>
        private IPlayerRepository playerRepo;

        /// <summary>
        /// User name (from view)
        /// </summary>
        private string username;

        /// <summary>
        /// Password (from view)
        /// </summary>
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">Navigation service interface</param>
        /// <param name="authRepo">Authentication Repository interface</param>
        /// <param name="playerRepository">Player Repository interface</param>
        public LoginPageViewModel(INavigationService navigationService, IAuthRepository authRepo, IPlayerRepository playerRepository)
        {
            this.authRepo = authRepo;
            this.navigationService = navigationService;
            this.playerRepo = playerRepository;

            this.NavigateHome = new DelegateCommand(this.GoToHome);
            this.LoginTest = new DelegateCommand(this.LoginWithStaticAccount);

            CurrentUser.Player = new Models.Player();
        }

        /// <summary>
        /// Gets <c>NavigateHome</c>
        /// </summary>
        public DelegateCommand NavigateHome { get; private set; }

        /// <summary>
        /// Gets <c>LoginTest</c> DelegateCommand
        /// </summary>
        public DelegateCommand LoginTest { get; private set; }

        /// <summary>
        /// Gets or sets <c>Username</c>
        /// </summary>
        public string Username { get => this.username; set => this.username = value; }

        /// <summary>
        /// Gets or sets <c>Password</c>
        /// </summary>
        public string Password { get => this.password; set => this.password = value; }

        /// <summary>
        /// Go to Home Page
        /// </summary>
        public async void GoToHome()
        {
            CurrentUser.Player.Login = this.username;
            CurrentUser.Player.Password = this.password;

            CurrentUser.Token = this.authRepo.GetToken(CurrentUser.Player.Login, CurrentUser.Player.Password);

            if (CurrentUser.Token == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error while connecting. Wrong username/password?", "Dismiss");
            }
            else
            {
                CurrentUser.Player = this.playerRepo.GetUserDetails(CurrentUser.Player.Login, CurrentUser.Player.Password);

                await this.navigationService.NavigateAsync("HomePage");
            }
        }

        /// <summary>
        /// Go to Home Page
        /// </summary>
        public async void LoginWithStaticAccount()
        {
            CurrentUser.Player.Login = "ValentinVirot";
            CurrentUser.Player.Password = "password";

            CurrentUser.Token = this.authRepo.GetToken(CurrentUser.Player.Login, CurrentUser.Player.Password);

            if (CurrentUser.Token == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error while connecting. Wrong username/password?", "Dismiss");
            }
            else
            {
                CurrentUser.Player = this.playerRepo.GetUserDetails(CurrentUser.Player.Login, CurrentUser.Player.Password);

                await this.navigationService.NavigateAsync("HomePage");
            }
        }
    }
}
