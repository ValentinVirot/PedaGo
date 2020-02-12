//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Game class
    /// </summary>
    public partial class Game
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        public Game()
        {
            this.Plays = new HashSet<Play>();
            this.Teamanswers = new HashSet<Teamanswer>();
            this.Teamroutes = new HashSet<Teamroute>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>RouteId</c>
        /// </summary>
        public int? RouteId { get; set; }

        /// <summary>
        /// Gets or sets <c>FinalTime</c>
        /// </summary>
        public DateTime? FinalTime { get; set; }

        /// <summary>
        /// Gets or sets <c>FinalScore</c>
        /// </summary>
        public int? FinalScore { get; set; }

        /// <summary>
        /// Gets or sets <c>CreationDate</c>
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets <c>OrganizerId</c>
        /// </summary>
        public int? OrganizerId { get; set; }

        /// <summary>
        /// Gets or sets <c>TransportId</c>
        /// </summary>
        public int? TransportId { get; set; }

        /// <summary>
        /// Gets or sets <c>Organizer</c>
        /// </summary>
        public virtual Organizer Organizer { get; set; }

        /// <summary>
        /// Gets or sets <c>Route</c>
        /// </summary>
        public virtual Route Route { get; set; }

        /// <summary>
        /// Gets or sets <c>Transport</c>
        /// </summary>
        public virtual Transport Transport { get; set; }

        /// <summary>
        /// Gets or sets <c>Plays</c>
        /// </summary>
        public virtual ICollection<Play> Plays { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamanswers</c>
        /// </summary>
        public virtual ICollection<Teamanswer> Teamanswers { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamroutes</c>
        /// </summary>
        public virtual ICollection<Teamroute> Teamroutes { get; set; }
    }
}
