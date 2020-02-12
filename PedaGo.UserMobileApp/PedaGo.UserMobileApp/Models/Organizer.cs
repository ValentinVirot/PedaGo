//-----------------------------------------------------------------------
// <copyright file="Organizer.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.UserMobileApp.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Organizer class
    /// </summary>
    public partial class Organizer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Organizer" /> class.
        /// </summary>
        public Organizer()
        {
            this.Games = new HashSet<Game>();
            this.Messages = new HashSet<Message>();
            this.Players = new HashSet<Player>();
            this.Routes = new HashSet<Route>();
            this.Teams = new HashSet<Team>();
        }

        /// <summary>
        /// Gets or sets <c>Id</c>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <c>FirstName</c>
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets <c>LastName</c>
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets <c>Login</c>
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets <c>Password</c>
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets <c>Email</c>
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets <c>AdministratorId</c>
        /// </summary>
        public int? AdministratorId { get; set; }

        /// <summary>
        /// Gets or sets <c>Administrator</c>
        /// </summary>
        public virtual Administrator Administrator { get; set; }

        /// <summary>
        /// Gets or sets <c>Games</c>
        /// </summary>
        public virtual ICollection<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets <c>Messages</c>
        /// </summary>
        public virtual ICollection<Message> Messages { get; set; }

        /// <summary>
        /// Gets or sets <c>Players</c>
        /// </summary>
        public virtual ICollection<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets <c>Routes</c>
        /// </summary>
        public virtual ICollection<Route> Routes { get; set; }

        /// <summary>
        /// Gets or sets <c>Teams</c>
        /// </summary>
        public virtual ICollection<Team> Teams { get; set; }
    }
}
