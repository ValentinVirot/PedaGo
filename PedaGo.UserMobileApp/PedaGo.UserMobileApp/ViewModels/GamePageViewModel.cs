//-----------------------------------------------------------------------
// <copyright file="GamePageViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using PedaGo.UserMobileApp.Contracts;
    using PedaGo.UserMobileApp.Services;
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Navigation;

    /// <summary>
    /// ViewModel attached to Game Page
    /// </summary>
    public class GamePageViewModel : BindableBase
    {
        /// <summary>
        /// Step name, <c>Binded</c> in view
        /// </summary>
        private string stepName;

        /// <summary>
        /// <c>Parcours</c> name, <c>Binded</c> in view
        /// </summary>
        private string parcoursName;

        /// <summary>
        /// Step description, <c>Binded</c> in view
        /// </summary>
        private string stepDescription;

        /// <summary>
        /// NavigationService Interface, injected
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// Step repository interface, injected
        /// </summary>
        private IStepRepository stepRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamePageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">NavigationService interface, injected</param>
        /// <param name="step">Step repository interface, injected</param>
        public GamePageViewModel(INavigationService navigationService, IStepRepository step)
        {
            this.navigationService = navigationService;
            this.NavigateTeam = new DelegateCommand(this.GoToTeam);
            this.NavigateValidation = new DelegateCommand(this.GoToValidation);
            this.stepRepo = step;

            CurrentUser.CurrentStep = step.GetCurrentStep(CurrentUser.Player.Id);

            this.ParcoursName = CurrentUser.CurrentStep.RouteName;
            this.StepName = CurrentUser.CurrentStep.StepName;
            this.StepDescription = CurrentUser.CurrentStep.StepDescription;
        }

        /// <summary>
        /// Gets or sets <c>StepName</c>
        /// </summary>
        public string StepName { get => this.stepName; set => this.stepName = value; }

        /// <summary>
        /// Gets or sets <c>ParcoursName</c>
        /// </summary>
        public string ParcoursName { get => this.parcoursName; set => this.parcoursName = value; }

        /// <summary>
        /// Gets or sets <c>StepDescription</c>
        /// </summary>
        public string StepDescription { get => this.stepDescription; set => this.stepDescription = value; }

        /// <summary>
        /// Gets command <c>binded</c> in view, to navigate to Validation Page
        /// </summary>
        public DelegateCommand NavigateValidation { get; private set; }

        /// <summary>
        /// Gets command <c>binded</c> in view, to navigate to Team Page
        /// </summary>
        public DelegateCommand NavigateTeam { get; private set; }

        /// <summary>
        /// Method that navigates to Validation Page
        /// </summary>
        private void GoToValidation()
        {
            this.navigationService.NavigateAsync("ValidationPage");
        }

        /// <summary>
        /// Method called when NavigateTeam is triggered
        /// </summary>
        private void GoToTeam()
        {
            this.navigationService.NavigateAsync("TeamPage");
        }
    }
}
