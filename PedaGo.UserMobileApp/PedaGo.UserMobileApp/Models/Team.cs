//-----------------------------------------------------------------------
// <copyright file="Team.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Team class
    /// </summary>
    public partial class Team
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Team" /> class.
        /// </summary>
        public Team()
        {
            this.Plays = new HashSet<Play>();
            this.Teamanswers = new HashSet<Teamanswer>();
            this.Teamplayers = new HashSet<Teamplayer>();
            this.Teamroutes = new HashSet<Teamroute>();
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
        /// Gets or sets <c>CaptainId</c>
        /// </summary>
        public int? CaptainId { get; set; }

        /// <summary>
        /// Gets or sets <c>OrganizerId</c>
        /// </summary>
        public int? OrganizerId { get; set; }

        /// <summary>
        /// Gets or sets <c>Captain</c>
        /// </summary>
        public virtual Player Captain { get; set; }

        /// <summary>
        /// Gets or sets <c>Organizer</c>
        /// </summary>
        public virtual Organizer Organizer { get; set; }

        /// <summary>
        /// Gets or sets <c>Plays</c>
        /// </summary>
        public virtual ICollection<Play> Plays { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamanswers</c>
        /// </summary>
        public virtual ICollection<Teamanswer> Teamanswers { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamplayers</c>
        /// </summary>
        public virtual ICollection<Teamplayer> Teamplayers { get; set; }

        /// <summary>
        /// Gets or sets <c>Teamroutes</c>
        /// </summary>
        public virtual ICollection<Teamroute> Teamroutes { get; set; }
    }
}
