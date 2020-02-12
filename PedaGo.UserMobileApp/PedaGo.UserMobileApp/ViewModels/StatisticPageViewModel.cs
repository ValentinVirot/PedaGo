//-----------------------------------------------------------------------
// <copyright file="StatisticPageViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using Prism.Mvvm;

    /// <summary>
    /// ViewModel attached to Statistic Page
    /// </summary>
    public class StatisticPageViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticPageViewModel"/> class.
        /// </summary>
        public StatisticPageViewModel()
        {
            this.Stats = new StatsViewModel
            {
                DistanceTotale = "Distance totale : 94 km",
                DureeTotale = "Durée totale : 05:17:00",
                DistanceMarchee = "Distance marchée : 14 km",
                DistanceVelo = "Distance à vélo : 42 km",
                DistanceVoiture = "Distance en voiture : 12 km"
            };
        }

        /// <summary>
        /// Gets or sets list of stats
        /// </summary>
        public StatsViewModel Stats { get; set; }
    }
}
