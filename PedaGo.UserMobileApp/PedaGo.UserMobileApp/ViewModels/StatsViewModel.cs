//-----------------------------------------------------------------------
// <copyright file="StatsViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    /// <summary>
    /// Stats View Model
    /// </summary>
    public class StatsViewModel
    {
        /// <summary>
        /// Gets or sets total distance
        /// </summary>
        public string DistanceTotale { get; set; }

        /// <summary>
        /// Gets or sets total duration
        /// </summary>
        public string DureeTotale { get; set; }

        /// <summary>
        /// Gets or sets walked distance
        /// </summary>
        public string DistanceMarchee { get; set; }

        /// <summary>
        /// Gets or sets distance riding a bike
        /// </summary>
        public string DistanceVelo { get; set; }

        /// <summary>
        /// Gets or sets distance by car
        /// </summary>
        public string DistanceVoiture { get; set; }
    }
}
