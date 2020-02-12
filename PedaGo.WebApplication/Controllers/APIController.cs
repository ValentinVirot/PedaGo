//-----------------------------------------------------------------------
// <copyright file="APIController.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
    using Microsoft.Extensions.Configuration;
    using PedaGo.Business.Contracts;
    using PedaGo.Entities;

    /// <summary>
    /// API routes Controller
    /// </summary>
    [ApiController, Route("[controller]")]
    public partial class APIController : ControllerBase
    {
        /// <summary>
        /// TrialBusiness interface, injected
        /// </summary>
        private ITrialBusiness trialBusiness;

        /// <summary>
        /// MissionBusiness interface, injected
        /// </summary>
        private IMissionBusiness missionBusiness;

        /// <summary>
        /// PlayerBusiness interface, injected
        /// </summary>
        private IPlayerBusiness playerBusiness;

        /// <summary>
        /// StepBusiness interface, injected
        /// </summary>
        private IStepBusiness stepBusiness;

        /// <summary>
        /// RouteBusiness interface, injected
        /// </summary>
        private IRouteBusiness routeBusiness;

        /// <summary>
        /// OrganizerBusiness, injected
        /// </summary>
        private IOrganizerBusiness organizerBusiness;

        /// <summary>
        /// GameBusiness, injected
        /// </summary>
        private IGameBusiness gameBusiness;

        /// <summary>
        /// Configuration interface, injected
        /// </summary>
        private IConfiguration config;

        /// <summary>
        /// Cognitive Services subscription key, in <c>secret.json</c>
        /// </summary>
        private string cognitiveServicesSubscriptionKey;

        /// <summary>
        /// Cognitive Services end point, in <c>secret.json</c>
        /// </summary>
        private string cognitiveServicesEndpoint;

        /// <summary>
        /// Computer Vision Client, connects to Cognitive services
        /// </summary>
        private ComputerVisionClient computerVisionClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="APIController" /> class.
        /// </summary>
        /// <param name="trial">ITrialBusiness, injected</param>
        /// <param name="mission">IMissionBusiness, injected</param>
        /// <param name="player">IPlayerBusiness, injected</param>
        /// <param name="step">IStepBusiness, injected</param>
        /// <param name="route">IRouteBusiness, injected</param>
        /// <param name="game">IGameBusiness, injected</param>
        /// <param name="organizer">IOrganizerBusiness, injected</param> 
        /// <param name="configSrc">Configuration interface, injected</param>  
        public APIController(ITrialBusiness trial, IMissionBusiness mission, IPlayerBusiness player, IStepBusiness step, IRouteBusiness route, IGameBusiness game, IOrganizerBusiness organizer, IConfiguration configSrc)
        {
            this.config = configSrc;
            this.trialBusiness = trial;
            this.missionBusiness = mission;
            this.playerBusiness = player;
            this.stepBusiness = step;
            this.routeBusiness = route;
            this.organizerBusiness = organizer;
            this.gameBusiness = game;
            this.cognitiveServicesSubscriptionKey = this.config["ComputerVisionKey"];
            this.cognitiveServicesEndpoint = this.config["ComputerVisionEndPoint"];

            this.computerVisionClient = new ComputerVisionClient(new ApiKeyServiceClientCredentials(this.cognitiveServicesSubscriptionKey)) { Endpoint = this.cognitiveServicesEndpoint };
        }
    }
}