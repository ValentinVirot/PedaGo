//-----------------------------------------------------------------------
// <copyright file="Teamanswer.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System;

    /// <summary>
    /// <c>Teamanswer</c> class
    /// </summary>
    public partial class Teamanswer
    {
        /// <summary>
        /// Gets or sets <c>TeamId</c>
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets <c>GameId</c>
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets <c>TrialId</c>
        /// </summary>
        public int TrialId { get; set; }

        /// <summary>
        /// Gets or sets <c>AnswerId</c>
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// Gets or sets <c>TextAnswer</c>
        /// </summary>
        public string TextAnswer { get; set; }

        /// <summary>
        /// Gets or sets <c>Date</c>
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets <c>Good</c>
        /// </summary>
        public bool? Good { get; set; }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>Answer</c>
        /// </summary>
        public virtual Answer Answer { get; set; }

        /// <summary>
        /// Gets or sets <c>Game</c>
        /// </summary>
        public virtual Game Game { get; set; }

        /// <summary>
        /// Gets or sets <c>Team</c>
        /// </summary>
        public virtual Team Team { get; set; }

        /// <summary>
        /// Gets or sets <c>Trial</c>
        /// </summary>
        public virtual Trial Trial { get; set; }
    }
}
