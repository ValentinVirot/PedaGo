//-----------------------------------------------------------------------
// <copyright file="HistoryViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    using System;

    /// <summary>
    /// History View Model, passed to HistoryPage View
    /// </summary>
    public class HistoryViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryViewModel" /> class.
        /// </summary>
        /// <param name="nameSrc">Game name</param>
        /// <param name="distanceSrc">Distance (in km)</param>
        /// <param name="timeSrc">Duration of the game</param>
        public HistoryViewModel(string nameSrc, int distanceSrc, TimeSpan timeSrc)
        {
            this.Name = nameSrc;
            this.Distance = distanceSrc.ToString() + " km";
            this.Time = timeSrc.ToString();
        }

        /// <summary>
        /// Gets or sets game Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets game distance (in km)
        /// </summary>
        public string Distance { get; set; }

        /// <summary>
        /// Gets or sets game duration
        /// </summary>
        public string Time { get; set; }
    }
}
