//-----------------------------------------------------------------------
// <copyright file="Play.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System;

    /// <summary>
    /// Play class
    /// </summary>
    public partial class Play
    {
        /// <summary>
        /// Gets or sets <c>GameId</c>
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets <c>TeamId</c>
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets <c>Score</c>
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        /// Gets or sets <c>StartDate</c>
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets <c>EndDate</c>
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets <c>Time</c>
        /// </summary>
        public TimeSpan? Time { get; set; }

        /// <summary>
        /// Gets or sets <c>Game</c>
        /// </summary>
        public virtual Game Game { get; set; }

        /// <summary>
        /// Gets or sets <c>Team</c>
        /// </summary>
        public virtual Team Team { get; set; }
    }
}
