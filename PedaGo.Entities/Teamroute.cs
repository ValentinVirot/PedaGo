//-----------------------------------------------------------------------
// <copyright file="Teamroute.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Entities
{
    using System;

    /// <summary>
    /// <c>Teamroute</c> class
    /// </summary>
    public partial class Teamroute
    {
        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>GameId</c>
        /// </summary>
        public int? GameId { get; set; }

        /// <summary>
        /// Gets or sets <c>TeamId</c>
        /// </summary>
        public int? TeamId { get; set; }

        /// <summary>
        /// Gets or sets <c>RouteId</c>
        /// </summary>
        public int? RouteId { get; set; }

        /// <summary>
        /// Gets or sets <c>StepId</c>
        /// </summary>
        public int? StepId { get; set; }

        /// <summary>
        /// Gets or sets <c>StepOrder</c>
        /// </summary>
        public int StepOrder { get; set; }

        /// <summary>
        /// Gets or sets <c>ValidationDate</c>
        /// </summary>
        public DateTime? ValidationDate { get; set; }

        /// <summary>
        /// Gets or sets <c>Routestep</c>
        /// </summary>
        public virtual Routestep Routestep { get; set; }

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
