//-----------------------------------------------------------------------
// <copyright file="Teamplayer.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    /// <summary>
    /// <c>Teamplayer</c> class
    /// </summary>
    public partial class Teamplayer
    {
        /// <summary>
        /// Gets or sets <c>TeamId</c>
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets <c>PlayerId</c>
        /// </summary>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets <c>Player</c>
        /// </summary>
        public virtual Player Player { get; set; }

        /// <summary>
        /// Gets or sets <c>Team</c>
        /// </summary>
        public virtual Team Team { get; set; }
    }
}
