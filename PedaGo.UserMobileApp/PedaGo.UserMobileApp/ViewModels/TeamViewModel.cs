//-----------------------------------------------------------------------
// <copyright file="TeamViewModel.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.ViewModels
{
    /// <summary>
    /// Team View Model, contains only data needed to bind in Team view
    /// </summary>
    public class TeamViewModel
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a player is captain
        /// </summary>
        public bool IsCaptain { get; set; }
    }
}
