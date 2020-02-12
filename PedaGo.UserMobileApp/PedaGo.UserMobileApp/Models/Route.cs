//-----------------------------------------------------------------------
// <copyright file="Route.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Route class
    /// </summary>
    public partial class Route
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Route" /> class.
        /// </summary>
        public Route()
        {
            this.Games = new HashSet<Game>();
            this.Routesteps = new HashSet<Routestep>();
            this.Routetags = new HashSet<Routetag>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>Name</c>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets <c>Description</c>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets <c>Handicap</c>
        /// </summary>
        public bool? Handicap { get; set; }

        /// <summary>
        /// Gets or sets <c>Time</c>
        /// </summary>
        public TimeSpan? Time { get; set; }

        /// <summary>
        /// Gets or sets <c>Distance</c>
        /// </summary>
        public int? Distance { get; set; }

        /// <summary>
        /// Gets or sets <c>OrganizerId</c>
        /// </summary>
        public int? OrganizerId { get; set; }

        /// <summary>
        /// Gets or sets <c>Organizer</c>
        /// </summary>
        public virtual Organizer Organizer { get; set; }

        /// <summary>
        /// Gets or sets <c>Games</c>
        /// </summary>
        public virtual ICollection<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets <c>Routesteps</c>
        /// </summary>
        public virtual ICollection<Routestep> Routesteps { get; set; }

        /// <summary>
        /// Gets or sets <c>Routetags</c>
        /// </summary>
        public virtual ICollection<Routetag> Routetags { get; set; }
    }
}
